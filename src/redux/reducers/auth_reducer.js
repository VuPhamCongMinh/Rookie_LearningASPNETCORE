import { ActionTypes } from "../constants/action_types";
const initialUserState = {
  user: null,
  isLoadingUser: false,
};
const authReducer = (state = initialUserState, { type, payload }) => {
  switch (type) {
    case ActionTypes.STORE_USER:
      return {
        ...state,
        isLoadingUser: false,
        user: payload,
      };
    case ActionTypes.LOADING_USER:
      return {
        ...state,
        isLoadingUser: true,
      };
    case ActionTypes.USER_EXPIRED:
    case ActionTypes.STORE_USER_ERROR:
    case ActionTypes.USER_SIGNED_OUT:
      return {
        ...state,
        user: null,
        isLoadingUser: false,
      };
    default:
      return state;
  }
};

export default authReducer;
