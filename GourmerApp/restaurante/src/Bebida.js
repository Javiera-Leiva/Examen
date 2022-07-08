import React, { Component } from 'react';
import { variables } from './Variables.js';


export class Bebida extends Component {

    constructor(props) {
        super(props);

        this.state = {
            bebidas: [],
            modalTitle: "",
            Id_Bebida: 0,
            Nombre: "",
            Precio:"",
            Id_CategoriaBebida:0,
            Fecha_Registro: "",
        }
    }

    refreshList() {

        fetch(variables.API_URL + 'bebida')
            .then(response => response.json())
            .then(data => {
                this.setState({ bebidas: data });
            });

    }

    componentDidMount() {
        this.refreshList();
    }

    changeNombre = (e) => {
        this.setState({ NombreB: e.target.value });
    }
    changeCategoria = (e) => {
        this.setState({ Id_CategoriaBebida: e.target.value });
    }
    changeFecha_Registro = (e) => {
        this.setState({ Fecha_Registro: e.target.value });
    }
    changePrecio= (e)=>{
        this.setState({Precio:e.target.value})
    }

    addClick() {
        this.setState({
            modalTitle: "Agregar Producto",
            Id_Bebida: 0,
            NombreB: "",
            Id_CategoriaBebida:"",
            Fecha_Registro: "",
            Precio:"",
        });
    }
    editClick(b) {
        this.setState({
            modalTitle: "Editar Producto",
            Id_Bebida:b.Id_Bebida,
            NombreB:b.NombreB,
            Id_CategoriaBebida:b.Id_CategoriaBebida,
            Fecha_Registro:b.Fecha_Registro,
            Precio:b.Precio,
        });
    }

    createClick() {
        fetch(variables.API_URL + 'bebida', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                NombreB: this.state.NombreB,
                Id_CategoriaBebida:this.state.Id_CategoriaBebida,
                Fecha_Registro: this.state.Fecha_Registro,
                Precio:this.state.Precio,
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
        fetch(variables.API_URL + 'bebida/' + id, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Id_Bebida: this.state.Id_Bebida,
                NombreB: this.state.NombreB,
                Id_CategoriaBebida: this.state.Id_CategoriaBebida,
                Precio: this.state.Precio,
                Fecha_Registro:this.state.Fecha_Registro,
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
            fetch(variables.API_URL + 'bebida/' + id, {
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
            bebidas,
            modalTitle,
            Id_Bebida,
            NombreB,
            Precio,
            Id_CategoriaBebida,
            Fecha_Registro,
        } = this.state;

        return (
            <div>

                <button type="button"
                    className="btn btn-custom btn-lg btn-outline-dark m-1"
                    data-bs-toggle="modal"
                    data-bs-target="#exampleModal"
                    onClick={() => this.addClick()}>
                    Agregar Producto
                </button>
                <table className="table table-dark">
                    <thead>
                        <tr>
                            <th>
                                Id_Bebida
                            </th>
                            <th>
                                Nombre
                            </th>
                            <th>
                                Categoria
                            </th>
                            <th>
                                Fecha
                            </th>
                            <th>
                                Precio
                            </th>
                            <th>
                                Opciones
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {bebidas.map(b =>
                            <tr key={b.Id_Bebida}>
                                <td>{b.Id_Bebida}</td>
                                <td>{b.NombreB}</td>
                                <td>{b.Id_CategoriaBebida}</td>
                                <td>{b.Fecha_Registro}</td>
                                <td>{b.Precio}</td>
                                <td>
                                    <button type="button"
                                        className="btn btn-light mr-1"
                                        data-bs-toggle="modal"
                                        data-bs-target="#exampleModal"
                                        onClick={() => this.editClick(b)}>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                            <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                        </svg>
                                    </button>

                                    <button type="button"
                                        className="btn btn-danger btn-outline-primary m-2"
                                        onClick={() => this.deleteClick(b.Id_Bebida)}>
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
                                                value={NombreB}
                                                onChange={this.changeNombre} />
                                        </div>

                                        <div className="input-group mb-3">
                                            <span className="input-group-text">Fecha</span>
                                            <input type="date" className="form-control"
                                                value={Fecha_Registro}
                                                onChange={this.changeFecha_Registro} />
                                        </div>
                                        <div className="input-group mb-3">
                                            <span className="input-group-text">Precio</span>
                                            <input type="text" className="form-control"
                                                value={Precio}
                                                onChange={this.changePrecio} />
                                        </div>
                                        <div className="input-group mb-3">
                                            <span className="input-group-text">Categoria</span>
                                            <input type="text" className="form-control"
                                                value={Id_CategoriaBebida}
                                                onChange={this.changeCategoria} />
                                        </div>                

                                    </div>
                                </div>

                                {Id_Bebida === 0 ?
                                    <button type="button"
                                        className="btn btn-primary float-start"
                                        onClick={() => this.createClick()}
                                    >Crear</button>
                                    : null}

                                {Id_Bebida !== 0 ?
                                    <button type="button"
                                        className="btn btn-primary float-start"
                                        onClick={() => this.updateClick(Id_Bebida)}
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