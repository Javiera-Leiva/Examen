import React, { Component } from 'react';
import { variables } from './Variables.js';
import { tsConstructorType } from '@babel/types';

export class Categoria2 extends Component {

    constructor(props) {
        super(props);
        this.state = {
            categorias: [],
            modalTitle: "",
            CategoriaB: "",
            Id_CategoriaBebida: 0
        }
    }
    refreshList() {
        fetch(variables.API_URL+'ctbebida')
            .then(response=>response.json())
            .then(data => {
                this.setState({ categorias: data });
            });
    }
    componentDidMount() {
        this.refreshList();
    }
    changeCategoriaNombre = (e) => {
        this.setState({CategoriaB:e.target.value });
    }

    addClick() {
        this.setState({
            modalTitle: "Agregar Categoria",
            Id_CategoriaBebida: 0,
            Nombre: ""

        });
    }
    editClick(cat2) {
        this.setState({
            modalTitle: "Editar Categoria",
            Id_CategoriaBebida:cat2.Id_CategoriaBebida,
            CategoriaB:cat2.CategoriaB

        });
    }

    createClick() {
        fetch(variables.API_URL +'ctbebida', {
            method: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                CategoriaB:this.state.CategoriaB
            })
        })
            .then(res=>res.json())
            .then((result)=>{
                alert(result);
                this.refreshList();
            },(error)=>{
                alert('Failed');
            })
    }


    updateClick(id) {
        fetch(variables.API_URL +'ctbebida/'+id, {
            method:'PUT',
            headers: {
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body: JSON.stringify({
                Id_CategoriaBebida: this.state.Id_CategoriaBebida,
                CategoriaB:this.state.CategoriaB
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
        if (window.confirm('Deseas Eliminar?')) {
            fetch(variables.API_URL +'ctbebida/'+id, {
                method:'DELETE',
                headers: {
                    'Accept':'application/json',
                    'Content-Type':'application/json'
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
            categorias,
            modalTitle,
            Id_CategoriaBebida,
            CategoriaB
        } = this.state;
        return (
            <div>
                <button type="button"
                    className="btn btn-custom btn-lg btn-outline-dark m-1"
                    data-bs-toggle="modal"
                    data-bs-target="#exampleModal"
                    onClick={() => this.addClick()}>
                    Agregar Categoria
                </button>


                <table className="table table-dark">
                    <thead>
                        <tr>
                            <th>
                                CategoriaId
                            </th>
                            <th>
                                CategoriaNombre
                            </th>
                            <th>
                                Opciones
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {categorias.map(cat2=>
                            <tr key={cat2.Id_CategoriaBebida}>
                                <td>{cat2.Id_CategoriaBebida}</td>
                                <td>{cat2.CategoriaB}</td>
                                <td>
                                    <button type="button"
                                        className="btn btn-light btn-outline-primary m-1"
                                        data-bs-toggle="modal"
                                        data-bs-target="#exampleModal"
                                        onClick={() => this.editClick(cat2)}>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                            <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                        </svg>
                                    </button>
                                    <button type="button"
                                        className="btn btn-danger btn-outline-primary m-1"
                                        onClick={() => this.deleteClick(cat2.Id_CategoriaBebida)}>
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
                                <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div className="modal-body">
                                <div className="input-group mb-3">
                                    <spam className="input-group-text">CategoriaNombre</spam>
                                    <input type="text" className="form-control"
                                        value={CategoriaB}
                                        onChange={this.changeCategoriaNombre} />
                                </div>
                                {Id_CategoriaBebida == 0 ?
                                    <button type="button"
                                        className="btn btn-primary float-start"
                                        onClick={() => this.createClick()}
                                    >Crear</button>
                                    : null}

                                {Id_CategoriaBebida !==0?
                                    <button type="button"
                                        className="btn btn-primary float-start"
                                        onClick={() => this.updateClick(Id_CategoriaBebida)}
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