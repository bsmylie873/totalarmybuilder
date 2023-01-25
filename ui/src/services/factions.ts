import { Faction } from "../types/faction";
import {FetchUtils} from "../utils";

const getFactions = async () => {
    return await FetchUtils.fetchInstance(`factions`, {
        method: "GET",
    });
};

const getFaction = async (factionId: number) => {
    return await FetchUtils.fetchInstance(`factions/${factionId}`, {
        method: "GET",
    });
};

const getFactionUnits = async (factionId: number) => {
    return await FetchUtils.fetchInstance(`factions/${factionId}/units`, {
        method: "GET",
    });
};


export default {
    getFactions,
    getFaction,
    getFactionUnits
};