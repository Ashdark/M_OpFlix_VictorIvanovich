import React,{Component} from 'react';
import Axios from 'axios';

export default class CadastrarUsuario extends Component{
    constructor(){
        super();
        this.state = {
            nome : "",
            senha: "",
            email: "",
            idTipo : ""
        }
    }
    cadastrar=(event)=>{
        event.preventDefault();
        Axios.post("http://192.168.4.200:5000/api/Usuarios",{
            nome: this.state.nome,
            senha: this.state.senha,
            email: this.state.email,
            idTipo: Number(this.state.idTipo)
        },{
            headers: {
                'Authorization' : "Bearer " + sessionStorage.getItem("opflix_user")
            }
        }).then(data => this.setState({nome: data.nome,senha: data.senha,email:data.email,idTipo: data.idTipo})).then(window.location.reload(false))}
    atualizarNome = (event) =>{
            this.setState({nome: event.target.value})
            console.log(this.state);
        }
        atualizarSenha = (event) =>{
            this.setState({senha: event.target.value})
            console.log(this.state);
        }
        atualizarEmail = (event) =>{
            this.setState({email: event.target.value})
            console.log(this.state);
        }
        atualizarTipo = (event) =>{
            this.setState({idTipo: event.target.value})
            console.log(this.state);
        }
    render(){
    return(
        <form onSubmit>
        <input value={this.state.nome} placeholder="Digite o nome do usuario" type="text" onInput={this.atualizarNome}></input>
        <input value={this.state.senha} placeholder="Digite a senha do usuario" type="password" onInput={this.atualizarSenha}></input>
        <input value={this.state.email} placeholder="Digite o email do usuario" type="email" onInput={this.atualizarEmail}></input>
        <input value={this.state.idTipo} placeholder="1 = comum|2 = adm" type="text" onInput={this.atualizarTipo}></input>
        <button onClick={this.cadastrar}>Cadastrar</button>
        </form>
    )
    }
}
