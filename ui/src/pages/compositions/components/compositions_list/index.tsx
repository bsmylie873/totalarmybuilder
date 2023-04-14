import {
  Box,
  IconButton,
  InputAdornment,
  List,
  ListItem,
  ListItemButton,
  ListItemText,
  MenuItem,
  Select,
  SelectChangeEvent,
} from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import { CompContext } from "../../../../contexts";
import { useState } from "react";
import { Unit } from "../../../../types/unit";

interface IProps {
  factionUnits: Unit[];
}

function CompositionsList({ factionUnits }: IProps) {
  const { state, dispatch } = CompContext.useCurrentComposition();
  const [unit, setUnit] = useState<Unit>();

  const handleChange = (event: SelectChangeEvent<typeof unit>) => {
    const {
      target: { value },
    } = event;
    setUnit(value as Unit);
  };

  async function addUnit(unParsedValue: any, type: string) {
    if (unParsedValue === undefined || state.units.length >= 20) {
      return;
    }
    let value = JSON.parse(unParsedValue) as Unit;
    dispatch({
      type: "ADD_TO_UNIT_LIST",
      payload: { value, type },
    });
  }

  async function removeUnit(value: any, type: string) {
    if (value === undefined || state.units.length <= 0) {
      return;
    }
    dispatch({
      type: "REMOVE_UNIT_FROM_UNIT_LIST",
      payload: { value, type },
    });
  }

  return (
    <>
      <Select
        id="primary-unit-selection"
        label="Select"
        sx={{ width: "100%" }}
        onChange={handleChange}
        value={unit || ""}
        endAdornment=<InputAdornment position="end">
          <IconButton
            aria-label="addUnit"
            onClick={() => addUnit(unit, "Unit")}
            edge="start"
          >
            +
          </IconButton>
        </InputAdornment>
      >
        {factionUnits.map((option: Unit) => (
          <MenuItem
            style={{
              justifyContent: "space-between",
              alignItems: "flex-end",
            }}
            divider
            key={option.id}
            value={JSON.stringify({
              id: option.id,
              name: option.name,
              cost: option.cost,
              avatarId: option.avatarId,
            })}
          >
            {option.name} {"Cost: " + option.cost}
          </MenuItem>
        ))}
      </Select>
      <Box sx={{ height: "100%", width: "100%", overflow: "auto" }}>
        <List dense>
          {state.units?.map((unit: Unit) => (
            <ListItem
              divider
              key={unit.id}
              secondaryAction={
                <IconButton
                  edge="end"
                  aria-label="delete"
                  onClick={() => removeUnit(unit, "Unit")}
                >
                  <DeleteIcon />
                </IconButton>
              }
            >
              <ListItemButton dense>
                <ListItemText
                  primary={unit.name}
                  secondary={"Cost: " + unit.cost}
                />
              </ListItemButton>
            </ListItem>
          ))}
        </List>
      </Box>
    </>
  );
}

export default CompositionsList;
