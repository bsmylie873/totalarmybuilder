import { Stack } from "@mui/material";
import { useParams } from "react-router-dom";
import {
  BattleTypeSelection,
  BudgetSelection,
  FactionSelection,
  PrimaryUnitList,
  SecondaryUnitList,
} from "../../components";
import Button from "@mui/material/Button";
import { Box } from "@mui/system";

const Composition = () => {
  const { compositionId } = useParams<{ compositionId: string }>();
  console.log(compositionId);
  return (
    <>
      <Stack
        direction="row"
        spacing={0}
        alignItems="center"
        justifyContent="center"
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
        <Button variant="outlined" color="error">
          Cancel
        </Button>
      </Box>
    </>
  );
};

export default Composition;
