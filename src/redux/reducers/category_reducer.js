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
      return [...state.categoryList, payload];
    }
    case ActionTypes.UPDATE_CATEGORY: {
      return [...state.categoryList, payload];
    }
    case ActionTypes.SET_SELECTED_CATEGORY: {
      return { ...state, selectedCategory: payload };
    }
    default:
      return state;
  }
};

export default categoryReducer;
