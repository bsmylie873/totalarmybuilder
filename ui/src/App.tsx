import { Navigate, Route, Routes } from "react-router-dom";
import {
  AccountDetails,
  Blog,
  Composition,
  Home,
  Login,
  MyBuilds,
  PasswordReset,
  PasswordResetRequest,
  Search,
  SignUp,
  Tutorial
} from "./pages";
import "./styles.css";
import Layout from "./components/layout";
import { NavigationRoutes } from "./constants";
import { AuthContext } from "./contexts";
import { LoginUtils } from "./utils";
import { ThemeProvider, createTheme } from '@mui/material/styles';

const darkTheme = createTheme({
  palette: {
    mode: 'dark',
  },
});

const lightTheme = createTheme({
  palette: {
    mode: 'light',
  },
});

if (process.env.NODE_ENV === "development") {
  //const { worker } = require("./services/mocks/browser");
  //worker.start();
}

const authenticatedRoutes = () => {
  return (
    <>
      <Route path={NavigationRoutes.Home} element={<Home />} />
      <Route
        path={NavigationRoutes.AccountDetails}
        element={<AccountDetails />}
      />
      <Route path={NavigationRoutes.Blog} element={<Blog />} />
      <Route path={NavigationRoutes.Composition} element={<Composition />} />
      <Route path={NavigationRoutes.Home} element={<Home />} />
      <Route path={NavigationRoutes.MyBuilds} element={<MyBuilds />} />
      <Route
        path={NavigationRoutes.PasswordReset}
        element={<PasswordReset />}
      />
      <Route path={NavigationRoutes.Search} element={<Search />} />
      <Route path={NavigationRoutes.Tutorial} element={<Tutorial />} />
      <Route path="*" element={<Navigate to={NavigationRoutes.Home} />} />
    </>
  );
};

const unauthenticatedRoutes = () => {
  return (
    <>
      <Route path={NavigationRoutes.Login} element={<Login />} />
      <Route
        path={NavigationRoutes.PasswordResetRequest}
        element={<PasswordResetRequest />}
      />
      <Route path={NavigationRoutes.SignUp} element={<SignUp />} />
      <Route path="*" element={<Navigate to={NavigationRoutes.Login} />} />
    </>
  );
};

function App() {
  const { state } = AuthContext.useLogin();
  const loggedIn = state.accessToken && !LoginUtils.isTokenExpired(state);
  return (
    <>
    <ThemeProvider theme ={lightTheme}>
      <Layout>
        <Routes>
          {!loggedIn && unauthenticatedRoutes()}
          {loggedIn && authenticatedRoutes()}
        </Routes>
      </Layout>
      </ThemeProvider>
    </>
  );
}

export default App;
