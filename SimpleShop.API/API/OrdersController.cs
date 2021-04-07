using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Shared.EF;
using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;

namespace SimpleShop.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IOrderService service;
        private readonly IMapper mapper;

        public OrdersController (MyDBContext context, IOrderService service, IMapper mapper)
        {
            _context = context;
            this.service = service;
            this.mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrders ()
        {
            var orders = mapper.Map<IEnumerable<OrderResponse>>(await _context.Orders.Include(o => o.orderDetails).ToListAsync());
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder (string id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder (string id, Order order)
        {
            if (id != order.orderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder ([FromForm] OrderCreateRequest order)
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

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder (string id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists (string id)
        {
            return _context.Orders.Any(e => e.orderId == id);
        }

        [Authorize("Bearer")]
        [HttpGet("/api/GetUserOrder")]
        public async Task<ActionResult<OrderDetailResponse>> GetUserOrder (string userId)
        {
            var userOrder = await service.GetUserOrderDetailAsync(userId);
            if (userOrder != null)
            {
                var od = new OrderDetailResponse { orderDetails = userOrder, totalPrice = userOrder.Sum(o => (o.Product.productPrice * o.quantity)) };
                return Ok(od);
            }
            return NotFound();
        }

        [Authorize("Bearer")]
        [HttpGet("/api/CountUserOrder")]
        public ActionResult<int> CountUserOrder (string userId)
        {
            var userOrder = service.CountUserOrderAsync(userId);
            return Ok(userOrder);
        }
    }
}
