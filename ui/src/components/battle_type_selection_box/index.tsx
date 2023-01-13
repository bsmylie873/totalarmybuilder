import { Autocomplete, List, MenuItem, Stack, TextField } from "@mui/material";

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

export default function BattleTypeSelection() {
  return (
    <div>
      <TextField
        id="outlined-select-battle-type"
        select
        label="Select"
        defaultValue="Domination"
        helperText="Please select your battle type"
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
