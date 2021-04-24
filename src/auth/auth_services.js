import Oidc from "oidc-client";
import { storeUser } from "../redux/actions/auth_actions";

const oidcSettings = {
  authority: "https://localhost:44348",
  client_id: "react",
  redirect_uri: "http://localhost:3000/signin-oidc",
  post_logout_redirect_uri: "http://localhost:3000/singout-oidc",
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
