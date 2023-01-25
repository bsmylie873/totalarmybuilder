import { Unit } from "./unit";

export type Composition = {
    id: number,
    name: string,
    battleType: string,
    factionId: string,
    avatarId?: string,
    budget: number,
    dateCreated: Date,
    wins: number,
    losses: number,
    unitList: Unit[] 
};