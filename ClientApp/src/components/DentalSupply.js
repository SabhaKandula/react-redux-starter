import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/DentalSupply';

class DentalSupply extends Component {

  componentWillMount() {
    this.props.actionCreators();
  }

  render() {
    return (
      <div>
        <h1>Dental Supply Items forecast</h1>
        <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
        {renderForecastsTable(this.props)}       
      </div>
    );
  }
}

function renderForecastsTable(props) {
  return (
    <table className='table'>
      <thead>
        <tr>
          <th>Tooth Number</th>
          <th>SAP Number</th>
          <th>Price</th>
        </tr>
      </thead>
      <tbody>
        {props.items.map(item =>
          <tr key={item.itemCode}>
            <td>{item.toothNumber}</td>
            <td>{item.itemCode}</td>
            <td>{item.price}</td>            
          </tr>
        )}
      </tbody>
    </table>
  );
}

export default connect(
  state => state.dentalSupply,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(DentalSupply);