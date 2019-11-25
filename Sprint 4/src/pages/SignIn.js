import React, { Component } from 'react';

import {
    Text,
    View,
    TextInput,
    TouchableOpacity,
    AsyncStorage,
    StyleSheet,
    ScrollView,
    Dimensions,
    Image
} from 'react-native';


class SignIn extends Component {
    static navigationOptions = {
        header: null,
    };

    constructor() {
        super();
        this.state = {
            email: "",
            senha: ""
        };
    }

    _realizarLogin = async () => {
        fetch('http://192.168.4.200:5000/api/Login', {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                email: this.state.email,
                senha: this.state.senha,
            }),
        }).then(resposta => resposta.json()).then(data => this.Home(data.token)).catch(erro => console.log("Error:"+{erro}));

    };

    Home = async tokenRecebido => {
        if (tokenRecebido != null) {
            try {
                await AsyncStorage.setItem('@OpFlix:token', tokenRecebido);
                this.props.navigation.navigate('MainNavigator');
            } catch (error) { }
        }
    };

    render() {
        return (
            <View style={styles.container}>
                <Image style={styles.logo}source={require("../img/Opflix.png")}/>
                <TextInput style={styles.input1} placeholder="Digite seu email" onChangeText={email => this.setState({ email })} value={this.state.email}>

                </TextInput>
                <TextInput style={styles.input2} placeholder="Digite sua senha" secureTextEntry={true} onChangeText={senha => this.setState({ senha })} value={this.state.senha}>

                </TextInput>
                <TouchableOpacity style={styles.button} onPress={this._realizarLogin}>
                    <Text style={styles.texto}>Login</Text>
                </TouchableOpacity>
            </View>
        )
    }


}
var styles = StyleSheet.create({
    container : {
        backgroundColor: "#121212",
        height: Dimensions.get('window').height,
        flex: 1,
        alignItems: "center"

    },
    input1 : {
        backgroundColor : "white",
        borderColor: "rgba(255, 0, 0, 1)",
        borderWidth: 2,
        borderRadius:90,
        fontSize:16,
        marginTop: 150,
        width: 300,
        position: "absolute",
        textAlign:"center"
    },
    input2 : {
        backgroundColor : "white",
        borderColor: "rgba(255, 0, 0, 1)",
        borderWidth: 2,
        borderRadius:90,
        fontSize:16,
        marginTop: 250,
        width: 300,
        position:"absolute",
        textAlign: "center"
    },
    button : {
        position:"absolute",
        marginTop: 350
    },
    texto: {
        color: "white",
    },
    logo : {
        width:150,
        height:50,
        marginTop: 40,
        position:"absolute"
    }
})
export default SignIn;