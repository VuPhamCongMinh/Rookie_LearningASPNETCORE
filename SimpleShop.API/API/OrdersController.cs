using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;

namespace SimpleShop.API.API
{
    [Route("api/[controller]")]
    [Authorize("User")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService service;
        private readonly IMapper mapper;
        private readonly IFilesService filesService;

        public OrdersController (IOrderService service, IMapper mapper, IFilesService filesService)
        {
            this.service = service;
            this.mapper = mapper;
            this.filesService = filesService;
        }

        // GET: api/Orders
        [Authorize("Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrders ()
        {
            var orders = mapper.Map<IEnumerable<OrderResponse>>(await service.GetOrders());
            if (orders != null)
            {
                foreach (var order in orders)
                {
                    foreach (var odDetails in order.orderDetails)
                    {
                        foreach (var prodImg in odDetails.Product.Images)
                        {
                            prodImg.imageUrl = filesService.GetFileUrl(prodImg.imageUrl);
                        }
                    }
                }
            }
            return Ok(orders);
        }

        // GET: api/Orders/5
        [Authorize("Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder (string id)
        {
            var order = await service.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrder (string id, Order order)
        //{

        //}

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder ([FromBody] OrderCreateRequest order)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var orderToBeAdded = await service.PostOrderAsync(order, userId);
                return CreatedAtAction(nameof(GetOrder), new { id = orderToBeAdded.orderId }, orderToBeAdded);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("/api/GetUserOrder")]
        public async Task<ActionResult<OrderDetailResponse>> GetUserOrder (string userId)
        {
            var userOrder = await service.GetUserOrderDetailAsync(userId);
            if (userOrder != null)
            {
                var od = new OrderDetailResponse { orderDetails = userOrder, totalPrice = userOrder.Sum(o => (o.Product.productPrice * o.quantity)) };

                foreach (var odDetails in od.orderDetails)
                {
                    foreach (var prodImg in odDetails.Product.Images)
                    {
                        prodImg.imageUrl = filesService.GetFileUrl(prodImg.imageUrl);
                    }
                }
                return Ok(od);
            }
            return NotFound();
        }

        [HttpGet("/api/CountUserOrder")]
        public ActionResult<int> CountUserOrder (string userId)
        {
            var userOrder = service.CountUserOrderAsync(userId);
            return Ok(userOrder);
        }
    }
}
