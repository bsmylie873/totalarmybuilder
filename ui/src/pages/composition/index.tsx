import { Stack, TextField } from "@mui/material";
import { useParams } from "react-router-dom";
import {
  BattleTypeSelection,
  BudgetSelection,
  FactionSelection,
  PrimaryUnitList,
  SecondaryUnitList,
} from "../../components";

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
    </>
  );
};

export default Composition;
