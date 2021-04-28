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
import { alertError, alertSuccess } from "./sweetalert_util";

export const productSubmitHandle = async (formData, setValue) => {
  let returnData;
  let myFormData = ProductFormData(formData);

  if (!myFormData.get("productId")) {
    returnData = await PostProducts(myFormData);
    if (returnData != null) {
      store.dispatch(addNewProduct(returnData));
      alertSuccess("Thêm sản phẩm");
    } else {
      alertError("Thêm sản phẩm");
    }
  } else {
    returnData = await PutProducts(myFormData);
    if (returnData != null) {
      alertSuccess("Sửa sản phẩm");
      store.dispatch(updateProduct(returnData));
    } else {
      alertError("Sửa sản phẩm");
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
      alertSuccess("Thêm danh mục");
      store.dispatch(addNewCategory(returnData));
    }
  } else {
    returnData = await PutCategory(myFormData);
    if (returnData != null) {
      alertSuccess("Sửa danh mục");
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

export const scrollToTop = () => {
  window.scrollTo({
    top: 0,
    behavior: "smooth",
  });
};
