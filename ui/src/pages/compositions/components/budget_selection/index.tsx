import { Autocomplete, List, MenuItem, Stack, TextField } from "@mui/material";
import { useState } from "react";

const budgets = [
  {
    value: "0",
    label: "0",
  },
  {
    value: "9000",
    label: "9000",
  },
];

export default function BudgetSelection(_props: any) {
  const [budget, setBudget] = useState(_props.budget);

  const handleChange = (event: any) => {
    debugger;
    setBudget(event.target.value);
  };

  return (
    <div>
      <TextField
        id="outlined-select-budget"
        select
        label="Select"
        value={budget}
        helperText="Please select your budget"
        onChange={handleChange}
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
