export const ProductFormData = (formData) => {
  // Khởi tạo FormData từ các input trong form trả về thông qua biến formData
  // do sử dụng FormData nên phải trong API controller phải dùng attribute [FromForm] trước paramter - tui đã mất 1 ngày trời để biết chiện này :((
  let myFormData = new FormData();

  if (formData.productId) {
    myFormData.append("productId", formData.productId);
  }
  console.log(formData);
  if (formData.categoryId) {
    myFormData.append("categoryId", formData.categoryId);
  }

  myFormData.append("productName", formData.productName);
  myFormData.append("productPrice", formData.productPrice);
  myFormData.append("productDescription", formData.productDescription);
  if (formData.ImageFiles) {
    // Câu lệnh spread operator để clone ImagesFiles thành Array để có thể dùng map
    [...formData.ImageFiles].forEach((file) => {
      myFormData.append("ImageFiles", file);
    });
  }
  return myFormData;
};
