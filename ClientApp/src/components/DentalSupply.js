import React,{Component} from 'react';
import ReactDOM from "react-dom";

class DentalSupply extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			items: []			
		};
	}
  componentWillMount() {
    const url = `api/SampleData/GetItemDetails`;
	 fetch(url)
      .then(res => res.json())
      .then(data => this.setState({items: data}));
  }

  render() {
	console.log(this.state.items);
	const items = this.state.items;
	if(items.Count == 0){
		return <p>Loading....</p>;	
	}	
    return (
	      <div>
        <ul>
          {items.map(item =>
          <li key={item.toothNumber}>Tooth Number: {item.toothNumber} - Ref : {item.itemCode} - Price: {item.price}</li>
        )}
        </ul>		
      </div>
    );
  }
 }
 export default DentalSupply;