import { DeleteProduct } from "../../api/product_api";
import { ActionTypes } from "../constants/action_types";
const initialProductState = {
  productList: [],
  selectedProduct: {},
};
const productReducer = (state = initialProductState, { type, payload }) => {
  switch (type) {
    case ActionTypes.SET_PRODUCTS: {
      return { ...state, productList: payload };
    }
    case ActionTypes.UPDATE_PRODUCT: {
      let newProducts = state.productList.map((prod) =>
        prod.productId === payload.productId ? payload : prod
      );
      return { ...state, productList: newProducts };
    }
    case ActionTypes.DELETE_PRODUCT: {
      let newProducts = state.productList.filter(
        (prod) => prod.productId !== payload
      );
      return { ...state, productList: newProducts };
    }
    case ActionTypes.ADD_NEW_PRODUCT: {
      return { ...state, productList: [...state.productList, payload] };
    }
    case ActionTypes.SET_SELECTED_PRODUCT: {
      return { ...state, selectedProduct: payload };
    }
    case ActionTypes.SORT_PRODUCTS_BY_NAME: {
      if (payload.sort === "asc") {
        return {
          ...state,
          productList: [...state.productList].sort(
            (a, b) => a.productPrice - b.productPrice
          ),
        };
      } else {
        return {
          ...state,
          productList: [...state.productList].sort(
            (a, b) => b.productPrice - a.productPrice
          ),
        };
      }
    }
    case ActionTypes.SORT_PRODUCTS_BY_CATEGORY: {
      if (payload.cate === "asc") {
        return {
          ...state,
          productList: [...state.productList].sort((a, b) =>
            a.category.categoryName.localeCompare(b.category.categoryName)
          ),
        };
      } else {
        return {
          ...state,
          productList: [...state.productList].sort((a, b) =>
            b.category.categoryName.localeCompare(a.category.categoryName)
          ),
        };
      }
    }
    case ActionTypes.CLEAR_SELECTED_PRODUCT: {
      return { ...state, selectedProduct: {} };
    }
    default:
      return state;
  }
};

export default productReducer;
