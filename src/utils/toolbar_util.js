import {
  sortProductsByCategory,
  sortProductsByPrice,
} from "../redux/actions/product_actions";
import store from "../redux/store";

export const SortPrice = (sortOption, setSortOption) => {
  store.dispatch(sortProductsByPrice(sortOption));
  if (sortOption.sort === "asc") {
    setSortOption({ ...sortOption, sort: "desc" });
  } else {
    setSortOption({ ...sortOption, sort: "asc" });
  }
};

export const SortCate = (sortOption, setSortOption) => {
  store.dispatch(sortProductsByCategory(sortOption));
  if (sortOption.cate === "asc") {
    setSortOption({ ...sortOption, cate: "desc" });
  } else {
    setSortOption({ ...sortOption, cate: "asc" });
  }
};
