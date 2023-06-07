import { combineReducers } from 'redux'
import permissionsReducers from './reducer'

const rootReducer = combineReducers({
    data: permissionsReducers 
})

export default rootReducer;