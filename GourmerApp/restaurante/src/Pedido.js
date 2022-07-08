import React, { Component } from 'react';
import { variables } from './Variables.js';


export class Pedido extends Component {

    constructor(props) {
        super(props);

        this.state = {
            Pedido: [],
            modalTitle: "",
            Id_Pedido: 0,
            Subtotal:0,
            Fecha_Venta:0,
            Id_Usuario:0,
            Id_Bebida:0,
            Cantidad_Bebidas:0,
            Id_Plato:0,
            Cantidad_Platos: 0,
            

        }
    }

    refreshList() {

        fetch(variables.API_URL+'pedidov')
            .then(response => response.json())
            .then(data => {
                this.setState({ Pedido: data });
            });

    }
    componentDidMount() {
        this.refreshList();
    }

    deleteClick(id) {
        if (window.confirm('¿Estas seguro?')) {
            fetch(variables.API_URL+'pedidov/'+ id, {
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
            Pedido,
            Id_Pedido,
            Subtotal,
            Fecha_Venta,
            Id_Usuario,
            Id_Bebida,
            Cantidad_Bebidas,
            Id_Plato,
            Cantidad_Platos,

        } = this.state;

        return (
            <div>
                <table className="table table-dark">
                    <thead>
                        <tr>
                            <th>
                                Id_Pedido
                            </th>
                            <th>
                                Id_Plato
                            </th>
                            
                            <th>
                                Cantidad de platos
                            </th>
                            <th>
                                Id_Bebida
                            </th>
                                                     
                            <th>
                                Cantidad de Bebidas
                            </th>
                            <th>
                                Id_Usuario
                            </th>
                            <th>
                                Subtotal
                            </th>
                            <th>
                                Fecha_Venta
                            </th>

                            <th>
                                Opciones
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {Pedido.map(pei =>
                            <tr key={pei.Id_Pedido}>
                                <td>{pei.Id_Pedido}</td>
                                <td>{pei.Id_Plato}</td>
                                <td>{pei.Cantidad_Bebidas}</td>
                                <td>{pei.Id_Bebida}</td>
                                <td>{pei.Cantidad_Platos}</td>
                                <td>{pei.Id_Usuario}</td>
                                <td>{pei.Subtotal}</td>
                                <td>{pei.Fecha_Venta}</td>
                                <td>

                                    <button type="button"
                                        className="btn btn-danger btn-outline-primary m-2"
                                        onClick={() => this.deleteClick(pei.Id_Pedido,Id_Plato,Id_Pedido,Id_Bebida,Subtotal,Fecha_Venta,Id_Usuario,Cantidad_Platos,Cantidad_Bebidas)}>
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