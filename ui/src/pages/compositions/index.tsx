import { Button, Grid, Stack, TextField } from "@mui/material";
import { useNavigate, useParams } from "react-router-dom";
import { Box } from "@mui/system";
import { useState, useEffect, useCallback } from "react";
import { CompositionService, FactionService } from "../../services";
import { NavigationRoutes } from "../../constants";
import toast from "react-hot-toast";
import { Unit } from "../../types/unit";
import { Composition } from "../../types/composition";
import {
  BattleTypeSelection,
  BudgetSelection,
  CompositionsList,
  FactionSelection,
  LossCounter,
  WinCounter,
} from "./components";
import { CompContext } from "../../contexts";

const Compositions = () => {
  var { compositionId } = useParams<{ compositionId: string }>();
  const { state, dispatch } = CompContext.useCurrentComposition();

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

  const getCompositionData = useCallback(async () => {
    const compositionResponse = await CompositionService.getComposition(
      compositionId as string
    );
    if (compositionResponse.status === 200) {
      const composition = await compositionResponse.json();
      dispatch({ type: "SET_COMP", payload: composition });
    }
  }, [compositionId, dispatch]);

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

  const resetUnitList = useCallback(async () => {
    dispatch({ type: "RESET_UNIT_LIST" });
  }, [dispatch]);

  const getUnitByFactionData = useCallback(async () => {
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
  }, [state.factionId]);

  function setStateValue(value: any, type: string) {
    dispatch({ type: "SET_VALUE", payload: { value, type } });
  }

  useEffect(() => {
    getCompositionData();
  }, [getCompositionData]);

  useEffect(() => {
    resetUnitList();
  }, [resetUnitList, state.battleType]);

  useEffect(() => {
    getUnitByFactionData();
  }, [getUnitByFactionData, state.factionId]);

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
          style={{ width: "65%" }}
          onChange={(e) => setStateValue(e.target.value, "name")}
        />
        <BattleTypeSelection />
        <FactionSelection />
        <BudgetSelection />
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
        <CompositionsList factionUnits={dropdownData} />
      </Stack>
      <br></br>
      <Grid
        container
        direction="row"
        justifyContent="space-around"
        alignItems="center"
        spacing={0}
      >
        <Grid item xs={3}>
          <h4>Wins:</h4>
        </Grid>
        <Grid item xs={3}>
          <WinCounter />
        </Grid>
        <Grid item xs={3}>
          <h4>Losses:</h4>
        </Grid>
        <Grid item xs={3}>
          <LossCounter />
        </Grid>
      </Grid>
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
