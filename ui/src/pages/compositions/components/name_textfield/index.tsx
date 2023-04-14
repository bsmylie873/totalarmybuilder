import { TextField } from "@mui/material";
import { CompContext } from "../../../../contexts";

type TextFieldProps = {
  // 👇️ type as React.CSSProperties
  style: React.CSSProperties;
};

function NameTextField({ style }: TextFieldProps) {
  const { state, dispatch } = CompContext.useCurrentComposition();

  function setStateValue(value: any, type: string) {
    dispatch({ type: "SET_VALUE", payload: { value, type } });
  }

  return (
    <div>
      <TextField
        id="outlined-name"
        label="Name"
        type="text"
        helperText="Please enter the name..."
        value={state.name}
        style={style}
        onChange={(e) => setStateValue(e.target.value, "name")}
      ></TextField>
    </div>
  );
}

export default NameTextField;
