import {createAppContainer, createSwitchNavigator} from 'react-navigation';
import {createStackNavigator} from 'react-navigation-stack';
import {createBottomTabNavigator} from 'react-navigation-tabs';
import Text from 'react-native'

import SignInScreen from './pages/SignIn';
import MainScreen from './pages/Main';
import SeriesScreen from './pages/Series';
import FilmesScreen from './pages/Filmes';
const AuthStack = createStackNavigator({
    Sign: {screen: SignInScreen},
});
const MainNavigator = createBottomTabNavigator(
    {
      Main: {
        screen: MainScreen,
      },Series:{
        screen : SeriesScreen,
      },Filmes:{
        screen: FilmesScreen
      }
    },
    {
      initialRouteName: 'Main',
      tabBarOptions: {
        showIcon: true,
        showLabel: true,
        inactiveBackgroundColor: '#cf001a',
        activeBackgroundColor: '#cf001a',
        labelStyle: {
          color: 'white',
        },
        style: {
          width: '100%',
          height: 50,
        },
      },
    },
  );
export default createAppContainer(
    createSwitchNavigator(
        {
            AuthStack,
            MainNavigator,
        },{
            initialRouteName: 'AuthStack',
            },
    ),
);