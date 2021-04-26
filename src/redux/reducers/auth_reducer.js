import { ActionTypes } from "../constants/action_types";
const initialUserState = {
  user: null,
};
const authReducer = (state = initialUserState, { type, payload }) => {
  switch (type) {
    case ActionTypes.STORE_USER:
      return {
        ...state,
        user: payload,
      };
    case ActionTypes.CLEAR_USER:
      return {
        ...state,
        user: null,
      };
    default:
      return state;
  }
};

export default authReducer;
