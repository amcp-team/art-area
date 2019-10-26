import React from 'react';
import logo from './logo.svg';
import './App.css';
import {Task} from "./Task.js"
import { Slide } from './Slide';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";

function App() {
  return (
    <div className="App">
      <div class="container">
        <Router>
          <Switch>
            <Route exact path="/" >
              <Task />
            </Route>
            <Route path="/slide/:id" component={Slide}>
              
            </Route>
          </Switch>
        </Router>
        
      </div>
    </div>
  );
}

export default App;
