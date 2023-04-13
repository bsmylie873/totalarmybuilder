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
  Tutorial,
} from "./pages";
import "./styles.css";
import Layout from "./components/layout";
import { NavigationRoutes } from "./constants";
import { AuthContext, ThemeContext } from "./contexts";
import CompProvider from "./contexts/composition";
import { LoginUtils } from "./utils";
import { createTheme, ThemeProvider } from "@mui/material";
import useMediaQuery from "@mui/material/useMediaQuery";
import { useEffect, useMemo, useState } from "react";
import { themes } from "./contexts/theme";
import { CompContext } from "./contexts";

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
  const prefersDarkMode = useMediaQuery("(prefers-color-scheme: dark)");
  const { state } = AuthContext.useLogin();
  const loggedIn = state.accessToken && !LoginUtils.isTokenExpired(state);
  const [mode, setMode] = useState(themes[0].theme);

  const colorMode = useMemo(
    () => ({
      setColorMode: () => {
        setMode((prevMode) =>
          prevMode === themes[0].theme ? themes[1].theme : themes[0].theme
        );
      },
    }),
    []
  );

  const theme = useMemo(() => createTheme({ palette: mode.palette }), [mode]);

  useEffect(() => {
    if (prefersDarkMode) {
      setMode((prevMode) => (prevMode = themes[1].theme));
    }
  }, [prefersDarkMode]);

  return (
    <>
      <ThemeContext.Provider value={colorMode}>
        <ThemeProvider theme={theme}>
          <CompContext.CompProvider>
            <Layout>
              <Routes>
                {!loggedIn && unauthenticatedRoutes()}
                {loggedIn && authenticatedRoutes()}
              </Routes>
            </Layout>
          </CompContext.CompProvider>
        </ThemeProvider>
      </ThemeContext.Provider>
    </>
  );
}

export default App;
