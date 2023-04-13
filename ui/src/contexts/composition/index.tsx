import React, { createContext, useContext, useReducer } from "react";
import { Composition } from "../../types/composition";
import { Unit } from "../../types/unit";

interface CompContextProps {
  state: {
    id?: number;
    name: string;
    battleType: string;
    factionId: number;
    avatarId?: number;
    budget: number;
    dateCreated: Date;
    wins: number;
    losses: number;
    units: Unit[];
  };
  dispatch: React.Dispatch<any>;
}

type payload = {
  value: number | string | Unit;
  type: string;
};

const CompContext = createContext<CompContextProps | undefined>(undefined);

export type Action =
  | { type: string; payload: payload }
  | { type: "SET_COMP"; payload: Composition }
  | { type: "CLEAR" }
  | { type: "ADD_TO_UNIT_LIST"; payload: any }
  | { type: "RESET_UNIT_LIST" }
  | { type: "REMOVE_UNIT_FROM_UNIT_LIST"; payload: any };

export const initialState: Composition = {
  id: 0,
  name: "New Composition",
  battleType: "Land Battles",
  factionId: 1,
  avatarId: 1,
  budget: 10000,
  dateCreated: new Date(Date.now()),
  wins: 0,
  losses: 0,
  units: [],
};

export function compReducer(state: Composition, action: Action): Composition {
  switch (action.type) {
    case "SET_VALUE":
      return { ...state, [action.payload.type]: action.payload.value };
    case "CLEAR":
      return { ...initialState };
    case "SET_COMP":
      return { ...(action.payload as Composition) };
    case "ADD_TO_UNIT_LIST":
      return {
        ...state,
        units: [...state.units, action.payload.value as Unit],
      };
    case "RESET_UNIT_LIST":
      return { ...state, units: [] };
    case "REMOVE_UNIT_FROM_UNIT_LIST":
      return {
        ...state,
        units: state.units.filter((unit) => unit !== action.payload.value),
      };
    case "ADD_WIN":
      return { ...state, wins: state.wins + 1 };
    case "REMOVE_WIN":
      return { ...state, wins: state.wins - 1 };
    case "ADD_LOSS":
      return { ...state, losses: state.losses + 1 };
    case "REMOVE_LOSS":
      return { ...state, losses: state.losses - 1 };
    default:
      return state;
  }
}

function CompProvider({ children }: any) {
  const [state, dispatch] = useReducer(compReducer, initialState);
  const value = { state, dispatch };

  return <CompContext.Provider value={value}>{children}</CompContext.Provider>;
}

function useCurrentComposition() {
  const context = useContext(CompContext);
  if (context === undefined) {
    throw new Error("useComposition must be used within a CompositionProvider");
  }
  return context;
}

// eslint-disable-next-line import/no-anonymous-default-export
export default { CompProvider, useCurrentComposition };
