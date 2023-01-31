import { MenuItem, TextField } from "@mui/material";
import { useEffect, useState } from "react";
import { Faction } from "../../../../types/faction";
import { FactionService } from "../../../../services";

export default function FactionSelection(_props: any) {
  const [dropdownData, setDropDownData] = useState([]);
  const [faction, setFaction] = useState(_props.faction);

  async function getFactionData() {
    const factionResponse = await FactionService.getFactions();
    if (factionResponse.status === 200) {
      const factions = await factionResponse.json();
      setDropDownData(factions);
    }
  }

  const handleChange = (event: any) => {
    debugger;
    setFaction(event.target.value);
  };

  useEffect(() => {
    getFactionData();
  }, []);

  return (
    <div>
      <TextField
        id="outlined-select-faction"
        select
        label="Select"
        value={faction}
        helperText="Please select your faction"
        onChange={handleChange}
      >
        {dropdownData.map((option: Faction) => (
          <MenuItem key={option.id} value={option.name}>
            {option.name}
          </MenuItem>
        ))}
      </TextField>
    </div>
  );
}
