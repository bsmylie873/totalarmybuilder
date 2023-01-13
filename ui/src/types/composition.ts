import { Unit } from "./unit";

export type Composition = {
    name: string,
    battleType: string,
    factionId: string,
    avatarId?: string,
    dateCreated: Date,
    wins: number,
    losses: number,
    unitList: Unit[] 
};