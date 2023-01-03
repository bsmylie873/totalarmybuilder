import React, {useState, useEffect, useReducer} from 'react';

const intialReducerState = {
  value: 50,
};

const reducer = (state: any, action: any) => {
  switch(action.type){
    case "ofTest":
      return {...state, value: action.value};
    case "reset":
      return intialReducerState;
    default:
      return state;
  }
}

function App() {
  const [x, setX] = useState(0);
  const [reducerState, dispatch] = useReducer(reducer, intialReducerState);
  const add = () => {
    setX((prevX) => prevX+5);
    dispatch({ type: "ofTest", value: 666});
  } 
  const reset = () => {
    dispatch({ type: "reset"});
  } 

  useEffect(() => {
    console.log(x);
  }, [])




  return (
    <div className="App">
      <header className="App-header">
        <p>
          reducerState {reducerState.value}
        </p>
        <button
          className="App-link"
          onClick={() => add()}
        >
          New Gext {x}
        </button>
        <button
          className="App-link"
          onClick={() => reset()}
        >
          Reset
        </button>
      </header>
    </div>
  );
}

export default App;
