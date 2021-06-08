import * as React from 'react';
import { BrowserRouter as Router } from 'react-router-dom'
import Header from './components/Header'
import Routes from './routes/Routes'

export default () => (
    <Router>
        <Header />
        <Routes />
    </Router>
);
