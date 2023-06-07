import React, { useEffect } from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import { useDispatch, useSelector } from 'react-redux'
import { loadPermissions } from '../redux/actions';
import { Button, ButtonGroup } from '@material-ui/core';
import { useNavigate } from 'react-router-dom'

const Home = () => {
    const navigate = useNavigate();
    let dispatch = useDispatch();
    const { permissions } = useSelector(state=> state.data ) 
    useEffect(()=>{
      dispatch(loadPermissions())
    }, []);
    return (
        <div>
            <div>
              <Button variant="contained" color="primary" onClick={()=>navigate("/new")}>Nuevo Permiso</Button>
            </div>
            
            <TableContainer>
              <Table>
                <TableHead>
                  <TableRow>
                    <TableCell>Nombre</TableCell>
                    <TableCell align="center">Apellido</TableCell>
                    <TableCell align="center">Tipo</TableCell>
                    <TableCell align="center">Fecha</TableCell>
                    <TableCell align="center">Editar</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {permissions  && permissions.map((r) => (
                    <TableRow key={ r.id }>
                      <TableCell >{r.nombreEmpleado}</TableCell>
                      <TableCell align="center">{r.apellidoEmpleado}</TableCell>
                      <TableCell align="center">{r.tipoPermisoDescripcion}</TableCell>
                      <TableCell align="center">{r.fechaPermiso}</TableCell>
                      <TableCell align="center" >
                        <ButtonGroup>
                          <Button color="primary" onClick={()=> navigate(`/edit/${r.id}`) }>Editar</Button>
                        </ButtonGroup>
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
        </div>
    )
}

export default Home