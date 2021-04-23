import { combineReducers } from "redux";
import authReducer from "./auth_reducer";
import categoryReducer from "./category_reducer";
import productReducer from "./product_reducer";

const rootReducer = combineReducers({
  product: productReducer,
  category: categoryReducer,
  auth: authReducer,
});

export default rootReducer;
