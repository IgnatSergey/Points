import { legacy_createStore, combineReducers, applyMiddleware } from "redux";
import thunkMiddleware from "redux-thunk";
import { appReducer } from "./app-reducer";
import { pointReducer } from "./point-reducer";

let reducers = combineReducers({
  app: appReducer,
  point: pointReducer,
});

let store = legacy_createStore(reducers, applyMiddleware(thunkMiddleware));

export type RootState = ReturnType<typeof store.getState>

export { store };
