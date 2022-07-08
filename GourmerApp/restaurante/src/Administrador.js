import React, { Component } from 'react';
import { variables } from './Variables.js';


export class Administrador extends Component {

    constructor(props) {
        super(props);

        this.state = {
            administrador: [],
            modalTitle: "",
            Id_Admin: 0,
            Nombre: "",
            Correo:"",
            Contraseña:"",
            Telefono:"",
            Fecha_Registro: "",
        }
    }

    refreshList() {

        fetch(variables.API_URL + 'admin')
            .then(response => response.json())
            .then(data => {
                this.setState({ administrador: data });
            });

    }

    componentDidMount() {
        this.refreshList();
    }

    changeNombre = (e) => {
        this.setState({ Nombre: e.target.value });
    }
    changeCorreo = (e) => {
        this.setState({ Correo: e.target.value });
    }
    changeFecha_Registro = (e) => {
        this.setState({ Fecha_Registro: e.target.value });
    }
    changeContraseña= (e)=>{
        this.setState({Contraseña:e.target.value})
    }
    changeTelefono= (e)=>{
        this.setState({Telefono:e.target.value})
    }
    


    addClick() {
        this.setState({
            modalTitle: "Agregar Admin",
            Id_Admin: 0,
            Nombre: "",
            Correo:"",
            Fecha_Registro: "",
            Telefono:"",
            Contraseña:""
        });
    }
    editClick(A) {
        this.setState({
            modalTitle: "Editar Admin",
            Id_Admin:A.Id_Admin,
            Nombre:A.Nombre,
            Correo:A.Correo,
            Fecha_Registro:A.Fecha_Registro,
            Telefono:A.Telefono,
            Contraseña:A.Contraseña
        });
    }

    createClick() {
        fetch(variables.API_URL + 'admin', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Nombre: this.state.Nombre,
                Telefono:this.state.Telefono,
                Fecha_Registro: this.state.Fecha_Registro,
                Correo:this.state.Correo,
                Contraseña:this.state.Contraseña
            })
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
                this.refreshList();
            }, (error) => {
                alert('Failed');
            })
    }
    updateClick(id) {
        fetch(variables.API_URL + 'admin/' + id, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Id_Admin: this.state.Id_Admin,
                Nombre: this.state.Nombre,
                Contraseña: this.state.Contraseña,
                Correo:this.state.Correo,
                Telefono:this.state.Telefono

            })
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
                this.refreshList();
            }, (error) => {
                alert('Failed');
            })
    }

    deleteClick(id) {
        if (window.confirm('¿Estas seguro?')) {
            fetch(variables.API_URL + 'admin/' + id, {
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
           
            administrador,
            modalTitle,
            Id_Admin,
            Correo,
            Nombre,
            Telefono,
            Fecha_Registro,
            Contraseña,
            

        } = this.state;

        return (
            <div>

                <button type="button"
                    className="btn btn-custom btn-lg btn-outline-dark m-1"
                    data-bs-toggle="modal"
                    data-bs-target="#exampleModal"
                    onClick={() => this.addClick()}>
                    Agregar Administrador
                </button>
                <table className="table table-dark">
                    <thead>
                        <tr>
                            <th>
                                Id_Administrador
                            </th>
                            <th>
                                Nombre
                            </th>
                            <th>
                                Fecha de registro
                            </th>
                            <th>
                                Telefono
                            </th>
                            <th>
                                Correo
                            </th>
                            <th>
                                Contraseña
                            </th>
                           
                         
                            <th>
                                Opciones
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {administrador.map(A=>
                            <tr key={A.Id_Admin}>
                                <td>{A.Id_Admin}</td>
                                <td>{A.Nombre}</td>
                                <td>{A.Fecha_Registro}</td>
                                <td>{A.Telefono}</td>
                                <td>{A.Correo}</td>
                                <td>{A.Contraseña}</td>
                                <td>
                                    <button type="button"
                                        className="btn btn-light mr-1"
                                        data-bs-toggle="modal"
                                        data-bs-target="#exampleModal"
                                        onClick={() => this.editClick(A)}>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                            <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                        </svg>
                                    </button>

                                    <button type="button"
                                        className="btn btn-danger btn-outline-primary m-2"
                                        onClick={() => this.deleteClick(A.Id_Admin)}>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash-fill" viewBox="0 0 16 16">
                                            <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z" />
                                        </svg>
                                    </button>

                                </td>
                            </tr>
                        )}
                    </tbody>
                </table>

                <div className="modal fade" id="exampleModal" tabIndex="-1" aria-hidden="true">
                    <div className="modal-dialog modal-lg modal-dialog-centered">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title">{modalTitle}</h5>
                                <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"
                                ></button>
                            </div>

                            <div className="modal-body">
                                <div className="d-flex flex-row bd-highlight mb-3">

                                    <div className="p-2 w-50 bd-highlight">

                                        <div className="input-group mb-3">
                                            <span className="input-group-text">Nombre</span>
                                            <input type="text" className="form-control"
                                                value={Nombre}
                                                onChange={this.changeNombre} />
                                        </div>

                                        <div className="input-group mb-3">
                                            <span className="input-group-text">Fecha</span>
                                            <input type="date" className="form-control"
                                                value={Fecha_Registro}
                                                onChange={this.changeFecha_Registro} />
                                        </div>
                                        <div className="input-group mb-3">
                                            <span className="input-group-text">Telefono</span>
                                            <input type="text" className="form-control"
                                                value={Telefono}
                                                onChange={this.changeTelefono} />
                                        </div>
                                        <div className="input-group mb-3">
                                            <span className="input-group-text">Contraseña</span>
                                            <input type="text" className="form-control"
                                                value={Contraseña}
                                                onChange={this.changeContraseña} />
                                        </div>
                                        <div className="input-group mb-3">
                                            <span className="input-group-text">Correo</span>
                                            <input type="text" className="form-control"
                                                value={Correo}
                                                onChange={this.changeCorreo} />
                                        </div>
                                        

                                    </div>
                                </div>

                                {Id_Admin === 0 ?
                                    <button type="button"
                                        className="btn btn-primary float-start"
                                        onClick={() => this.createClick()}
                                    >Crear</button>
                                    : null}

                                {Id_Admin !== 0 ?
                                    <button type="button"
                                        className="btn btn-primary float-start"
                                        onClick={() => this.updateClick(Id_Admin)}
                                    >Actualizar</button>
                                    : null}
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        )
    }
}