import { rest } from "msw";

const compositions = {
    1 : {
    name: "Hungry Hungry Ogres", 
    author: "OgreTyrant985",
    battle_type: "Land Battles",
    faction: "Ogre Kingdoms",
    budget: 9000},
    2 : {
        name: "Chaos Knights Are Bad",
    author: "bigchungus98",
    battle_type: "Domination",
    faction: "Warriors Of Chaos",
    budget: 120000},
    3 : {
        name: "Kislev Draft1",
    author: "user8573666",
    battle_type: "Domination",
    faction: "Beastmen",
    budget: 9000},
    4 : {
        name: "Kislev Draft1",
    author: "user8573666",
    battle_type: "Domination",
    faction: "Beastmen",
    budget: 9000},
}



export const handlers = [
    rest.get("/compositions", async (req, res, ctx) => {
        return res(
            ctx.status(200),
            ctx.json(
                Object.entries(compositions).map(([id, data]) => {
                    return { ...data };
                })
            )
        )
    })
]