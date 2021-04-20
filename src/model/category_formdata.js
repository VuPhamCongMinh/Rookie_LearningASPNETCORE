export const CategoryFormData = (formData) => {
  console.log(formData);
  let myFormData = new FormData();
  if (formData.categoryId) {
    myFormData.append("categoryId", formData.categoryId);
  }
  myFormData.append("categoryName", formData.categoryName);
  return myFormData;
};
