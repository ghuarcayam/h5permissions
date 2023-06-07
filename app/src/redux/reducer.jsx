import * as types from './actionType'

const initialState = {
    permissions:[],
    permission:{},
    types:[],
    loading: true
}

const permissionsReducers = (state = initialState, action) =>{
    
    switch (action.type){
        case types.GET_PERMISSIONS:
            return {
                ...state,
                permissions: action.payload,
                loading:false
            }
        case types.ADD_PERMISSIONS:
            return{
                ...state,
                loading:false
            }
        case types.EDIT_PERMISSION:
            return{
                ...state,
                loading:false
            }
        case types.GET_PERMISSIONTYPES:
            return{
                ...state,
                types:action.payload,
                loading:false
            }
        case types.GET_SINGLE_PERMISSION:
            return{
                ...state,
                permission:action.payload,
                loading:false
            }
        default:
            return state
    }
        
}

export default permissionsReducers;