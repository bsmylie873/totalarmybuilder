import { Container, Stack, TextField, Button, Grid } from "@mui/material";
import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { Title } from "../../components";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const navigate = useNavigate();

  const authentication = async () => {
    navigate("/home");
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
            <Button variant="contained" onClick={() => navigate("/signup")}>
              Sign Up
            </Button>
            <Button
              variant="contained"
              onClick={() => navigate("/passwordreset")}
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
