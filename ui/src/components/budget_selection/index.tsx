import { Autocomplete, List, MenuItem, Stack, TextField } from "@mui/material";

const budgets = [
  {
    value: "0",
    label: "0",
  },
  {
    value: "10000",
    label: "10000",
  },
];

export default function BudgetSelection() {
  return (
    <div>
      <TextField
        id="outlined-select-budget"
        select
        label="Select"
        defaultValue="0"
        helperText="Please select your budget"
      >
        {budgets.map((option) => (
          <MenuItem key={option.value} value={option.value}>
            {option.label}
          </MenuItem>
        ))}
      </TextField>
    </div>
  );
}
