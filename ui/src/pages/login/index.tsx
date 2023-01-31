import { Container, Stack, TextField, Button, Grid } from "@mui/material";
import React, { useState } from "react";
import toast from "react-hot-toast";
import { useNavigate } from "react-router-dom";
import { Title } from "../../components";
import { NavigationRoutes, StorageTypes } from "../../constants";
import { AuthContext } from "../../contexts";
import { AuthenticationService, StorageService } from "../../services";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const { dispatch } = AuthContext.useLogin();

  const navigate = useNavigate();

  const authentication = async () => {
    const response = await AuthenticationService.authenticate(email, password);
    if (response.status === 200) {
      const loginResult = await response.json();
      StorageService.setLocalStorage(loginResult, StorageTypes.AUTH);
      StorageService.setLocalStorage(email, StorageTypes.EMAIL);
      dispatch({
        type: "authentication",
        ...loginResult,
      });
      toast.success("Successfully logged in!");
      navigate(NavigationRoutes.Home);
    } else if (response.status === 401) {
      toast.error("Failed to logged in!");
      navigate(NavigationRoutes.Login);
    }
  };

  return (
    <>
      <Title title="Login" />
      <Container fixed>
        {
          <Stack spacing={2} style={{ marginTop: 50 }}>
            <TextField
              required
              id="outlined-required"
              label="Email"
              onChange={(e) => setEmail(e.target.value)}
              value={email}
            />
            <TextField
              required
              id="outlined-required"
              label="Password"
              type="password"
              onChange={(e) => setPassword(e.target.value)}
              onKeyUp={(e) => {
                if (e.key === "Enter") {
                  authentication();
                }
              }}
              value={password}
            />
            <Button variant="contained" onClick={() => authentication()}>
              Login
            </Button>
            <Button
              variant="contained"
              onClick={() => navigate(NavigationRoutes.SignUp)}
            >
              Sign Up
            </Button>
            <Button
              variant="contained"
              onClick={() => navigate(NavigationRoutes.PasswordResetRequest)}
            >
              Forgot Password?
            </Button>
          </Stack>
        }
      </Container>
    </>
  );
};

export default Login;
