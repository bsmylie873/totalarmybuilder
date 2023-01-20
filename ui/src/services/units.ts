import { Unit } from "../types/unit";
import {FetchUtils} from "../utils";

const getUnits = async () => {
    return await FetchUtils.fetchInstance(`units`, {
        method: "GET",
    });
};

const getUnit = async (unitId: string) => {
    return await FetchUtils.fetchInstance(`units/${unitId}`, {
        method: "GET",
    });
};

const getUnitFactions = async (unitId: string) => {
    return await FetchUtils.fetchInstance(`units/${unitId}/factions`, {
        method: "GET",
    });
};

const getLords = async () => {
    return await FetchUtils.fetchInstance(`lords`, {
        method: "GET",
    });
};

const getHeroes = async () => {
    return await FetchUtils.fetchInstance(`heroes`, {
        method: "GET",
    });
};


export default {
    getUnits,
    getUnit,
    getUnitFactions,
    getLords,
    getHeroes
};