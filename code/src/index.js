import React from 'react';
import ReactDOM from 'react-dom';
import './CSS/index.css';
import App from './Pages/App';
import * as serviceWorker from './serviceWorker';

import {Route, Link, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';
import Login from '../src/Pages/Login';


const routing = (
    <Router>
        <div>
            <Switch>
                <Route exact path='/' component={App}></Route>
                <Route exact path='/Index' component={App}></Route>
                <Route path='/login' component={Login}/>
            </Switch>
        </div>
    </Router>
)


ReactDOM.render(routing, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
