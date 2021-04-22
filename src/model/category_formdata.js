export const CategoryFormData = (formData) => {
  let myFormData = new FormData();
  if (formData.categoryId) {
    myFormData.append("categoryId", formData.categoryId);
  }
  myFormData.append("categoryName", formData.categoryName);
  return myFormData;
};
