import { styled, alpha } from "@mui/material/styles";
import {
  AppBar as MuiAppBar,
  Box,
  IconButton,
  InputBase,
  Stack,
  Toolbar,
  Typography,
} from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import AccountCircle from "@mui/icons-material/AccountCircle";
import NavigationDrawer from "../navigation_drawer";
import LogoutIcon from "@mui/icons-material/Logout";
import Brightness4Icon from "@mui/icons-material/Brightness4";
import { createSearchParams, useNavigate } from "react-router-dom";
import { NavigationRoutes } from "../../constants";
import { AuthContext, ThemeContext } from "../../contexts";
import { useContext, useState } from "react";

const Search = styled("div")(({ theme }) => ({
  padding: 1,
  position: "relative",
  backgroundColor: alpha(theme.palette.common.white, 0.15),
  "&:hover": {
    backgroundColor: alpha(theme.palette.common.white, 0.25),
  },
  width: "100%",
}));

const StyledInputBase = styled(InputBase)(({ theme }) => ({
  color: "inherit",
  "& .MuiInputBase-input": {
    padding: theme.spacing(1, 1, 1, 1),
    width: "100%",
  },
}));

export default function PrimarySearchAppBar() {
  const [searched, setSearched] = useState<string>("");
  const themeSelection = useContext(ThemeContext);
  const { dispatch } = AuthContext.useLogin();

  const navigate = useNavigate();

  const handleSearch = () => {
    navigate({
      pathname: NavigationRoutes.Search,
      search: createSearchParams({ query: searched }).toString(),
    });
  };

  const handleAccountDetails = () => {
    navigate(NavigationRoutes.AccountDetails);
  };

  const handleLogOut = () => {
    localStorage.clear();
    dispatch({ type: "logout" });
    navigate(NavigationRoutes.Login);
  };

  return (
    <Box sx={{ flexGrow: 1 }}>
      <MuiAppBar position="static">
        <Toolbar>
          <NavigationDrawer />
          <Typography
            padding={1}
            variant="h6"
            component="div"
            sx={{ display: { xs: "none", sm: "block" } }}
          >
            TotalArmyBuilder
          </Typography>
          <Search>
            <StyledInputBase
              fullWidth={true}
              placeholder="Search…"
              inputProps={{ "aria-label": "search" }}
              defaultValue=""
              onChange={(event) => setSearched(event.target.value)}
            />
          </Search>
          <IconButton type="submit" aria-label="search" onClick={handleSearch}>
            <SearchIcon style={{ fill: "white" }} />
          </IconButton>

          <IconButton>
            <Brightness4Icon
              style={{ fill: "white" }}
              onClick={themeSelection.setColorMode}
            />
          </IconButton>
          <Stack direction="row">
            <IconButton
              onClick={handleAccountDetails}
              size="large"
              edge="end"
              aria-label="account of current user"
              color="inherit"
            >
              <AccountCircle />
            </IconButton>
            <IconButton
              onClick={handleLogOut}
              size="large"
              edge="end"
              aria-label="log out"
              color="inherit"
            >
              <LogoutIcon />
            </IconButton>
          </Stack>
        </Toolbar>
      </MuiAppBar>
    </Box>
  );
}
