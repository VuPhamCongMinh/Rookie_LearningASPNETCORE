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
    default:
      return state;
  }
};

export default productReducer;
