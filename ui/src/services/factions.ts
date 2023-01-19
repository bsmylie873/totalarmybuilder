import { Faction } from "../types/faction";
import {FetchUtils} from "../utils";

const getFactions = async () => {
    return await FetchUtils.fetchInstance(`api/factions`, {
        method: "GET",
    });
};

const getFaction = async (factionId: string) => {
    return await FetchUtils.fetchInstance(`api/factions/${factionId}`, {
        method: "GET",
    });
};

const getFactionUnits = async (factionId: string) => {
    return await FetchUtils.fetchInstance(`api/factions/${factionId}/units`, {
        method: "GET",
    });
};


export default {
    getFactions,
    getFaction,
    getFactionUnits
};