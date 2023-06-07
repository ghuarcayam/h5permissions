import React, { useState, useEffect  } from 'react'
import { makeStyles } from '@material-ui/core/styles'
import TextField from '@material-ui/core/TextField'
import Select from '@material-ui/core/Select'
import Checkbox from '@material-ui/core/Checkbox'
import MenuItem from '@material-ui/core/MenuItem'
import Button from '@material-ui/core/Button'
import FormControlLabel from '@material-ui/core/FormControlLabel'
import { useNavigate, useParams } from 'react-router-dom'
import { useDispatch, useSelector } from 'react-redux'
import { editPermission, loadPermissionTypes, loadSinglePermission } from '../redux/actions'


const useStyles = makeStyles((theme)=>({
    root:{
        "& > *":{
            margin: theme.spacing(1),
            width:"45ch"
        }
    }
}))

const EditPermission =()=> {
    const {id} = useParams()
    const navigate = useNavigate()
    const dispatch = useDispatch();
    const classes = useStyles()
    const [state, setState] = useState({
        nombreEmpleado:"",
        apellidoEmpleado:"",
        fechaPermiso:new Date(),
        idTipoPermiso:0,
        descripcionTipoPermiso:""
    })

    const [error, setError] = useState("");

    const { nombreEmpleado, apellidoEmpleado, fechaPermiso, idTipoPermiso, descripcionTipoPermiso } = state

    const handlerChange = (e)=>{
        
        let { name, value } = e.target;
        setState({...state, [name]: value})
    }

    const handlerSubmit = (e)=>{
        e.preventDefault()
        dispatch(editPermission(id,state))
        navigate("/")
    }


    const { types, permission } = useSelector(state=> state.data ) 
    useEffect(()=>{
      dispatch(loadPermissionTypes())
      dispatch(loadSinglePermission(id))
    }, []);

    useEffect(()=>{
        
        if (permission){
            if (permission.fechaPermiso){
                const dateObj = new Date(permission.fechaPermiso);
            
                const month = ("0" + (dateObj.getMonth() + 1)).slice(-2);
                const day = ("0" + dateObj.getDate()).slice(-2);
                const year = dateObj.getFullYear();

                permission.fechaPermiso = `${year}-${month}-${day}`;
            }
            
            setState(permission);
        }
    }, [permission] )

    const [checked, setChecked] = useState(false);

    const handleChange = (event) => {
        setChecked(event.target.checked);
        setState({...state, idTipoPermiso: 0, descripcionTipoPermiso:"" })
    };

    return(
        <div style={{margin:25}}>
            <Button style={{width:"100px"}} variant="contained" color="secondary" type="button"
                    onClick={()=>navigate("/")}   >Home</Button>
            <h2> Editar Permiso</h2>
            <form className={classes.root} onSubmit={handlerSubmit}>
                <TextField label="Nombre" name="nombreEmpleado" onChange={handlerChange} value={nombreEmpleado} type="text"></TextField><br />
                <TextField label="Apellido" name="apellidoEmpleado" onChange={handlerChange} value={apellidoEmpleado} type="text">Apellido</TextField><br />
                <TextField label="Fecha" name="fechaPermiso" onChange={handlerChange} value={fechaPermiso} type="date">Fecha</TextField><br />
                <FormControlLabel control={<Checkbox label="Agregar Tipo" checked={checked} onChange={handleChange}/>} label="Agregar tipo de permiso"><br />

                </FormControlLabel>
                <br />
                {
                    !checked &&
                    (<Select placeholder='Tipo' name="idTipoPermiso" onChange={handlerChange} label="Tipo" value={idTipoPermiso}>
      
                {types.map((type)=>(
                    <MenuItem
                        key={type.id}
                        value={type.id}
                    >
                        {type.descripcion}
                    </MenuItem>
                ))}
                    </Select>)
                }
                {   checked &&
                    (<TextField label="Tipo Servicio" name="descripcionTipoPermiso" onChange={handlerChange} value={descripcionTipoPermiso} type="text"></TextField>)
                }
                <br />
                <Button style={{width:"100px"}} variant="contained" color="primary" type="submit" >Guardar Permiso</Button>
            </form>
        </div>
    )
}
export default EditPermission