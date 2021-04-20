import { PostCategory, PutCategory } from "../api/category_api";
import { PostProducts, PutProducts } from "../api/product_api";
import { ProductFormData } from "../model/product_formdata";
import { CategoryFormData } from "../model/category_formdata";

export const productSubmitHandle = async (
  selectedItem,
  setProductItems,
  productItems,
  formData,
  setValue,
  setSelectedItem
) => {
  let returnData;
  let myFormData = ProductFormData(formData);

  if (!myFormData.get("productId")) {
    returnData = await PostProducts(myFormData);

    alert(JSON.stringify(returnData));

    if (returnData != null) setProductItems((prev) => [...prev, returnData]);
  } else {
    returnData = await PutProducts(myFormData);
    if (returnData != null) {
      let newProducts = productItems.map((prod) =>
        prod.productId === returnData.productId ? returnData : prod
      );
      setProductItems(newProducts);
    }
  }

  resetForm(selectedItem, setValue, setSelectedItem);
};

export const cagetorySubmitHandle = async (
  categories,
  setCategories,
  selectedCate,
  setSelectedCate,
  formData,
  setValue
) => {
  let returnData;
  let myFormData = CategoryFormData(formData);

  if (!myFormData.get("categoryId")) {
    returnData = await PostCategory(myFormData);
    if (returnData != null) setCategories((prev) => [...prev, returnData]);
  } else {
    returnData = await PutCategory(myFormData);
    if (returnData != null) {
      let newCategories = categories.map((cate) =>
        cate.categoryId === returnData.categoryId ? returnData : cate
      );
      setCategories(newCategories);
    }
  }

  resetForm(selectedCate, setValue, setSelectedCate);
};

const resetForm = (selectedItem, setValue, setSelectedItem) => {
  Object.keys(selectedItem).forEach((x) => {
    setValue(x, "");
  });
  setSelectedItem({});
};
