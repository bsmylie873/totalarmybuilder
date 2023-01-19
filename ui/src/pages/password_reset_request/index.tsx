import { Container, Stack, TextField, Button } from "@mui/material";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Title } from "../../components";

const Password_reset_request = () => {
  const [email, setEmail] = useState("");

  const navigate = useNavigate();

  const authentication = async () => {
    navigate("/login");
  };

  return (
    <>
      <Title title="Reset Password Form" />
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
            <Button variant="contained" onClick={() => authentication()}>
              Send Reset Password Email
            </Button>
          </Stack>
        }
      </Container>
    </>
  );
};

export default Password_reset_request;
