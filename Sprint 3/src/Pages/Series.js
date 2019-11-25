import React,{Component} from 'react';
import Axios from 'axios';
import '../CSS/App.css'

export default class Series extends Component{
    constructor(){
        super();
        this.state = {
            lista : [],
            listaG : [],
            listaP: []          
        }
    }
    componentDidMount(){
        Axios('http://localhost:5000/api/Lancamentos',{
            headers : {'Authorization' : "Bearer " + sessionStorage.getItem("opflix_user")}
        })
        .then(data => this.setState({ lista: data.data}));
        Axios('http://localhost:5000/api/Categorias',{
            headers : {'Authorization' : "Bearer " + sessionStorage.getItem("opflix_user"), 'Content-Type' : 'application/json'}
        }).then(data => this.setState({listaG : data.data}))
        Axios('http://localhost:5000/api/Plataformas',{
            headers : {'Authorization' : "Bearer " + sessionStorage.getItem("opflix_user")}
        }).then(data => this.setState({listaP : data.data}))

    }
    
    render(){
        return(
            <div>
                    <header>
                    <a href="/IndexLogado">Voltar</a>
                </header>
            <tbody>
                {this.state.lista.filter(element => element.idTipo === 2).map(element =>{
                    return(
                        <tr className="Tabela">
                            <td>{element.titulo}</td>
                            <td>{element.dataLancamento}</td>
                            <td>{element.sinopse}</td>
                            <td>{element.idCat}</td>
                            <td>{element.tempoD}</td>
                            <td>{element.faixaEtaria}</td>
                            <td>{element.descricao}</td>
                            <td>{element.plataforma}</td>
                        </tr>
                    )
                })}
            </tbody>
            </div>
        )
    }

}