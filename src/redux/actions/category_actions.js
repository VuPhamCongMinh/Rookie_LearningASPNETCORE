import { ActionTypes } from "../constants/action_types";

export const addNewCategory = (category) => {
  return {
    type: ActionTypes.ADD_NEW_CATEGORY,
    payload: category,
  };
};

export const updateCategory = (category) => {
  return {
    type: ActionTypes.UPDATE_CATEGORY,
    payload: category,
  };
};

export const setCategories = (categoryList) => {
  return {
    type: ActionTypes.SET_CATEGORIES,
    payload: categoryList,
  };
};

export const setSelectedCategory = (category) => {
  return {
    type: ActionTypes.SET_SELECTED_CATEGORY,
    payload: category,
  };
};
