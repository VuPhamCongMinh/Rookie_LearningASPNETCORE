import axios from "axios";

const account_url = "https://localhost:44348/api/accounts";

export const GetUsers = () => {
  return axios.get(account_url);
};
