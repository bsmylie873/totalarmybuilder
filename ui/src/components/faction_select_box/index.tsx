import * as React from "react";
import Box from "@mui/material/Box";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemText from "@mui/material/ListItemText";
import { FixedSizeList, ListChildComponentProps } from "react-window";
import { Autocomplete, List, MenuItem, Stack, TextField } from "@mui/material";

const factions = [
  {
    value: "Beastmen",
    label: "Beastmen",
  },
  {
    value: "Bretonnia",
    label: "Bretonnia",
  },
];

export default function FactionSelection() {
  return (
    <div>
      <TextField
        id="outlined-select-faction"
        select
        label="Select"
        defaultValue="Beastmen"
        helperText="Please select your faction"
      >
        {factions.map((option) => (
          <MenuItem key={option.value} value={option.value}>
            {option.label}
          </MenuItem>
        ))}
      </TextField>
    </div>
  );
}
