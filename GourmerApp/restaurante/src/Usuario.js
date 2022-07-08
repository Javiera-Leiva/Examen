import React, { Component } from 'react';
import { variables } from './Variables.js';


export class Usuario extends Component {

    constructor(props) {
        super(props);

        this.state = {
        Usuario:[],
        Id_Usuario:"",
        modalTitle: "",
        Nombre:"",
        Correo:"",
        Contraseña:"", 
        Telefono:"",
        Fecha_Registro:"", 
            

        }
    }

    refreshList() {

        fetch(variables.API_URL+'usuario')
            .then(response => response.json())
            .then(data => {
                this.setState({ Usuario: data });
            });

    }
    componentDidMount() {
        this.refreshList();
    }

    deleteClick(id) {
        if (window.confirm('¿Estas seguro?')) {
            fetch(variables.API_URL+'usuario/'+ id, {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
                .then(res => res.json())
                .then((result) => {
                    alert(result);
                    this.refreshList();
                }, (error) => {
                    alert('Failed');
                })
        }
    }



    render() {
        const {
            Usuario,
            Id_Usuario,
            modalTitle,
            Nombre,
            Correo,
            Contraseña, 
            Telefono,
            Fecha_Registro, 
        } = this.state;

        return (
            <div>
                <table className="table table-dark">
                    <thead>
                        <tr>
                            <th>
                                Id_Usuario
                            </th>
                            <th>
                                Nombre
                            </th>
                            
                            <th>
                                Correo
                            </th>
                            <th>
                                Contraseña
                            </th>
                                                     
                            <th>
                                Telefono
                            </th>
                            <th>
                                Fecha_Registro
                            </th>
                            <th>
                                Opciones
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {Usuario.map(U =>
                            <tr key={U.Id_Usuario}>
                                <td>{U.Id_Usuario}</td>
                                <td>{U.Nombre}</td>
                                <td>{U.Correo}</td>
                                <td>{U.Contraseña}</td>
                                <td>{U.Telefono}</td>
                                <td>{U.Fecha_Registro}</td>
                                <td>

                                    <button type="button"
                                        className="btn btn-danger btn-outline-primary m-2"
                                        onClick={() => this.deleteClick(U.Id_Usuario,Nombre,Correo,Contraseña,Fecha_Registro)}>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash-fill" viewBox="0 0 16 16">
                                            <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z" />
                                        </svg>
                                    </button>

                                </td>
                            </tr>
                        )}
                    </tbody>
                </table>

            </div>
        )
    }
}