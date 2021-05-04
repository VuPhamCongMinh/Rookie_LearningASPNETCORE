import { GetCategories } from "../../api/category_api";
import { DeleteProduct } from "../../api/product_api";
import { alertSuccess } from "../../utils/sweetalert_util";
import { ActionTypes } from "../constants/action_types";
import { setCategories } from "./category_actions";

export const addNewProduct = (product) => {
  return {
    type: ActionTypes.ADD_NEW_PRODUCT,
    payload: product,
  };
};

export const updateProduct = (product) => {
  return {
    type: ActionTypes.UPDATE_PRODUCT,
    payload: product,
  };
};
export const setProducts = (productList) => {
  return {
    type: ActionTypes.SET_PRODUCTS,
    payload: productList,
  };
};

export const setSelectedProduct = (product) => {
  return {
    type: ActionTypes.SET_SELECTED_PRODUCT,
    payload: product,
  };
};

export const sortProductsByPrice = (sortOption) => {
  return {
    type: ActionTypes.SORT_PRODUCTS_BY_NAME,
    payload: sortOption,
  };
};

export const sortProductsByCategory = (sortOption) => {
  return {
    type: ActionTypes.SORT_PRODUCTS_BY_CATEGORY,
    payload: sortOption,
  };
};

export const clearSelectedProduct = () => {
  return {
    type: ActionTypes.CLEAR_SELECTED_PRODUCT,
  };
};

export const deleteProductRequest = (id) => {
  return (dispatch) => {
    DeleteProduct(id).then((res) => {
      res === true && dispatch(deleteProduct(id));
      GetCategories().then((cateRes) => {
        dispatch(setCategories(cateRes.data));
      });
      alertSuccess("Xóa");
    });
  };
};

export const deleteProduct = (id) => {
  return {
    type: ActionTypes.DELETE_PRODUCT,
    payload: id,
  };
};
