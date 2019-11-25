import React,{Component} from 'react';
import Axios from 'axios';

export default class CadastrarCategoria extends Component{
    constructor(){
        super();
        this.state = {
            nomeCat : ""
        }
    }
    cadastrar=(event)=>{
        event.preventDefault();
        Axios.post("http://localhost:5000/api/Categorias",{
            nomeCat: this.state.nomeCat
        },{
            headers: {
                'Authorization' : "Bearer " + sessionStorage.getItem("opflix_user")
            }
        }).then(data => this.setState({nomeCat: data})).then(window.location.reload(false))}
    atualizarNome = (event) =>{
            this.setState({nomeCat: event.target.value})
            console.log(this.state);
        }
    render(){
    return(
        <form onSubmit>
        <input value={this.state.nomeCat} placeholder="Digite o nome da categoria" type="text" onInput={this.atualizarNome}></input>
        <button onClick={this.cadastrar}>Cadastrar</button>
        </form>
    )
    }
}
