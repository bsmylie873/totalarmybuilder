import {
  Button,
  ButtonGroup,
  IconButton,
  List,
  ListItem,
  ListItemButton,
  ListItemText,
  MenuItem,
  Select,
  SelectChangeEvent,
  Stack,
  TextField,
} from "@mui/material";
import { useNavigate, useParams } from "react-router-dom";
import { Box } from "@mui/system";
import { useState, useEffect, useReducer } from "react";
import { CompositionService, FactionService } from "../../services";
import { NavigationRoutes } from "../../constants";
import { initialState, reducer } from "./compReducer";
import { Faction } from "../../types/faction";
import InputAdornment from "@mui/material/InputAdornment";
import toast from "react-hot-toast";
import { Unit } from "../../types/unit";
import { Composition } from "../../types/composition";
import DeleteIcon from "@mui/icons-material/Delete";

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

const Compositions = () => {
  var { compositionId } = useParams<{ compositionId: string }>();
  const [state, dispatch] = useReducer(reducer, initialState);
  const [unit, setUnit] = useState<Unit>();
  const [factions, setFactions] = useState<Faction[]>([]);
  const [dropdownData, setDropDownData] = useState<Unit[]>([]);

  const navigate = useNavigate();

  function conditionalButtons() {
    if (compositionId === undefined) {
      return (
        <>
          <Button
            variant="contained"
            color="secondary"
            onClick={() => {
              createComposition();
            }}
          >
            Create
          </Button>
          <Button
            variant="contained"
            color="error"
            onClick={() => {
              resetUnitList();
            }}
          >
            Reset Unit List
          </Button>
          <Button
            variant="outlined"
            color="primary"
            onClick={() => {
              navigate(NavigationRoutes.Home);
            }}
          >
            Cancel
          </Button>
        </>
      );
    } else {
      return (
        <>
          <Button
            variant="contained"
            color="success"
            onClick={() => {
              updateComposition(compositionId);
            }}
          >
            Save
          </Button>
          <Button
            variant="contained"
            color="error"
            onClick={() => {
              resetUnitList();
            }}
          >
            Reset Unit List
          </Button>
          <Button
            variant="outlined"
            color="error"
            onClick={() => {
              deleteComposition(compositionId);
            }}
          >
            Delete
          </Button>
          <Button
            variant="outlined"
            color="primary"
            onClick={() => {
              navigate(NavigationRoutes.Home);
            }}
          >
            Cancel
          </Button>
        </>
      );
    }
  }

  async function getCompositionData() {
    const compositionResponse = await CompositionService.getComposition(
      compositionId as string
    );
    if (compositionResponse.status === 200) {
      const composition = await compositionResponse.json();
      dispatch({ type: "SET_COMP", payload: composition });
    }
  }

  const createComposition = async () => {
    if (compositionId !== undefined) {
      toast.error("Cannot create a new composition.");
      return;
    }

    const newComposition: Composition = {
      name: state.name,
      battleType: state.battleType,
      factionId: state.factionId,
      avatarId: state.avatarId,
      budget: state.budget,
      dateCreated: state.dateCreated,
      wins: state.wins,
      losses: state.losses,
      units: state.units,
    };

    const response = await CompositionService.createComposition(newComposition);
    if (response.status === 201) {
      toast.success("New composition added!");
      navigate(NavigationRoutes.MyBuilds);
    } else {
      toast.error("Error creating the composition.");
    }
  };

  const updateComposition = async (compositionId: string | undefined) => {
    if (compositionId === undefined) {
      toast.error("Cannot update a composition that has not been created yet.");
      return;
    }
    debugger;

    const updateComposition: Composition = {
      id: Number(compositionId),
      name: state.name,
      battleType: state.battleType,
      factionId: state.factionId,
      avatarId: state.avatarId,
      budget: state.budget,
      dateCreated: state.dateCreated,
      wins: state.wins,
      losses: state.losses,
      units: state.units,
    };
    const response = await CompositionService.updateComposition(
      updateComposition
    );
    if (response.status === 204) {
      toast.success("Composition updated successfully!");
      window.location.reload();
    } else {
      toast.error("Error updating the composition.");
    }
  };

  const deleteComposition = async (compositionId: string | undefined) => {
    if (compositionId === undefined) {
      toast.error("Cannot delete a composition that has not been created yet.");
      return;
    }

    const response = await CompositionService.deleteComposition(compositionId);
    if (response.status === 204) {
      toast.success("Composition deleted successfully!");
      navigate(NavigationRoutes.Home);
    } else {
      toast.error("Error deleting the composition.");
    }
  };

  async function getFactionData() {
    const factionResponse = await FactionService.getFactions();
    if (factionResponse.status === 200) {
      const factionJSON = await factionResponse.json();
      setFactions(factionJSON);
    } else {
      toast.error("Error loading factions!");
    }
  }

  async function resetUnitList() {
    dispatch({ type: "RESET_UNIT_LIST" });
  }

  const handleChange = (event: SelectChangeEvent<typeof unit>) => {
    const {
      target: { value },
    } = event;
    setUnit(value as Unit);
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

  async function addWin(value: any, type: string) {
    dispatch({
      type: "ADD_WIN",
      payload: { value, type },
    });
  }

  async function subtractWin(value: any, type: string) {
    if (state.wins > 0) {
      dispatch({
        type: "REMOVE_WIN",
        payload: { value, type },
      });
    } else {
      toast.error("Cannot have a negative number of wins!");
    }
  }

  async function addLoss(value: any, type: string) {
    dispatch({
      type: "ADD_LOSS",
      payload: { value, type },
    });
  }

  async function subtractLoss(value: any, type: string) {
    if (state.losses > 0) {
      dispatch({
        type: "REMOVE_LOSS",
        payload: { value, type },
      });
    } else {
      toast.error("Cannot have a negative number of losses!");
    }
  }

  useEffect(() => {
    getCompositionData();
    getFactionData();
  }, []);

  useEffect(() => {
    getUnitByFactionData();
  }, [state.factionId]);

  useEffect(() => {
    console.log(state.units);
  }, [state.units]);

  return (
    <>
      <Stack
        direction="row"
        padding={3}
        alignItems="center"
        justifyContent="space-around"
      >
        <TextField
          id="outlined-name"
          label="Name"
          type="text"
          helperText="Please enter the name..."
          value={state.name}
          style={{ width: "60%" }}
          onChange={(e) => setStateValue(e.target.value, "name")}
        />
        <div>
          <TextField
            id="outlined-select-battle-type"
            select
            label="Battle Type"
            value={state.battleType}
            helperText="Please select the battle type..."
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
            label="Faction"
            value={state.factionId}
            helperText="Please select the faction..."
            onChange={(e) => setStateValue(e.target.value, "factionId")}
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
            label="Budget"
            value={state.budget}
            helperText="Please select the budget..."
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
          {dropdownData.map((option: Unit) => (
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
      </Stack>
      <br></br>
      <Box
        display="flex"
        justifyContent="space-around"
        alignItems="flex-end"
        width="100%"
        margin={0}
        alignSelf="center"
      >
        <h4>Wins:</h4>
        <ButtonGroup size="small" aria-label="win counter">
          <Button
            key="subtractWin"
            onClick={() => {
              subtractWin(undefined, "wins");
            }}
          >
            -
          </Button>
          <h4>{state.wins}</h4>
          <Button
            key="addWin"
            onClick={() => {
              addWin(undefined, "wins");
            }}
          >
            +
          </Button>
        </ButtonGroup>
        <h4>Losses:</h4>
        <ButtonGroup size="small" aria-label="loss counter">
          <Button
            key="subtractLoss"
            onClick={() => {
              subtractLoss(undefined, "losses");
            }}
          >
            -
          </Button>
          <h4>{state.losses}</h4>
          <Button
            key="addLoss"
            onClick={() => {
              addLoss(undefined, "losses");
            }}
          >
            +
          </Button>
        </ButtonGroup>
      </Box>
      <Box
        display="flex"
        justifyContent="space-around"
        alignItems="flex-end"
        width="100%"
        margin={5}
        alignSelf="center"
      >
        {conditionalButtons()}
      </Box>
    </>
  );
};

export default Compositions;
