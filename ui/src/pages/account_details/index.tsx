import { Container, Stack, TextField, Button } from "@mui/material";
import { useEffect, useState } from "react";
import { LoginUtils } from "../../utils";
import { useNavigate } from "react-router-dom";
import { AccountService } from "../../services";
import { Account } from "../../types/account";
import toast from "react-hot-toast";
import { AuthContext } from "../../contexts";
import { NavigationRoutes } from "../../constants";

const AccountDetails = () => {
  const [account, setAccount] = useState({
    id: null,
    username: "",
    email: "",
    password: null,
    avatar: "",
  });
  const [email, setEmail] = useState("");
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [errorState, setErrorState] = useState({
    password: false,
  });
  const navigate = useNavigate();

  const { state } = AuthContext.useLogin();
  const { dispatch } = AuthContext.useLogin();
  const accountId = LoginUtils.getAccountId(state.accessToken);

  const getAccountData = async (accountId: string) => {
    const accountResponse = await AccountService.getAccount(accountId);
    if (accountResponse.status === 200) {
      const account = await accountResponse.json();
      setAccount(account);
    }
  };

  const editAccountClicked = async () => {
    const formErrors = {
      password: password === "",
    };
    setErrorState(formErrors);

    if (!formErrors.password) {
      var account: Account = {
        id: accountId,
        username: username,
        email: email,
        password: password,
        avatar: "",
      };
      const response = await AccountService.updateAccount(account);
      if (response.status == 200) {
        setPassword("");
        toast.success("Profile updated");
        localStorage.clear();
        dispatch({ type: "logout" });
        navigate(NavigationRoutes.Login);
      } else {
        toast.error("Profile failed to update");
      }
    }
  };

  useEffect(() => {
    getAccountData(accountId);
  }, []);

  return (
    <>
      <Container fixed>
        {
          <Stack spacing={2}>
            <br></br>
            <h3>Current username: {account.username}</h3>
            <TextField
              id="outlined-required"
              label="New username..."
              type="text"
              defaultValue={account.username}
              onChange={(e) => setUsername(e.target.value)}
            />
            <h3>Current email: {account.email}</h3>
            <TextField
              id="outlined-required"
              label="New email..."
              type="email"
              defaultValue={account.email}
              onChange={(e) => setEmail(e.target.value)}
            />
            <h3>Enter your new password:</h3>
            <TextField
              required
              id="outlined-required"
              label="New password:"
              type="password"
              defaultValue={account.password}
              onChange={(e) => setPassword(e.target.value)}
            />
            <Button variant="contained" onClick={() => editAccountClicked()}>
              Edit Account
            </Button>
            <Button
              variant="contained"
              onClick={() => navigate(NavigationRoutes.Home)}
            >
              Cancel
            </Button>
          </Stack>
        }
      </Container>
    </>
  );
};

export default AccountDetails;
