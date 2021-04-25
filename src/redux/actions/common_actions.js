import axios from "axios";
import { GetUsers } from "../../api/account_api";
import { GetCategories } from "../../api/category_api";
import { GetProducts } from "../../api/product_api";
import { setCategories } from "./category_actions";
import { setProducts } from "./product_actions";
import { setUsers } from "../slices/account_slice";

export const fetchInitialDatas = () => {
  return (dispatch) => {
    axios.all([GetCategories(), GetProducts(), GetUsers()]).then(
      axios.spread((cateRes, prodRes, userRes) => {
        dispatch(setCategories(cateRes.data));
        dispatch(setProducts(prodRes.data));
        dispatch(setUsers(userRes.data));
      })
    );
  };
};
