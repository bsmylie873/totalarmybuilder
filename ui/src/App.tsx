import React from 'react';
import {Navigate, Route, Routes} from "react-router-dom";
import {
  AccountDetails,
  Blog,
  CompositionCreationDom,
  CompositionCreationLB,
  CompositionEditDom,
  CompositionEditLB,
  CreateAccount,
  Home,
  Login,
  Search
} from "./pages";
import "./styles.css";

function App() {
  return (<Routes>
<Route path="/accountdetails" element={<AccountDetails/>}/>
<Route path="/blog" element={<Blog/>}/>
<Route path="/compositioncreationdom" element={<CompositionCreationDom/>}/>
<Route path="/compositioncreationlb" element={<CompositionCreationLB/>}/>
<Route path="/compositioneditdom" element={<CompositionEditDom/>}/>
<Route path="/compositioneditlb" element={<CompositionEditLB/>}/>
<Route path="/createaccount" element={<CreateAccount/>}/>
<Route path="/home" element={<Home/>}/>
<Route path="/login" element={<Login/>}/>
<Route path="/search" element={<Search/>}/>
<Route path="*" element={<Navigate to="/home"/>}/>
  </Routes>)
}

export default App;