import { Composition } from "../../types/composition";
import { Unit } from "../../types/unit";

type payload = {
   value: number | string, type: string 
}

export type Action = { type: string; payload: payload } | { type: "SET_COMP"; payload: Composition } | { type: 'CLEAR' };

export const initialState: Composition = {
    id: 0,
    name: 'New Composition',
    battleType: 'Land Battles',
    factionId: 1,
    avatarId: 1,
    budget: 9000,
    dateCreated: new Date(Date.now()),
    wins: 0,
    losses: 0,
    unitList: []
};

export function reducer(state: Composition, action: Action): Composition {
    switch (action.type) {
        case 'SET_VALUE':
            return { ...state, [action.payload.type]: action.payload.value };
        case 'CLEAR':
            return { ...initialState};
        case 'SET_COMP':
            return { ...(action.payload as Composition)};
        case 'RESET_UNIT_LIST':
            return { ...state, unitList: []};
        /* case 'ADD_UNIT':
            return { ...state, unitList: [...state.unitList, action.payload.newUnit]}; */
        default:
            return state;
    }
}