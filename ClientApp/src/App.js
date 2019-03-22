import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import DentalSupply from './components/DentalSupply';

export default () => (
  <Layout>
	<DentalSupply/>
    <Route exact path='/' component={Home} />
	<Route path='/DSOrder' component={DentalSupply} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
  </Layout>
);
