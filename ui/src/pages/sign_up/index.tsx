import { Title } from "../../components";
import React, { useReducer, useState } from "react";
import { useNavigate } from "react-router-dom";
import { AccountService } from "../../services";
import { Account } from "../../types/account";
import { TextField, Button } from "@mui/material";
import { Container, Stack } from "@mui/system";

interface NewAccount extends Account {
  confirmPassword: string;
}

const initialAccount: NewAccount = {
  email: "",
  username: "",
  password: "",
  confirmPassword: "",
  avatar: "",
};

const accountReducer = (state: NewAccount, action: any) => {
  switch (action.type) {
    case "Update":
      return {
        ...state,
        [action.field]: action.value,
      };
    default:
      return state;
  }
};

const SignUp = () => {
  const [newUser, dispatch] = useReducer(accountReducer, initialAccount);

  const navigate = useNavigate();

  const onAddAccount = async () => {
    const response = await AccountService.createAccount(newUser);
    if (response.status === 201) {
      navigate("/login");
    }
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
              onChange={(e) =>
                dispatch({
                  value: e.target.value,
                  type: "Update",
                  field: "username",
                })
              }
              value={newUser.username}
            />
            <TextField
              required
              id="outlined-required"
              label="Email"
              onChange={(e) =>
                dispatch({
                  value: e.target.value,
                  type: "Update",
                  field: "email",
                })
              }
              value={newUser.email}
            />
            <TextField
              required
              id="outlined-required"
              label="Password"
              onChange={(e) =>
                dispatch({
                  value: e.target.value,
                  type: "Update",
                  field: "password",
                })
              }
              value={newUser.password}
            />
            <TextField
              required
              id="outlined-required"
              label="Confirm Password"
              onChange={(e) =>
                dispatch({
                  value: e.target.value,
                  type: "Update",
                  field: "confirmPassword",
                })
              }
              value={newUser.confirmPassword}
            />
            <Button variant="contained" onClick={() => onAddAccount()}>
              Create Account
            </Button>
          </Stack>
        }
      </Container>
    </>
  );
};
export default SignUp;
