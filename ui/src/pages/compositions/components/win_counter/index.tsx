import { Button, ButtonGroup } from "@mui/material";
import { CompContext } from "../../../../contexts";
import toast from "react-hot-toast";

function WinCounter() {
  const { state, dispatch } = CompContext.useCurrentComposition();

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

  return (
    <>
      <ButtonGroup size="small" aria-label="win counter" color="info">
        <Button
          key="subtractWin"
          onClick={() => {
            subtractWin(undefined, "wins");
          }}
          style={{ margin: "15%" }}
        >
          -
        </Button>

        <h4>{state.wins}</h4>
        <Button
          key="addWin"
          onClick={() => {
            addWin(undefined, "wins");
          }}
          style={{ margin: "15%" }}
        >
          +
        </Button>
      </ButtonGroup>
    </>
  );
}

export default WinCounter;
