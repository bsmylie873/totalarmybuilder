import { MenuItem, TextField } from "@mui/material";
import { CompContext } from "../../../../contexts";

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

function BattleTypeSelection() {
  const { state, dispatch } = CompContext.useCurrentComposition();

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
}

export default BattleTypeSelection;

/* export default function BattleTypeSelection(_props: any) {
  const value = useContext(Com)

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
} */
