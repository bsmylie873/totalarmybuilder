# API Specification

## FACTIONS
`GET /factions` Return a list of all factions.

Response \
`[
  {
    "id": 1,
    "name": "Beastmen"
  },
  {
    "id": 2,
    "name": "Bretonnia"
  }
etc...
]`

`GET /factions/{id}` Return a specific faction by id.

Response \
`[
  {
    "id": 13,
    "name": "Norsca"
  }
]`

## UNITS
`GET /units` Return a list of all units.

Response \
`[
  {
    "id": 1,
    "name": "Boyar",
    "cost": 1550,
    "avatar_id:" "1"
  },
  {
    "id": 2,
    "name": "Ice Witch (Ice)",
    "cost": 2062,
    "avatar_id:" "2"
  }
etc...
]`

`GET /units/{id}` Return a specific unit by id.

Response \
`[
  {
    "id": 11,
    "name": "Tzar Guard",
    "cost": 1000,
    "avatar_id:" "11"
  }
]`

`GET /units/{factionId}` Return all units which belong to a faction.

`[
  {
    "id": 28,
    "name": "Lord Magistrate",
    "cost": 1300,
    "avatar_id:" "28"
  },
  {
    "id": 29,
    "name": "Dragon-blooded Shugengan Lord (Yin)",
    "cost": 2062,
    "avatar_id:" "29"
  }
etc...
]`

`GET /units/{compositionId}` Return units associated with a composition.

Response \
`[
  {
    "id": 11,
    "name": "Tzar Guard",
    "cost": 1000,
    "avatar_id:" "11"
  },
  {
    "id": 11,
    "name": "Tzar Guard",
    "cost": 1000,
    "avatar_id:" "11"
  },
etc...
]`

## COMPOSITIONS
`GET /compositions` Return a list of all compositions.

Response \
`[
  {
    "id": 1,
    "name": "Khorne Rush",
    "battle_type": "Land Battle",
    "faction_id": "10"
    "avatar_id": "145"
  },
  {
    "id": 2,
    "name": "Wood Elf Skirmish",
    "battle_type": "Domination",
    "faction_id": "23"
    "avatar_id": "256"
  }
etc...
]`

`GET /compositions/{id}` Return a specific composition by id.

Response \
`[
  {
    "id": 66,
    "name": "Empire Wagons VS TK",
    "battle_type": "Domination",
    "faction_id": "6"
    "avatar_id": "344"
  }
]`

`GET /compositions/{accountId}` Return compositions made by a specific account.

Response \
`[
  {
    "id": 756,
    "name": "Dark Elves OP",
    "battle_type": "Land Battle",
    "faction_id": "4"
    "avatar_id": "744"
  },
etc...
]`

`POST /compositions/{accountId}` Create a new composition tied to an account.

Request \
`[
  {
    "id": 999,
    "name": "New Composition",
    "battle_type": "Land Battle",
    "faction_id": "1"
    "avatar_id": "1"
  }
]`

Response - `201 Created`

`GET /compositions/{factionId}` Return all compositions which belong to a faction.

`[
  {
    "id": 66,
    "name": "Empire Wagons VS TK",
    "battle_type": "Domination",
    "faction_id": "6"
    "avatar_id": "344"
  },
  {
    "id": 653,
    "name": "Demigryph Focus",
    "battle_type": "Land Battle",
    "faction_id": "6"
    "avatar_id": "333"
  }
etc...
]`



## ACCOUNT
`GET /account/{id}` Return a account by id.

Response \
`[
  {
    "id": 12345,
    "username": "Joe Bloggs",
  }
]`

`POST /account` Create a new account.

Request \
`[
  {
    "username": "new_user",
    "password": "new_password"
  }
]`

Response - `201 Created`

`PUT /account/{id}` Update an account by id.

Request \
`[
  {
    "username": "updated_username",
    "password": "updated_password"
  }
]`

`DELETE /users/{id}` Delete an account by id. \

Response - `204 No Content`
