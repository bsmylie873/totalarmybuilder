import React from "react";
import { AuthContext } from "../../contexts";
import { LoginUtils } from "../../utils";
import PrimarySearchAppBar from "../topbar";

interface IProps {
  children: React.ReactNode;
}

function LoggedStatus() {
  const { state } = AuthContext.useLogin();
  const loggedIn = state.accessToken && !LoginUtils.isTokenExpired(state);
  if (loggedIn) {
    return <PrimarySearchAppBar />;
  }
}

const Layout = ({ children }: IProps) => {
  return (
    <>
      <header>{LoggedStatus()}</header>
      <main>{children}</main>
    </>
  );
};

export default Layout;
