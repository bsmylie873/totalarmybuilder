import { Composition } from "../../types/composition";
import { Unit } from "../../types/unit";

type payload = {
   value: number | string | Unit, type: string
}

export type Action = { type: string; payload: payload } 
| { type: 'SET_COMP'; payload: Composition } 
| { type: 'CLEAR' } 
| { type: 'ADD_TO_UNIT_LIST'; payload: any}
| { type: 'RESET_UNIT_LIST'; }
| { type: 'REMOVE_UNIT_FROM_UNIT_LIST'; payload: any }

export const initialState: Composition = {
    id: 0,
    name: 'New Composition',
    battleType: 'Land Battles',
    factionId: 1,
    avatarId: 1,
    budget: 10000,
    dateCreated: new Date(Date.now()),
    wins: 0,
    losses: 0,
    units: []
};

export function reducer(state: Composition, action: Action): Composition {
    switch (action.type) {
        case 'SET_VALUE':
            return { ...state, [action.payload.type]: action.payload.value };
        case 'CLEAR':
            return { ...initialState};
        case 'SET_COMP':
            return { ...(action.payload as Composition)};
        case 'ADD_TO_UNIT_LIST':
            return { ...state, units: [...state.units, action.payload.value as Unit] };
        case 'RESET_UNIT_LIST':
            return { ...state, units: []};
        case "REMOVE_UNIT_FROM_UNIT_LIST":
            return { ...state, units: state.units.filter((unit) => unit !== action.payload.value) };   
        default:
            return state;
    }
}