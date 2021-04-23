import { DeleteCategory } from "../../api/category_api";
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

export const clearSelectedCategory = () => {
  return {
    type: ActionTypes.CLEAR_SELECTED_CATEGORY,
  };
};

export const deleteCategoryRequest = (id) => {
  return (dispatch) => {
    DeleteCategory(id).then((res) => {
      res === true && dispatch(deleteCategory(id));
    });
  };
};

export const deleteCategory = (id) => {
  return {
    type: ActionTypes.DELETE_CATEGORY,
    payload: id,
  };
};
