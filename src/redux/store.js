import { applyMiddleware, createStore } from "redux";
import ReduxThunk from "redux-thunk";
import { fetchInitialDatas } from "./actions/common_actions";
import rootReducer from "./reducers/root_reducer";

const store = createStore(rootReducer, applyMiddleware(ReduxThunk));
store.dispatch(fetchInitialDatas());
export default store;
