import { Unit } from "./unit";

export type Composition = {
    id?: number,
    name: string,
    battleType: string,
    factionId: number,
    avatarId?: number,
    budget: number,
    dateCreated: Date,
    wins: number,
    losses: number,
    units: Unit[], 
    units2: Unit[]
};