import axios from "axios";
import { GetCategories } from "../../api/category_api";
import { GetProducts } from "../../api/product_api";
import { setCategories } from "./category_actions";
import { setProducts } from "./product_actions";

export const fetchInitialDatas = () => {
  return (dispatch) => {
    axios.all([GetCategories(), GetProducts()]).then(
      axios.spread((cateRes, prodRes) => {
        dispatch(setCategories(cateRes.data));
        dispatch(setProducts(prodRes.data));
      })
    );
  };
};
