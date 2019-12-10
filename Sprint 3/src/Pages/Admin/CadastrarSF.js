import React,{Component} from 'react';
import Axios from 'axios';

export default class CadastrarSF extends Component{
    constructor(){
        super();
        this.state = {
            titulo : "",
            dataLancamento: "",
            idTipo: "",
            sinopse : "",
            idCat : "",
            tempoD: "",
            faixaEtaria: "",
            descricao:"",
            plataforma: "",
            listaG: [],
            listaP: []
        }
    }
    componentDidMount(){
        Axios.get("http://192.168.4.200:5000/api/Categorias",{
            headers: {
                "Authorization" : "Bearer " + sessionStorage.getItem("opflix_user")
            }
        }).then(data => this.setState({listaG : data.data}));
        Axios.get("http://192.168.4.200:5000/api/Plataformas",{
            headers: {
                "Authorization" : "Bearer " + sessionStorage.getItem("opflix_user")
            }
        }).then(data => this.setState({listaP : data.data}))
    }
    cadastrar=(event)=>{
        event.preventDefault();
        Axios.post("http://192.168.4.200:5000/api/Lancamentos",{
            titulo: this.state.titulo,
            dataLancamento: this.state.dataLancamento,
            idTipo: Number(this.state.idTipo),
            sinopse: this.state.sinopse,
            idCat: Number(this.state.idCat),
            tempoD: this.state.tempoD,
            faixaEtaria: Number(this.state.faixaEtaria),
            descricao: this.state.descricao,
            plataforma: Number(this.state.plataforma)
        },{
            headers: {
                'Authorization' : "Bearer " + sessionStorage.getItem("opflix_user"),"Content-Type" : "application/json"
            }
        }).then(data => this.setState({titulo: data.titulo,dataLancamento: data.dataLancamento,idTipo:data.idTipo,sinopse: data.sinopse,idCat: data.idCat,tempoD: data.tempoD,faixaEtaria: data.faixaEtaria,descricao: data.descricao,plataforma: data.plataforma})).then(window.location.reload(false))}
        atualizarTitulo = (event) =>{
            this.setState({titulo: event.target.value})
            console.log(this.state);
        }
        atualizarLancamento = (event) =>{
            this.setState({dataLancamento: event.target.value})
            console.log(this.state);
        }
        atualizarIdTipo = (event) =>{
            this.setState({idTipo: event.target.value})
            console.log(this.state);
        }
        atualizarSinopse = (event) =>{
            this.setState({sinopse: event.target.value})
            console.log(this.state);
        }
        atualizarIdCat = (event) =>{
            this.setState({idCat: event.target.value})
            console.log(this.state);
        }
        atualizarDuracao = (event) =>{
            this.setState({tempoD: event.target.value})
            console.log(this.state);
        }
        atualizarFaixaEtaria = (event) =>{
            this.setState({faixaEtaria: event.target.value})
            console.log(this.state);
        }
        atualizarDescricao = (event) =>{
            this.setState({descricao: event.target.value})
            console.log(this.state);
        }
        atualizarPlataforma = (event) =>{
            this.setState({plataforma: event.target.value})
            console.log(this.state);
        }
    render(){
    return(
        <form onSubmit>
        <input value={this.state.titulo} placeholder="Digite o titulo" type="text" onInput={this.atualizarTitulo}></input>
        <input value={this.state.dataLancamento} placeholder="ano-mês-dia" type="text" onInput={this.atualizarLancamento}></input>
        <select onChange={this.atualizarIdTipo} class="form-control" id="exampleFormControlSelect1">
        <option value="1">Filme</option>
        <option value="2">Serie</option>
        <option selected hidden>Selecione uma opção</option>
        </select>
        <input value={this.state.sinopse} placeholder="Digite a sinopse" type="text" onInput={this.atualizarSinopse}></input>
        <select onChange={this.atualizarIdCat} class="form-control" id="exampleFormControlSelect1">
        {this.state.listaG.map(element => {
            return(<option value={element.idCat}>{element.nomeCat}</option>)
        })}
        <option selected hidden>Selecione uma opção</option>
        </select>
        <input value={this.state.tempoD} placeholder="Duração em minutos" type="text" onInput={this.atualizarDuracao}></input>
        <input value={this.state.faixaEtaria} placeholder="Digite a faixa etaria" type="text" onInput={this.atualizarFaixaEtaria}></input>
        <input value={this.state.descricao} placeholder="Escreva uma descrição" type="text" onInput={this.atualizarDescricao}></input>
        <select onChange={this.atualizarPlataforma} class="form-control" id="exampleFormControlSelect1">
        {this.state.listaP.map(element => {
            return(<option value={element.idPlataforma}>{element.nome}</option>)
        })}
        <option selected hidden>Selecione uma opção</option>
        </select>
        <button onClick={this.cadastrar}>Cadastrar</button>
        </form>
    )
    }
}
