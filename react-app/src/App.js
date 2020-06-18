import React, { Component } from 'react';
import { store } from "./Actions/store";
import { Provider } from "react-redux";
import Empresas from './Components/Empresas';
import GlobalStyle from './styles/global';
import { Container } from '@material-ui/core';

class App extends Component {

  state = {
    empresas: [],
  };

  render() {
    return (
      <Provider store={store}>
        <Container maxWidth="lg">
          <Empresas />
          <GlobalStyle />
        </Container>
      </Provider>
    );
  }
}

export default App;
