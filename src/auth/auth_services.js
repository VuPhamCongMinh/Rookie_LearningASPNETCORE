import Oidc from "oidc-client";
import { storeUser } from "../redux/actions/auth_actions";

const oidcSettings = {
  authority: process.env.REACT_APP_BACKEND_URL,
  client_id: "react",
  redirect_uri: process.env.REACT_APP_CLIENT_SIGNIN_URL,
  post_logout_redirect_uri: process.env.REACT_APP_CLIENT_SIGNOUT_URL,
  response_type: "id_token token",
  scope: "product.api openid profile",
};

const userManager = new Oidc.UserManager(oidcSettings);

export async function loadUserFromStorage(store) {
  try {
    let user = await userManager.getUser();
    if (user) {
      store.dispatch(storeUser(user));
    }
  } catch (e) {
    console.error(`User not found: ${e}`);
  }
}

export function signinRedirect() {
  return userManager.signinRedirect();
}

export function signinRedirectCallback() {
  return userManager.signinRedirectCallback();
}

export function signoutRedirect() {
  userManager.clearStaleState();
  userManager.removeUser();
  return userManager.signoutRedirect();
}

export function signoutRedirectCallback() {
  userManager.clearStaleState();
  userManager.removeUser();
  return userManager.signoutRedirectCallback();
}

export default userManager;
