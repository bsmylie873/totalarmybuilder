import { Button, ButtonGroup } from "@mui/material";
import { CompContext } from "../../../../contexts";
import toast from "react-hot-toast";

function LossCounter() {
  const { state, dispatch } = CompContext.useCurrentComposition();

  async function addLoss(value: any, type: string) {
    dispatch({
      type: "ADD_LOSS",
      payload: { value, type },
    });
  }

  async function subtractLoss(value: any, type: string) {
    if (state.wins > 0) {
      dispatch({
        type: "REMOVE_LOSS",
        payload: { value, type },
      });
    } else {
      toast.error("Cannot have a negative number of losses!");
    }
  }

  return (
    <ButtonGroup size="small" aria-label="win counter">
      <Button
        key="subtractLoss"
        onClick={() => {
          subtractLoss(undefined, "wins");
        }}
      >
        -
      </Button>
      <h4>{state.losses}</h4>
      <Button
        key="addLoss"
        onClick={() => {
          addLoss(undefined, "wins");
        }}
      >
        +
      </Button>
    </ButtonGroup>
  );
}

export default LossCounter;
