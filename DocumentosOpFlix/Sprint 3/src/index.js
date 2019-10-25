import React from 'react';
import ReactDOM from 'react-dom';
import './CSS/index.css';
import App from './Pages/App';
import * as serviceWorker from './serviceWorker';

import {Route, Link, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';
import Login from '../src/Pages/Login';
import IndexLogado from '../src/Pages/IndexLogado';
import Filmes from '../src/Pages/Filmes';
import Series from '../src/Pages/Series';
import CadastrarCategoria from '../src/Pages/Admin/CadastrarCategoria'
import CadastrarUsuario from '../src/Pages/Admin/CadastrarUser';
import CadastrarSF from '../src/Pages/Admin/CadastrarSF';

const RotaPrivada = ({component: Component}) =>(
    <Route
        render={props =>
            sessionStorage.getItem("opflix_user") !== null ? (
                <Component {...props} /> 
            ) : (
                <Redirect 
                    to={{ pathname: "/login", state: {from: props.location}}}
                />
            )
        }
    />        
);
const routing = (
    <Router>
        <div>
            <Switch>
                <Route exact path='/' component={App}></Route>
                <Route exact path='/Index' component={App}></Route>
                <Route path='/login' component={Login}/>
                <RotaPrivada path ='/IndexLogado' component={IndexLogado}></RotaPrivada>
                <RotaPrivada path ='/Filmes' component={Filmes}></RotaPrivada>
                <RotaPrivada path ='/Series' component={Series}></RotaPrivada>
                <RotaPrivada path ='/CadastrarCategoria' component={CadastrarCategoria}></RotaPrivada>
                <RotaPrivada path ='/CadastrarUsuario' component={CadastrarUsuario}></RotaPrivada>
                <RotaPrivada path ='/CadastrarSF' component={CadastrarSF}></RotaPrivada>
            </Switch>
        </div>
    </Router>
)


ReactDOM.render(routing, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
