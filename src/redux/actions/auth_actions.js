import { ActionTypes } from "../constants/action_types";
import { setAuthHeader } from "../../utils/axios_util";

export function storeUser(user) {
  setAuthHeader(user.access_token);
  return {
    type: ActionTypes.STORE_USER,
    payload: user,
  };
}

export function clearUser() {
  setAuthHeader(null);
  return {
    type: ActionTypes.CLEAR_USER,
  };
}
