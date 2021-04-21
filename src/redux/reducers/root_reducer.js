import { combineReducers } from "redux";
import categoryReducer from "./category_reducer";
import productReducer from "./product_reducer";

const rootReducer = combineReducers({
  product: productReducer,
  category: categoryReducer,
});

export default rootReducer;
