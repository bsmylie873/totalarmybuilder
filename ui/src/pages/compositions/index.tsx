import {
  Avatar,
  Button,
  Chip,
  IconButton,
  List,
  ListItem,
  ListItemAvatar,
  ListItemButton,
  ListItemText,
  MenuItem,
  OutlinedInput,
  Select,
  SelectChangeEvent,
  Stack,
  TextField,
} from "@mui/material";
import { useNavigate, useParams } from "react-router-dom";
import ClearIcon from "@mui/icons-material/Clear";
import {
  BattleTypeSelection,
  BudgetSelection,
  FactionSelection,
  SecondaryUnitList,
} from "../../components";
import { Box } from "@mui/system";
import { useState, useEffect, useReducer } from "react";
import { CompositionService, FactionService } from "../../services";
import { NavigationRoutes } from "../../constants";
import { Composition } from "../../types/composition";
import { initialState, reducer } from "./compReducer";
import { Faction } from "../../types/faction";
import InputAdornment from "@mui/material/InputAdornment";
import toast from "react-hot-toast";
import { Unit } from "../../types/unit";
import { AddBusinessOutlined } from "@mui/icons-material";

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

const Compositions = () => {
  var { compositionId } = useParams<{ compositionId: string }>();
  const [state, dispatch] = useReducer(reducer, initialState);
  const [unit, setUnit] = useState<string[]>([]);
  const [factions, setFactions] = useState<Faction[]>([]);
  const [dropdownData, setDropDownData] = useState<Unit[]>([]);

  const navigate = useNavigate();

  async function getCompositionData() {
    const compositionResponse = await CompositionService.getComposition(
      compositionId as string
    );
    if (compositionResponse.status === 200) {
      const composition = await compositionResponse.json();
      dispatch({ type: "SET_COMP", payload: composition });
    }
  }

  async function getFactionData() {
    const factionResponse = await FactionService.getFactions();
    if (factionResponse.status === 200) {
      const factionJSON = await factionResponse.json();
      setFactions(factionJSON);
    } else {
      toast.error("Error loading factions!");
    }
  }

  const handleChange = (event: SelectChangeEvent<typeof unit>) => {
    const {
      target: { value },
    } = event;
    setUnit(
      // On autofill we get a stringified value.
      typeof value === "string" ? value.split(",") : value
    );
  };

  async function getUnitByFactionData() {
    if (state.factionId != null) {
      const factionUnitReponse = await FactionService.getFactionUnits(
        state.factionId
      );
      if (factionUnitReponse.status === 200) {
        const factionUnits = await factionUnitReponse.json();
        const factionsUnitsMapped = factionUnits.flatMap((x: any) => {
          return {
            id: x.id,
            name: x.name,
            cost: x.cost,
            avatarId: x.avatarId,
          };
        });
        setDropDownData(factionsUnitsMapped);
      }
    } else {
      toast.error("Error loading units!");
    }
  }

  function setStateValue(value: any, type: string) {
    dispatch({ type: "SET_VALUE", payload: { value, type } });
  }

  function setStateValueAndClear(value: any, type: string) {
    dispatch({ type: "SET_VALUE", payload: { value, type } });
    dispatch({ type: "RESET_UNIT_LIST", payload: { value, type } });
  }

  useEffect(() => {
    getCompositionData();
    getFactionData();
  }, []);

  useEffect(() => {
    getUnitByFactionData();
  }, [state.factionId]);

  return (
    <>
      <Stack
        direction="row"
        padding={5}
        alignItems="center"
        justifyContent="space-around"
      >
        <h2>Name:</h2>
        <TextField
          id="outlined-required"
          label=""
          type="text"
          value={state.name}
          onChange={(e) => setStateValue(e.target.value, "name")}
          fullWidth
        />
      </Stack>
      <Stack
        direction="row"
        spacing={1}
        alignItems="center"
        justifyContent="space-around"
      >
        <div>
          <TextField
            id="outlined-select-battle-type"
            select
            label="Select"
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
        <div>
          <TextField
            id="outlined-select-faction"
            select
            label="Select"
            value={state.factionId}
            helperText="Please select your faction"
            onChange={(e) => setStateValueAndClear(e.target.value, "factionId")}
          >
            {factions.map((option) => (
              <MenuItem key={option.id} value={option.id}>
                {option.name}
              </MenuItem>
            ))}
          </TextField>
        </div>
        <div>
          <TextField
            id="outlined-select-budget"
            select
            label="Select"
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
      </Stack>
      <Stack
        sx={{
          display: "flex",
          justifyContent: "center",
          width: "100%",
          bgcolor: "background.paper",
        }}
      >
        <h4>Primary Army:</h4>
        <Select
          id="primary-unit-selection"
          label="Select"
          sx={{ width: "100%" }}
          onChange={handleChange}
          value={unit}
          endAdornment=<InputAdornment position="end">
            <IconButton
              aria-label="addUnit"
              onClick={(e) => setStateValue(unit, "unitList")}
              edge="start"
            >
              +
            </IconButton>
          </InputAdornment>
          renderValue={(selected: any) => (
            <Box sx={{ display: "flex", flexWrap: "wrap", gap: 0.5 }}>
              {selected.map((value: any) => (
                <Chip key={value} label={value} />
              ))}
            </Box>
          )}
        >
          {dropdownData.map((option: Unit) => (
            <MenuItem key={option.id} value={option.name}>
              {option.name} {option.cost}
            </MenuItem>
          ))}
        </Select>
        <Box sx={{ height: 400, width: "100%", overflow: "auto" }}>
          <List dense>
            {state?.unitList?.map((item: Unit) => (
              <ListItem key={item.id}>
                <ListItemButton>
                  <ListItemText primary={item.name} />
                </ListItemButton>
              </ListItem>
            ))}
          </List>
        </Box>
      </Stack>
      <br></br>
      <SecondaryUnitList />
      <Stack direction="row" spacing={2}></Stack>
      <Box
        display="flex"
        justifyContent="space-around"
        alignItems="flex-end"
        width="100%"
        margin={5}
        alignSelf="center"
      >
        <Button variant="contained" color="success">
          Save
        </Button>
        <Button
          variant="outlined"
          color="error"
          onClick={() => navigate(NavigationRoutes.Home)}
        >
          Cancel
        </Button>
      </Box>
    </>
  );
};

export default Compositions;
