import { DeleteProduct } from "../../api/product_api";
import { ActionTypes } from "../constants/action_types";

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
    DeleteProduct(id).then((_) => {
      dispatch(deleteProduct(id));
    });
  };
};

export const deleteProduct = (id) => {
  return {
    type: ActionTypes.DELETE_PRODUCT,
    payload: id,
  };
};
