import { Unit } from "../types/unit";
import {FetchUtils} from "../utils";

const getUnits = async () => {
    return await FetchUtils.fetchInstance(`api/units`, {
        method: "GET",
    });
};

const getUnit = async (unitId: string) => {
    return await FetchUtils.fetchInstance(`api/units/${unitId}`, {
        method: "GET",
    });
};

const getUnitFactions = async (unitId: string) => {
    return await FetchUtils.fetchInstance(`api/units/${unitId}/factions`, {
        method: "GET",
    });
};

const getLords = async () => {
    return await FetchUtils.fetchInstance(`api/lords`, {
        method: "GET",
    });
};

const getHeroes = async () => {
    return await FetchUtils.fetchInstance(`api/heroes`, {
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