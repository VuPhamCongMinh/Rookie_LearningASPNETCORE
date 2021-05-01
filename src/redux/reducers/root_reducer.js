import { combineReducers } from "redux";
import accountSlice from "../slices/account_slice";
import paginationSlice from "../slices/pagination_slice";
import authReducer from "./auth_reducer";
import categoryReducer from "./category_reducer";
import productReducer from "./product_reducer";

const rootReducer = combineReducers({
  product: productReducer,
  category: categoryReducer,
  auth: authReducer,
  account: accountSlice,
  pagination: paginationSlice,
});

export default rootReducer;
