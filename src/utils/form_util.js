import { PostCategory, PutCategory } from "../api/category_api";
import { PostProducts, PutProducts } from "../api/product_api";
import { ProductFormData } from "../model/product_formdata";
import { CategoryFormData } from "../model/category_formdata";
import store from "../redux/store";
import {
  addNewProduct,
  updateProduct,
  clearSelectedProduct,
} from "../redux/actions/product_actions";
import {
  addNewCategory,
  updateCategory,
  clearSelectedCategory,
} from "../redux/actions/category_actions";

export const productSubmitHandle = async (formData, setValue) => {
  let returnData;
  let myFormData = ProductFormData(formData);

  if (!myFormData.get("productId")) {
    returnData = await PostProducts(myFormData);
    if (returnData != null) {
      store.dispatch(addNewProduct(returnData));
    }
  } else {
    returnData = await PutProducts(myFormData);
    if (returnData != null) {
      store.dispatch(updateProduct(returnData));
    }
  }

  resetForm(formData, setValue);
  store.dispatch(clearSelectedProduct());
};

export const cagetorySubmitHandle = async (formData, setValue) => {
  let returnData;
  let myFormData = CategoryFormData(formData);

  if (!myFormData.get("categoryId")) {
    returnData = await PostCategory(myFormData);
    if (returnData != null) {
      store.dispatch(addNewCategory(returnData));
    }
  } else {
    returnData = await PutCategory(myFormData);
    if (returnData != null) {
      store.dispatch(updateCategory(returnData));
    }
  }

  resetForm(formData, setValue);
  store.dispatch(clearSelectedCategory());
};

const resetForm = (formData, setValue) => {
  Object.keys(formData).forEach((x) => {
    setValue(x, "");
  });
};
