import React, { Component } from 'react';
import Axios from 'axios';
import '../CSS/App.css'
import { Map, InfoWindow, Marker, GoogleApiWrapper, Listing } from 'google-maps-react';

export class Mapa extends Component {

    constructor() {
        super()
        this.state = {
            lista: []
        }
    }
    componentDidMount() {
        fetch("http://192.168.4.200:5000/api/localizacoes")
            .then(res => res.json())
            .then(data => this.setState({ lista: data }))
            .catch(error => console.log(error));

    }
    render() {
        return (
            <div>
                <Map google={this.props.google} zoom={1}>
                    {this.state.lista.map(element => {
                        return (
                            <Marker position={{ lat: element.latitude, lng: element.longitude }}></Marker>
                        )
                    })}
                </Map>
            </div>
        )
    }

}
export default GoogleApiWrapper({
    apiKey: ("AIzaSyAJ000T0VeifR66iv5xIzwF7rw584fv7D4")
})(Mapa)