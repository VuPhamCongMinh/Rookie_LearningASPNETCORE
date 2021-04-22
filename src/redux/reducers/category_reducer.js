import { ActionTypes } from "../constants/action_types";
const initialCategoryState = {
  categoryList: [],
  selectedCategory: {},
};
const categoryReducer = (state = initialCategoryState, { type, payload }) => {
  switch (type) {
    case ActionTypes.SET_CATEGORIES: {
      return { ...state, categoryList: payload };
    }
    case ActionTypes.ADD_NEW_CATEGORY: {
      return { ...state, categoryList: [...state.categoryList, payload] };
    }
    case ActionTypes.UPDATE_CATEGORY: {
      let newCategories = state.categoryList.map((cate) =>
        cate.categoryId === payload.categoryId ? payload : cate
      );
      return { ...state, categoryList: newCategories };
    }
    case ActionTypes.DELETE_CATEGORY: {
      let newCategories = state.categoryList.filter(
        (cate) => cate.categoryId !== payload
      );
      return { ...state, categoryList: newCategories };
    }
    case ActionTypes.SET_SELECTED_CATEGORY: {
      return { ...state, selectedCategory: payload };
    }
    case ActionTypes.CLEAR_SELECTED_CATEGORY: {
      return { ...state, selectedCategory: {} };
    }
    default:
      return state;
  }
};

export default categoryReducer;
