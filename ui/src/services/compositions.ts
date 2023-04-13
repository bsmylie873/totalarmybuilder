import { Composition } from "../types/composition";
import { FetchUtils } from "../utils";

const createComposition = async (newComposition: Composition) => {
  const { name, battleType, factionId, avatarId, budget, wins, losses, units } =
    newComposition;
  return await FetchUtils.fetchInstance("compositions", {
    method: "POST",
    body: JSON.stringify({
      name,
      battleType,
      factionId,
      avatarId,
      budget,
      wins,
      losses,
      units,
    }),
  });
};

const updateComposition = async (updateComposition: Composition) => {
  const {
    id,
    name,
    battleType,
    factionId,
    avatarId,
    wins,
    losses,
    budget,
    units,
  } = updateComposition;
  return await FetchUtils.fetchInstance(`compositions/${id}`, {
    method: "PATCH",
    body: JSON.stringify({
      id,
      name,
      battleType,
      factionId,
      avatarId,
      budget,
      wins,
      losses,
      units,
    }),
  });
};

const deleteComposition = async (compositionId: string) => {
  return await FetchUtils.fetchInstance(`compositions/${compositionId}`, {
    method: "DELETE",
  });
};

const getComposition = async (compositionId: string) => {
  return await FetchUtils.fetchInstance(`compositions/${compositionId}`, {
    method: "GET",
  });
};

const getCompositions = async () => {
  return await FetchUtils.fetchInstance(`compositions`, {
    method: "GET",
  });
};

const getCompositionUnits = async (compositionId: string) => {
  return await FetchUtils.fetchInstance(`compositions/${compositionId}/units`, {
    method: "GET",
  });
};

export default {
  createComposition,
  updateComposition,
  deleteComposition,
  getComposition,
  getCompositions,
  getCompositionUnits,
};
