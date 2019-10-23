import React,{useState} from 'react';
import Axios from 'axios';

function CadastrarCategoria(event){
    const [nomeCat,setNomeCat] = useState("")

    function cadastrar(event){
    event.preventDefault();
    Axios.post('http://localhost:5000/api/Categorias',{
        nomeCat: setNomeCat
    },{
        headers: {
            'Authorization' : "Bearer " + sessionStorage.getItem("opflix_user")
        }
    }).then(console.log(setNomeCat))}
    return(
        <form onSubmit>
        <input value={nomeCat} placeholder="Digite o nome da categoria" onChange={event => setNomeCat(event.target.value)}></input>
        <button onClick={cadastrar}>Cadastrar</button>
        </form>
    )
}
export default CadastrarCategoria;