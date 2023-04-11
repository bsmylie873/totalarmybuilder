import { createContext } from "react";
import { createTheme } from "@mui/system";

export const themes = [
  {
    name: "lightTheme",
    theme: createTheme({
      palette: {
        mode: "light",
      },
    }),
  },
  {
    name: "darkTheme",
    theme: createTheme({
      palette: {
        mode: "dark",
      },
    }),
  },
];

export const ThemeContext = createContext({
  setColorMode: () => {},
});

export default ThemeContext;
