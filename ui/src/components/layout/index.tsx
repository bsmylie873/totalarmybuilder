import { AppBar } from "@mui/material";
import React from "react";
import CompositionGrid from "../composition_grid";
import Title from "../title";
import PrimarySearchAppBar from "../topbar";

interface IProps {
  children: React.ReactNode;
}

const Layout = ({ children }: IProps) => {
  return (
    <>
      <header>
        <PrimarySearchAppBar></PrimarySearchAppBar>
        <Title title={"TotalArmyBuilder"} />
      </header>
      <main>{children}</main>
    </>
  );
};

export default Layout;
