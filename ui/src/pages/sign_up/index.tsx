import { Container, Stack, TextField, Button } from "@mui/material";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Title } from "../../components";

const Sign_up = () => {
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const navigate = useNavigate();

  const authentication = async () => {
    navigate("/login");
  };

  return (
    <>
      <Title title="Create A New Account" />
      <Container fixed>
        {
          <Stack spacing={2} style={{ marginTop: 50 }}>
            <TextField
              required
              id="outlined-required"
              label="Username"
              onChange={(e) => setUsername(e.target.value)}
              value={username}
            />
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
              onChange={(e) => setPassword(e.target.value)}
              value={password}
            />
            <TextField
              required
              id="outlined-required"
              label="Confirm Password"
              onChange={(e) => setPassword(e.target.value)}
              value={password}
            />
            <Button variant="contained" onClick={() => authentication()}>
              Create Account
            </Button>
          </Stack>
        }
      </Container>
    </>
  );
};

export default Sign_up;
