import axios from "axios";

export function setAuthHeader(token) {
  // console.log(token);
  axios.defaults.headers.common["Authorization"] = token
    ? "Bearer " + token
    : "";
}
