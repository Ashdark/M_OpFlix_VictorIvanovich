import React,{Component} from 'react';
import Rodope from '../Components/Rodope';
import '../CSS/App.css';
import {Link} from 'react-router-dom';
import logo from '../Img/OpFlixLogo.png';
import logo2 from '../Img/Opflix.png';
import Foto1 from '../Img/Coringa.png';
import Foto2 from '../Img/Shazam.png';
import Foto3 from '../Img/It.png';
import { parseJwt } from "../Services/Auth";

class IndexLogado extends Component{
    constructor(){
        super();
        this.state = {
            permissao : ""
        }
    }
    componentDidMount(){
        this.setState({permissao: parseJwt().prn})
    }
deslogar=()=>{
    sessionStorage.removeItem("opflix_user");
}
  render(){
    return (<div className="App">
    <link rel="stylesheet" href="css/animate.min.css"></link>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"></link>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
      <header className="App-header">
      <nav className="navbar navbar-inverse navbar-fixed-top">
  <div className="container-fluid">
    <div className="navbar-header">
      <img className="navbar-brand" src={logo2} />
    </div>
  <ul className="nav navbar-nav">
    {(this.state.permissao == 1 | 2) ? (<li><a href="/IndexLogado">Home</a></li>) : ""}
    {(this.state.permissao == 1) ? (<li><a href="/Filmes">Filmes</a></li>) : ""}
    {(this.state.permissao == 1) ? (<li><a href="/Series">Séries</a></li>) : ""}
    {(this.state.permissao == 1) ? (<li><a href="#">Sobre(Em breve)</a></li>) : ""}
    {(this.state.permissao == 1) ? (<li><a href="#">Informações(Em breve)</a></li>) : ""}
    {(this.state.permissao == 1) ? (<li><a href="#">FAQ(Em breve)</a></li>) : ""}
    {(this.state.permissao == 1) ? (<li><a href="/Mapa">Mapa</a></li>) : ""}
    {(this.state.permissao == 2) ? (<li><a href="/CadastrarCategoria">CadastrarCategoria</a></li>) : ""}
    {(this.state.permissao == 2) ? (<li><a href="/CadastrarUsuario">CadastrarUser</a></li>) : ""}
    {(this.state.permissao == 2) ? (<li><a href="/CadastrarSF">CadastrarSF</a></li>) : ""}
    </ul>
    <ul className="nav navbar-nav navbar-right">
    <li><Link to="/Index" onClick={this.deslogar}><span className="glyphicon glyphicon-log-in"></span>Logout</Link></li>
    </ul>
    </div>
    </nav> 
    <div className="fade-in">
        <img src={logo} width="400" height="300"/>
        <p>
          Suas séries e filmes reunidas em apenas um lugar!
        </p>
        </div>
      </header>
      <body>
      <div className="Conteudo-caixas">
      <div className="QuadradoCompleto">
        <div className="DisplayTexto">
          <img className="Quadrado1"src={Foto1} width="400" height="300"></img>
          <p className="TextoFilmes">Sorrie e compartilhe momentos divertidos e alegre com seus amigos!</p>
        </div>      
        </div>
        <div className="QuadradoCompleto">
        <div className="DisplayTexto">
          <img className="Quadrado2" src={Foto2} width="400" height="300"></img>
        <p className="TextoFilmes">Filmes e séries de tirarem o fôlego estão te esperando. Uma eletrizante aventura fielmente está por vir!</p>
        </div>
        </div>
        <div className="QuadradoCompleto">
        <div className="DisplayTexto">
          <img className="Quadrado3"src={Foto3} width="400" height="300"></img>
          <p className="TextoFilmes">Os mais novos filmes de todo o cinema,catalogos atualizados e sempre com uma novidade a compartilhar</p>
        </div>
        </div>
      </div>
      </body>
      <Rodope />  
    </div>
    )
  }
}

export default IndexLogado;
