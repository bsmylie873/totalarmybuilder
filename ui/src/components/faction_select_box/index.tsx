import { MenuItem, TextField } from "@mui/material";
import { useState } from "react";
import { useParams } from "react-router-dom";
import { Faction } from "../../types/faction";
import useSWR from "swr";

const factions = [
  {
    id: 1,
    name: "Beastmen",
  },
  {
    id: 2,
    name: "Bretonnia",
  },
];

export default function FactionSelection() {
  function getFactions() {
    return fetch("/factions/").then((response) => response.json());
  }

  const { data, error, isLoading } = useSWR(["factions"], getFactions);

  console.log(data);
  return (
    <div>
      <TextField
        id="outlined-select-faction"
        select
        label="Select"
        defaultValue="Beastmen"
        helperText="Please select your faction"
      >
        {factions.map((option: Faction) => (
          <MenuItem key={option.id} value={option.name}>
            {option.name}
          </MenuItem>
        ))}
      </TextField>
    </div>
  );
}
