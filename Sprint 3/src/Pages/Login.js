import React,{Component} from 'react';
import Axios from 'axios';
import Rodape from '../Components/Rodope'
import '../CSS/App.css';
class Login extends Component{
    constructor(){
        super();
        this.state = {
            email : "",
            senha : "",
            erro : ""
        }
    }

    AtualizarInformacaoEmail=(event)=>{
        this.setState({email: event.target.value});
    }
    AtualizarInformacaoSenha=(event)=>{
        this.setState({senha: event.target.value});
    }
    EfetuarLogin=(event)=>{
        event.preventDefault();
        Axios.post("http://192.168.4.200:5000/api/Login",{
            email:this.state.email,
            senha:this.state.senha
        }).then(response =>{
            if(response.status === 200){
                sessionStorage.setItem("opflix_user",response.data.token)
                this.props.history.push('/IndexLogado');
            }else{
                console.log("Error!")
            }
        }).catch(erro => {
            this.setState({erro: "Usuario e/ou senha inválida"});
        console.log(erro);
        });
    }


    render(){
        return(
            <div className="App">
                <header>
                    <a href="/Index">Voltar</a>
                </header>
                <body>
            <section className="MainSec">
            <div className="Title">
                <p className="TextoTitulo">
                    Bem-vindo! Faça seu login abaixo e acesse sua conta.
                </p>
            </div>
            <form onSubmit={this.EfetuarLogin}>
                <div className="Item">
                <input className="input-login" placeholder="Digite seu email" onInput={this.AtualizarInformacaoEmail} type="Text" name="email"></input>
                </div>
                <div className="Item">
                <input className="input-login" placeholder="Digite sua senha" onInput={this.AtualizarInformacaoSenha} type="Text" name="senha"></input>
                </div>
                <div className="Item">
                <button className="Button-login">Login</button>
                </div>
            </form>
            </section>
            </body>
            <Rodape/>
            </div>
        );
    }
}
export default Login;