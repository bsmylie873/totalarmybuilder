import { MenuItem, TextField } from "@mui/material";
import { CompContext } from "../../../../contexts";

const budgets = [
  {
    value: 0,
    label: "0",
  },
  {
    value: 2000,
    label: "2000",
  },
  {
    value: 4000,
    label: "4000",
  },
  {
    value: 6000,
    label: "6000",
  },
  {
    value: 8000,
    label: "8000",
  },
  {
    value: 10000,
    label: "10000",
  },
  {
    value: 12000,
    label: "12000",
  },
  {
    value: 14000,
    label: "14000",
  },
  {
    value: 16000,
    label: "16000",
  },
  {
    value: 18000,
    label: "18000",
  },
  {
    value: 20000,
    label: "20000",
  },
];

function BudgetSelection() {
  const { state, dispatch } = CompContext.useCurrentComposition();

  function setStateValue(value: any, type: string) {
    debugger;
    dispatch({ type: "SET_VALUE", payload: { value, type } });
  }

  return (
    <div>
      <TextField
        id="outlined-select-budget"
        select
        label="Budget"
        value={state.budget}
        helperText="Please select your budget"
        onChange={(e) => setStateValue(e.target.value, "budget")}
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

export default BudgetSelection;
