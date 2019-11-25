import React, { Component } from 'react';
import { Text, View, Image, StyleSheet, Dimensions, Fragment,Animated } from 'react-native';
import { ScrollView } from 'react-native-gesture-handler';
import Rodape from '../Components/Rodape';
import FadeIn from 'react-native-fade-in-image';


class Main extends Component {
    static navigationOptions = {
        tabBarIcon: () => (
          <Image
            source={require("../img/home.png")}
            style={styles.tabBarNavigatorIcon}
          /> 
        ),
        tabBarLabel: 'Home',
      };
    constructor(){
        super();
        this.state = {
            fadeValue : new Animated.Value(0),
        }
    }
    _fadeAnim = () =>{
        Animated.timing(this.state.fadeValue,{
            toValue: 1,
            duration: 4000,
        }).start();
    }
    render() {
        return (
            <View style={styles.container}>
            <ScrollView style={styles.background}>
                <View>
                    <View>
                        <Animated.Image style={[styles.logo,{opacity: this.state.fadeValue}]} onLoad={this._fadeAnim()}source={require("../img/OpFlixLogoMobile.png")}></Animated.Image>
                        <Text>Suas séries e filmes reunidas em apenas um lugar!</Text>
                    </View>
                    <View style={{
                        flex: 1,
                        flexDirection: 'column',
                        justifyContent: 'center',
                        alignContent: 'center',
                    }}>
                        <View>
                            <Text></Text>
                        <Image style={styles.fotos} source={require('../img/Coringa.png')}></Image>
                        <Text style={styles.textos}>Sorrie e compartilhe momentos divertidos e alegre com seus amigos!</Text>
                            <Text></Text>
                            <Image style={styles.fotos} source={require("../img/Shazam.png")}></Image>
                            <Text style={styles.textos}>Filmes e séries de tirarem o fôlego estão te esperando. Uma eletrizante aventura fielmente está por vir!</Text>
                        </View>
                        <View>
                            <Text></Text>
                            <Image style={styles.fotos} source={require("../img/It.png")}></Image>
                            <Text style={styles.textos}>Os mais novos filmes de todo o cinema,catalogos atualizados e sempre com uma novidade a compartilhar</Text>
                        </View>
                    </View>
                </View>
                <View>
                    <Text>This text is just taking some space so please, ignore it UwU OwO it's just a normal and invisible text, if you're seeing it good job! You know how to access the code!</Text>
                </View>
                <View style={{
                    flex: 1,
                    flexDirection: 'column',
                    justifyContent: 'center',
                    alignItems: 'center'
                }}>
                    <Rodape ></Rodape>
                </View>
            </ScrollView>
            </View>
        );
    }
};
var styles = StyleSheet.create({
    fotos: {
        height: 300,
        width: Dimensions.get('window').width,
        borderWidth: 2,
        borderColor: "rgba(255, 255, 255, 0.5)",
    },
    logo: {
        width: Dimensions.get('window').width
    },
        tabBarNavigatorIcon: {width: 30, height: 30, tintColor: 'white'},
        tabBarLabel: {color: 'white'},
    background : {
        backgroundColor : "black",
    },
    textos : {
        color : "white",
        width: Dimensions.get('window').width - 20,
        alignContent:"center",
        justifyContent:"center",
        textAlign:"justify",
        fontSize: 18,
        flex:1
    },
    container: {
        alignContent:"center",
        justifyContent:"center",
    }
})
export default Main;