import { MenuItem, TextField } from "@mui/material";
import { useReducer } from "react";
import { reducer } from "../../compReducer";
import IProps from "../compInterface";

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

const BattleTypeSelection: React.FC<IProps> = ({ composition }) => {
  const [state, dispatch] = useReducer(reducer, composition);

  function setStateValue(value: any, type: string) {
    debugger;
    dispatch({ type: "SET_VALUE", payload: { value, type } });
  }

  return (
    <div>
      <TextField
        id="outlined-select-battle-type"
        select
        label="Battle Type"
        value={state.battleType}
        helperText="Please select your battle type"
        onChange={(e) => setStateValue(e.target.value, "battleType")}
      >
        {battleTypes.map((option) => (
          <MenuItem key={option.value} value={option.value}>
            {option.label}
          </MenuItem>
        ))}
      </TextField>
    </div>
  );
};

export default BattleTypeSelection;
