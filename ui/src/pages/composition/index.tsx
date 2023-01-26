import { Stack, TextField } from "@mui/material";
import { useNavigate, useParams } from "react-router-dom";
import {
  BattleTypeSelection,
  BudgetSelection,
  FactionSelection,
  PrimaryUnitList,
  SecondaryUnitList,
} from "../../components";
import Button from "@mui/material/Button";
import { Box } from "@mui/system";
import { useState, useEffect } from "react";
import toast from "react-hot-toast";
import { CompositionService } from "../../services";
import { NavigationRoutes } from "../../constants";

const Composition = () => {
  const { compositionId } = useParams<{ compositionId: string }>();
  const [compositionTitle, setCompositionTitle] = useState();

  const navigate = useNavigate();

  async function getCompositionTitle() {
    const compositionResponse = await CompositionService.getComposition(
      compositionId as string
    );
    if (compositionResponse.status === 200) {
      const composition = await compositionResponse.json();
      const compositionTitle = composition.flatMap((x: any) => {
        return {
          name: x.name,
        };
      });
    }
    setCompositionTitle(compositionTitle);
  }

  useEffect(() => {
    getCompositionTitle();
  }, []);

  return (
    <>
      <Stack
        direction="row"
        spacing={1}
        alignItems="center"
        justifyContent="space-around"
      >
        <h2>Composition Name: {compositionTitle}</h2>
      </Stack>
      <Stack
        direction="row"
        spacing={1}
        alignItems="center"
        justifyContent="space-around"
      >
        <BattleTypeSelection />
        <FactionSelection />
        <BudgetSelection />
      </Stack>
      <PrimaryUnitList />
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

export default Composition;
