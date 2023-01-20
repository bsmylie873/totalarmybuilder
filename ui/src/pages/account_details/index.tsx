import { Container, Stack, TextField, Button } from "@mui/material";
import React, { useReducer, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Title } from "../../components";
import { AccountService } from "../../services";
import { Account } from "../../types/account";
import { EditText, EditTextarea } from "react-edit-text";

const currentAccount: Account = {
  email: "",
  username: "",
  password: "",
  avatar: "",
};

const accountReducer = (state: Account, action: any) => {
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

const AccountDetails = () => {
  const { accountId } = useParams<{ accountId: string }>();
  console.log(accountId);
  const [existingUser, dispatch] = useReducer(accountReducer, currentAccount);

  const navigate = useNavigate();

  const onEditAccount = async () => {
    const response = await AccountService.createAccount(existingUser);
    if (response.status === 201) {
      navigate("/home");
    }
  };

  return (
    <>
      <Title title="Account Details" />
      <Container fixed>
        {
          <Stack spacing={2} style={{ marginTop: 50 }}>
            <EditText
              name="textbox3"
              defaultValue="I am an editable text with an edit button"
              editButtonProps={{ style: { marginLeft: "5px", width: 16 } }}
              showEditButton
            />

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
              value={existingUser.username}
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
              value={existingUser.email}
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
              value={existingUser.password}
            />
            <Button variant="contained" onClick={() => authentication()}>
              Create Account
            </Button>
            <Button variant="contained" onClick={() => authentication()}>
              Cancel
            </Button>
          </Stack>
        }
      </Container>
    </>
  );
};

export default AccountDetails;
function authentication(): void {
  throw new Error("Function not implemented.");
}
