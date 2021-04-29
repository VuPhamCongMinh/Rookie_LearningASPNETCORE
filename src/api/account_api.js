import axios from "axios";

const account_url = process.env.REACT_APP_ACCOUNT_API;

export const GetUsers = () => {
  return axios.get(account_url);
};
