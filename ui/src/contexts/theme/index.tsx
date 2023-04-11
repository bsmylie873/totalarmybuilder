import { createTheme } from "@mui/system";
import { createContext } from "react";

export const themes = [
  {
    name: "darkTheme",
    theme: createTheme({
      palette: {
        mode: "dark",
      },
    }),
  },
  {
    name: "lightTheme",
    theme: createTheme({
      palette: {
        mode: "light",
      },
    }),
  },
];

export const ThemeContext = createContext({
  setColorMode: () => {},
});
