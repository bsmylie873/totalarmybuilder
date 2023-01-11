import React from "react";

interface props {
  title: string;
}

const SecondaryArmy = ({ title }: props) => (
  <h1 style={{ textAlign: "center" }}>{title}</h1>
);

export default SecondaryArmy;
