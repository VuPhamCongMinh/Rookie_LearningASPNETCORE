

# Nashtech Rookie - Stage 1

**Sơ đồ kiến trúc**
![Tham khảo từ project myshop của anh Thiện](https://user-images.githubusercontent.com/68691395/116875087-8ab7ff80-ac44-11eb-8542-bd2427b6a2da.png)

 **Sơ đồ cơ sở dữ liệu**
 ![enter image description here](https://user-images.githubusercontent.com/68691395/116876217-4e859e80-ac46-11eb-91ee-f94da83dffd2.png)

**Một project E-Commerce website với một số tính năng sau :**

> Trang Customer :

		-   Xem sản phẩm theo danh mục 
		-   Xem chi tiết sản phẩm
		-   Tìm kiếm sản phẩm theo tên
		-   Tìm kiếm theo giá 
		-   Đăng nhập/đăng ký/đăng xuất 
		-   Theo dõi sản phẩm trong giỏ hàng
		-   Đánh giá sản phẩm
 

> Trang Admin:

		-   Đăng nhập/đăng xuất
		-   Thêm/xóa/sửa sản phẩm
		-   Thêm/xóa/sửa danh mục
		-   Xem danh sách User
 
 > Unit Test:

		-   Test Get, GetById, Post và Put API sản phẩm 
		-   Test Get, GetById, Post và Put API danh mục
		-   Test Get, GetById, Post và Put API đánh giá
		-   Test Get, GetById, Post và Put API giỏ hàng

## Migration
Bước 1 : chuột phải SimpleShop.API chọn Set as Startup Project \
Bước 2 : vào Package Manager Console chọn Default project là 
SimpleShop.Shared \
Bước 3 : chạy các lệnh migration như thường \

## Thư viện sử dụng

 - [React Hook Form](https://react-hook-form.com/)
 - [axios](https://github.com/axios/axios)
 - [Redux](https://redux.js.org/)
 - [oidc-client-js: OpenID Connect (OIDC) and OAuth2 protocol support for browser-based JavaScript applications](https://github.com/IdentityModel/oidc-client-js)
 - [reactstrap - React Bootstrap 4 components](https://reactstrap.github.io/)
 - [react-router](https://github.com/ReactTraining/react-router)

## Nguồn tham khảo

 - [onggieoi/NashEcommerce: Stage 1 Challenge (github.com)](https://github.com/onggieoi/NashEcommerce)
 - [thiennn/myshop: A sample of modern ASP.NET Core project (github.com)](https://github.com/thiennn/myshop)
 - [Aranoz - Free Bootstrap 4 HTML5 Ecommerce Website Template (themewagon.com)](https://themewagon.com/themes/free-bootstrap-4-html5-ecommerce-website-template-aranoz/)
