const receiveData = 'RECEIVE_DATA';
const initialState = { items: []};

export const actionCreators = {
  return (dispatch, getState) => {      
    dispatch({ type: requestData});
	const url = `api/SampleData/GetItemDetails`;
	 fetch(url)
      .then(res => res.json())
      .then(data => dispatch({type: receiveData, data}));
	  }
};

export const reducer = (state, action) => {
  state = state || initialState;
  if (action.type === receiveData) {
    return {
      ...state,
      items: action.items
    };
  }
  return state;
};