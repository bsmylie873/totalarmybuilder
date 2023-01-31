import { MenuItem, TextField } from "@mui/material";
import { useState } from "react";

const battleTypes = [
  {
    value: "Domination",
    label: "Domination",
  },
  {
    value: "Land Battles",
    label: "Land Battles",
  },
];

export default function BattleTypeSelection(_props: any) {
  const [battleType, setBattleType] = useState(_props.battleType);

  const handleChange = (event: any) => {
    debugger;
    setBattleType(event.target.value);
  };

  return (
    <div>
      <TextField
        id="outlined-select-battle-type"
        select
        label="Select"
        value={battleType}
        helperText="Please select your battle type"
        onChange={handleChange}
      >
        {battleTypes.map((option) => (
          <MenuItem key={option.value} value={option.value}>
            {option.label}
          </MenuItem>
        ))}
      </TextField>
    </div>
  );
}
