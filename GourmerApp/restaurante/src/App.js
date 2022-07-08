import './App.css';
import {Home} from './Home';
import {Categoria} from './Categoria';
import {Plato} from './Plato';
import {Bebida} from './Bebida';
import { Categoria2 } from './Categoria2';
import { Pedido } from './Pedido';
import { Usuario } from './Usuario';
import { Administrador } from './Administrador';


import {BrowserRouter, Route, Routes,NavLink} from 'react-router-dom';


function App() {
  return (
   <BrowserRouter>
  
    <div className="App container">
         <header id="header">
        
  <div class="intro">
    <div class="overlay">
      <div class="container">
        <div class="row">
          <div class="intro-text">
            <h1>El sabor que Siempre alegra tu paladar</h1>
           </div>
        </div>
      </div>
    </div>
  </div>
</header> 

     <nav className="navbar navbar-dark bg-dark m-3 d-flex justify-content-center navbar navbar-default navbar-fixed-top">
     <img class="Logo" src="ElBojazo.png"/>
      <ul className="navbar-nav">
        <li className="nav-item- m-1">
          <NavLink className="btn btn-custom btn-lg btn-outline-dark m-1" to="/Home">
            Home
          </NavLink>
          <NavLink className="btn btn-custom btn-lg btn-outline-dark m-1" to="/categoria">
            CategoriaPlatos
          </NavLink>
          <NavLink className="btn btn-custom btn-lg btn-outline-dark m-1" to="/plato">
            plato
          </NavLink>
          <NavLink className="btn btn-custom btn-lg btn-outline-dark m-1" to="/categoria2">
            CategoriaBebida
          </NavLink>
          <NavLink className="btn btn-custom btn-lg btn-outline-dark m-1" to="/bebida">
            Bebida
          </NavLink>
          <NavLink className="btn btn-custom btn-lg btn-outline-dark m-1" to="/pedido">
            Pedidos
          </NavLink>
          <NavLink className="btn btn-custom btn-lg btn-outline-dark m-1" to="/usuarios">
            Usuarios
          </NavLink>
          <NavLink className="btn btn-custom btn-lg btn-outline-dark m-1" to="/administrador">
            Administrador
          </NavLink>
         

        </li>
      </ul>
     </nav>

     <Routes>
      <Route path='/home' element={<Home/>}/>
      <Route path='/categoria' element={<Categoria/>}/>
      <Route path='/plato' element={<Plato/>}/>
      <Route path='/categoria2' element={<Categoria2/>}/>
      <Route path='/bebida' element={<Bebida/>}/>
      <Route path='/pedido' element={<Pedido/>}/>
      <Route path='/usuarios' element={<Usuario/>}/>
      <Route path='/administrador' element={<Administrador/>}/>

     </Routes>
    </div>
    </BrowserRouter> 
   
  );
}

export default App;
