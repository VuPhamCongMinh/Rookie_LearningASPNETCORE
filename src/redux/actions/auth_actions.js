import { ActionTypes } from "../constants/action_types";
import { setAuthHeader } from "../../utils/axios_util";

export function storeUser(user) {
  setAuthHeader(user.access_token);
  return {
    type: ActionTypes.STORE_USER,
    payload: user,
  };
}

export function loadingUser() {
  return {
    type: ActionTypes.LOADING_USER,
  };
}

export function storeUserError() {
  return {
    type: ActionTypes.STORE_USER_ERROR,
  };
}

export function userExpired() {
  return {
    type: ActionTypes.USER_EXPIRED,
  };
}

export function userSignedOut() {
  return {
    type: ActionTypes.USER_SIGNED_OUT,
  };
}
