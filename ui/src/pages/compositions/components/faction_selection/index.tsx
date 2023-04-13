import { MenuItem, TextField } from "@mui/material";
import { useEffect, useState } from "react";
import { Faction } from "../../../../types/faction";
import { FactionService } from "../../../../services";
import { CompContext } from "../../../../contexts";

function FactionSelection() {
  const { state, dispatch } = CompContext.useCurrentComposition();
  const [dropdownData, setDropDownData] = useState<Faction[]>([]);

  function setStateValue(value: any, type: string) {
    debugger;
    dispatch({ type: "SET_VALUE", payload: { value, type } });
  }

  async function getFactionData() {
    const factionResponse = await FactionService.getFactions();
    if (factionResponse.status === 200) {
      const factions = await factionResponse.json();
      setDropDownData(factions);
    }
  }

  useEffect(() => {
    getFactionData();
  }, []);

  return (
    <div>
      <TextField
        id="outlined-select-faction"
        select
        label="Faction"
        value={state.factionId}
        helperText="Please select your faction"
        onChange={(e) => setStateValue(e.target.value, "factionId")}
      >
        {dropdownData.map((option) => (
          <MenuItem key={option.id} value={option.id}>
            {option.name}
          </MenuItem>
        ))}
      </TextField>
    </div>
  );
}

export default FactionSelection;
