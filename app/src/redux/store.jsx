import { createStore, applyMiddleware } from 'redux';
import { logger } from 'redux-logger';
import reduxThunk from 'redux-thunk';
import rootReducer from './root-reducer'

const middlewares =[reduxThunk];
process.env.NODE_ENV == "develoment"? middlewares.push(logger):void(0);

const store = createStore(rootReducer, applyMiddleware(...middlewares))

export default store;