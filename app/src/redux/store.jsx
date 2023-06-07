import { createStore, applyMiddleware } from 'redux';
import { logger } from 'redux-logger';
import reduxThunk from 'redux-thunk';
import rootReducer from './root-reducer'

const middlewares =[reduxThunk];
console.log("process", process.env.NODE_ENV);
process.env.NODE_ENV == "development"? middlewares.push(logger):void(0);

const store = createStore(rootReducer, applyMiddleware(...middlewares))

export default store;