import { applyMiddleware, createStore } from "redux";
import ReduxThunk from "redux-thunk";
import rootReducer from "./reducers/root_reducer";

const store = createStore(rootReducer, applyMiddleware(ReduxThunk));
export default store;
