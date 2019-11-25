import React,{Component} from 'react';

import lupa from '../img/lupa.png'
import { SearchBar } from 'react-native-elements';
import {
    Text,
    View,
    TextInput,
    TouchableOpacity,
    AsyncStorage,
    Image,
    StyleSheet,
    SafeAreaView,
    Dimensions,
} from 'react-native';
import {FlatList} from 'react-native-gesture-handler';

if (!Array.prototype.joinWith) {
  +function () {
      Array.prototype.joinWith = function(that, by, select, omit) {
          var together = [], length = 0;
          if (select) select.map(function(x){select[x] = 1;});
          function fields(it) {
              var f = {}, k;
              for (k in it) {
                  if (!select) { f[k] = 1; continue; }
                  if (omit ? !select[k] : select[k]) f[k] = 1;
              }
              return f;
          }
          function add(it) {
              var pkey = '.'+it[by], pobj = {};
              if (!together[pkey]) together[pkey] = pobj,
                  together[length++] = pobj;
              pobj = together[pkey];
              for (var k in fields(it))
                  pobj[k] = it[k];
          }
          this.map(add);
          that.map(add);
          return together;
      }
  }();
}

class Filmes extends Component{
static navigationOptions = {
    tabBarIcon: () => (
      <Image
        source={require("../img/clapperboard.png")}
        style={styles.tabBarNavigatorIcon}
      /> 
    ),
    tabBarLabel: 'Filmes',
  };
  constructor(){
      super();
      this.state = {
          Filmes : [],
          Categorias: [],
          search: '',
          searchDate: "",
      }
  }
  componentDidMount(){
        this._CarregarFilmes();
        this._CarregarCategorias();
  };
  _CarregarCategorias = async () => {
    await fetch('http://192.168.4.200:5000/api/Categorias/', {
      headers: {
        'Authorization': "Bearer " + await AsyncStorage.getItem('@OpFlix:token'),
        'Accept': 'application/json',
        'Content-Type': 'application/json',
      }
    })
      .then(resposta => resposta.json())
      .then(data => this.setState({ Categorias: data }))
      .catch(erro => console.warn(erro));
  }

  _CarregarFilmes = async () => {
    await fetch('http://192.168.4.200:5000/api/Lancamentos/',{
        headers: {
            'Authorization' : "Bearer " + await AsyncStorage.getItem('@OpFlix:token'),
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        }
    })
      .then(resposta => resposta.json())
      .then(data => this.setState({Filmes: data}))
      .catch(erro => console.warn(erro));
  }

  header = () => {
    return <View><SearchBar placeholder="Buscar por categoria" value={this.state.search} lightTheme round onChangeText={this.Pesquisar}></SearchBar>
    <SearchBar placeholder="Buscar por data de lançamento" value ={this.state.searchDate} lightTheme round onChangeText={this.PesquisarData}></SearchBar></View>
  }

 headerD = () => {
   return <SearchBar placeholder="Buscar por data de lançamento" value ={this.state.searchDate} lightTheme round onChangeText={this.PesquisarData}></SearchBar>
 }


 PesquisarData = (text) => {
   this.setState({searchDate : text})
 }


  Pesquisar = (text) => {
    console.log("text", text)
    this.setState({ search: text })
  }


  render() {
    return (

      <SafeAreaView style={styles.background}>
        {(this.state.search !== null) & (this.state.search !== "") & (this.state.searchDate == "" || null) ?
          <View style = {styles.lista}>
            <FlatList
              data={this.state.Filmes.filter(element => element.idTipo === 1).joinWith(this.state.Categorias,'idCat').filter(element => element.nomeCat.toLowerCase() == this.state.search.toLowerCase())}
              keyExtractor={item => item.idSf}
              ListHeaderComponent={this.header}
              ItemSeparatorComponent={
                () => <View style={{ height: 10,width: Dimensions.get('window').width, backgroundColor: 'red' }}/>
            }
              renderItem={({ item }) => (
                <View>
                  <Text style={styles.textostitulo}>Titulo: {item.titulo}</Text>
                  <Text style={styles.textos}>Data de Lançamento: {item.dataLancamento}</Text>
                  <Text style={styles.textos}>Gênero: {item.nomeCat}</Text>
                  <Text style={styles.textos}>Faixa etária: {item.faixaEtaria} anos</Text>
                </View>
              )}
            />
            <View>
            </View>
          </View>
          :
        ((this.state.searchDate !== null) & (this.state.searchDate !== "") & (this.state.search == "" || null)) ?
          <View style = {styles.lista}>
            <FlatList
              data={this.state.Filmes.filter(element => element.idTipo == 1).joinWith(this.state.Categorias,'idCat').filter(element => element.dataLancamento == this.state.searchDate)}
              keyExtractor={item => item.idSf}
              ItemSeparatorComponent={
                () => <View style={{ height: 10,width: Dimensions.get('window').width, backgroundColor: 'red' }}/>
            }
              ListHeaderComponent={this.header}
              renderItem={({ item }) => (
                <View>
                  <Text style={styles.textostitulo}>Titulo: {item.titulo}</Text>
                  <Text style={styles.textos}>Data de Lançamento: {item.dataLancamento}</Text>
                  <Text style={styles.textos}>Gênero: {item.nomeCat}</Text>
                  <Text style={styles.textos}>Faixa etária: {item.faixaEtaria} anos</Text>
                </View>
              )}
            />

          </View>

          :
          ((this.state.searchDate !== null) & (this.state.searchDate !== "") & (this.state.search !== null) & (this.state.search !== "")) ? 
          <View style = {styles.lista}>
            <FlatList
              data={this.state.Filmes.filter(element => element.idTipo == 1).joinWith(this.state.Categorias,'idCat').filter(element => element.dataLancamento == this.state.searchDate & element.nomeCat.toLowerCase() == this.state.search.toLowerCase())}
              keyExtractor={item => item.idSf}
              ItemSeparatorComponent={
                () => <View style={{ height: 10,width: Dimensions.get('window').width, backgroundColor: 'red' }}/>
            }
              ListHeaderComponent={this.header}
              renderItem={({ item }) => (
                <View>
                  <Text style={styles.textostitulo}>Titulo: {item.titulo}</Text>
                  <Text style={styles.textos}>Data de Lançamento: {item.dataLancamento}</Text>
                  <Text style={styles.textos}>Gênero: {item.nomeCat}</Text>
                  <Text style={styles.textos}>Faixa etária: {item.faixaEtaria} anos</Text>
                </View>
              )}
            />

          </View>
          
          :
          
          <View style = {styles.lista}>
          <FlatList
            data={this.state.Filmes.filter(element => element.idTipo == 1).joinWith(this.state.Categorias,'idCat').filter(element => element.titulo != null)}
            keyExtractor={item => item.idSf}
            ItemSeparatorComponent={
              () => <View style={{ height: 10,width: Dimensions.get('window').width, backgroundColor: 'red' }}/>
          }
            ListHeaderComponent={this.header}
            renderItem={({ item }) => (
              <View>
                  <Text style={styles.textostitulo}>Titulo: {item.titulo}</Text>
                  <Text style={styles.textos}>Data de Lançamento: {item.dataLancamento}</Text>
                  <Text style={styles.textos}>Gênero: {item.nomeCat}</Text>
                  <Text style={styles.textos}>Faixa etária: {item.faixaEtaria} anos</Text>
              </View>
            )}
          />

        </View>
        }
      </SafeAreaView>

    )
  }
}
var styles = StyleSheet.create({
  tabBarNavigatorIcon: {width: 30, height: 30, tintColor: 'white'},
  tabBarLabel: {color: 'white'},
  background : {backgroundColor: '#121212', height: Dimensions.get('window').height},
  textos : {color:"white"},
  textostitulo : {color : "yellow"},
  lista : {justifyContent: 'space-between'},})
 export default Filmes;