import { createContext } from "react";
import { createTheme } from "@mui/system";

export const themes = [
  {
    name: "lightTheme",
    theme: createTheme({
      palette: {
        type: "light",
        primary: {
          main: "#a60000",
        },
        secondary: {
          main: "#4a4a4a",
        },
        error: {
          main: "#8d36f4",
        },
        background: {
          default: "#d4d4d4",
        },
      },
    }),
  },
  {
    name: "darkTheme",
    theme: createTheme({
      palette: {
        type: "dark",
        primary: {
          main: "#a60000",
        },
        secondary: {
          main: "#4a4a4a",
        },
        error: {
          main: "#8d36f4",
        },
        background: {
          default: "#2d2d2d",
        },
      },
    }),
  },
];

export const ThemeContext = createContext({
  setColorMode: () => {},
});

export default ThemeContext;
