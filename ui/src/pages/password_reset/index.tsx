import { Container, Stack, TextField, Button } from "@mui/material";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Title } from "../../components";

const Password_reset = () => {
  const [password, setPassword] = useState("");

  const navigate = useNavigate();

  const authentication = async () => {
    navigate("/login");
  };

  return (
    <>
      <Title title="Reset Password" />
      <Container fixed>
        {
          <Stack spacing={2} style={{ marginTop: 50 }}>
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
              Reset Password
            </Button>
          </Stack>
        }
      </Container>
    </>
  );
};

export default Password_reset;
