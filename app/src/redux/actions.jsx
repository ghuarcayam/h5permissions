import * as types from './actionType'
import axios from 'axios';

const getPermissions =(permissions)=> ({
    type:types.GET_PERMISSIONS,
    payload: permissions
});
const getSinglePermission =(permission)=> ({
    type:types.GET_SINGLE_PERMISSION,
    payload: permission
});

const permissionAdded =()=> ({
    type:types.ADD_PERMISSIONS
});

const permissionEdited =()=> ({
    type:types.EDIT_PERMISSION
});

const getPermissionTypes = (_types)=>({
    type: types.GET_PERMISSIONTYPES,
    payload: _types
})
export const loadPermissionTypes = ()=>{
    return  function(dispatch){
        axios
        .get(`https://localhost:44312/permission/types`)
        .then((response)=>{
            console.log('response', response)
            dispatch(getPermissionTypes(response.data.items));
        })
        .catch(error=>{
            console.log(error)
        });
    }
}
export const loadPermissions = ()=>{
    return  function(dispatch){
        axios
        .get(`https://localhost:44312/permission?startAt=1&pageSize=100`)
        .then((response)=>{
            console.log('response', response)
            dispatch(getPermissions(response.data.items));
        })
        .catch(error=>{
            console.log(error)
        });

    }
}

export const loadSinglePermission = (id)=>{
    return  function(dispatch){
        axios
        .get(`https://localhost:44312/permission/${id}`)
        .then((response)=>{
            console.log('response', response)
            dispatch(getSinglePermission(response.data));
        })
        .catch(error=>{
            console.log(error)
        });

    }
}

export const addPermission = (permission)=>{
    
    return function (dispatch){
        axios.post(`https://localhost:44312/permission`, permission)
        .then((response)=>{
            dispatch(permissionAdded())
            dispatch(loadPermissions())
        })
    }
}

export const editPermission = (id,permission)=>{
    
    return function (dispatch){
        axios.patch(`https://localhost:44312/permission/${id}`, permission)
        .then((response)=>{
            dispatch(permissionEdited())
            dispatch(loadPermissions())
        })
    }
}