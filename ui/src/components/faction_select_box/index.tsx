import { MenuItem, TextField } from "@mui/material";
import { useEffect, useState } from "react";
import { Faction } from "../../types/faction";
import { FactionService } from "../../services";

export default function FactionSelection() {
  const [dropdownData, setDropDownData] = useState([]);

  async function getFactionData() {
    const factionResponse = await FactionService.getFactions();
    if (factionResponse.status === 200) {
      const factions = await factionResponse.json();
      const factionsMapped = factions.flatMap((x: any) => {
        return {
          id: x.id,
          name: x.name,
        };
      });
      setDropDownData(factionsMapped);
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
        label="Select"
        defaultValue="Beastmen"
        helperText="Please select your faction"
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
