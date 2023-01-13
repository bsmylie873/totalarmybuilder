import React from "react";
import { Navigate, Route, Routes } from "react-router-dom";
import {
  AccountDetails,
  Blog,
  Composition,
  Home,
  Login,
  MyBuilds,
  PasswordReset,
  Search,
  SignUp,
  Tutorial,
} from "./pages";
import "./styles.css";
import Layout from "./components/layout";

function App() {
  return (
    <>
      <Layout>
        <Routes>
          <Route
            path="/accountdetails/:accountId"
            element={<AccountDetails />}
          />
          <Route path="/blog" element={<Blog />} />
          <Route path="/composition/:compositionId" element={<Composition />} />
          <Route path="/home" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/mybuilds" element={<MyBuilds />} />
          <Route path="/passwordreset" element={<PasswordReset />} />
          <Route path="/search" element={<Search />} />
          <Route path="/signup" element={<SignUp />} />
          <Route path="/tutorial" element={<Tutorial />} />
          <Route path="*" element={<Navigate to="/login" />} />
        </Routes>
      </Layout>
    </>
  );
}
/* return (<Routes>
<Route path="/accountdetails" element={<AccountDetails/>}/>
<Route path="/blog" element={<Blog/>}/>
<Route path="/compositioncreation" element={<CompositionCreation/>}/>
<Route path="/createaccount" element={<CreateAccount/>}/>
<Route path="/home" element={<Home/>}/>
<Route path="/login" element={<Login/>}/>
<Route path="/search" element={<Search/>}/>
<Route path="/signup" element={<SignUp/>}/>
<Route path="/tutorial" element={<Tutorial/>}/>
<Route path="*" element={<Navigate to="/home"/>}/>
  </Routes>) */

export default App;
