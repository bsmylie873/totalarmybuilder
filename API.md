# API Specification

## FACTIONS
### Return a list of all factions.
`GET /factions` 

Response: \
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

### Return a specific faction by id.
`GET /factions/{id}`

Response: \
`[
  {
    "id": 13,
    "name": "Norsca"
  }
]`

## UNITS
### Return a list of all units.
`GET /units` 

Response: \
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

### Return a specific unit by id.
`GET /units/{id}`

Response: \
`[
  {
    "id": 11,
    "name": "Tzar Guard",
    "cost": 1000,
    "avatar_id:" "11"
  }
]`

### Return all units which belong to a faction.
`GET /units/{factionId}` 


Response: \
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

### Return units associated with a composition.
`GET /units/{compositionId}` 

Response: \
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
### Return a list of all compositions.
`GET /compositions` 

Response: \
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

### Return a specific composition by id.
`GET /compositions/{id}` 

Response: \
`[
  {
    "id": 66,
    "name": "Empire Wagons VS TK",
    "battle_type": "Domination",
    "faction_id": "6"
    "avatar_id": "344"
  }
]`

### Return compositions made by a specific account.
`GET /compositions/{accountId}` 

Response: \
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

### Create a new composition tied to an account.
`POST /compositions/{accountId}` 

Request: \
`[
  {
    "id": 999,
    "name": "New Composition",
    "battle_type": "Land Battle",
    "faction_id": "1"
    "avatar_id": "1"
  }
]`

Response: 
`201 Created`
### Return all compositions which belong to a faction.
`GET /compositions/{factionId}` 

Response: \
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
### Return a account by id.
`GET /account/{id}` 

Response: \
`[
  {
    "id": 12345,
    "username": "Joe Bloggs",
  }
]`

### Create a new account.
`POST /account` 

Request: \
`[
  {
    "username": "new_user",
    "password": "new_password"
  }
]`

Response:
`201 Created`

### Update an account by id.
`PUT /account/{id}` 

Request: \
`[
  {
    "username": "updated_username",
    "password": "updated_password"
  }
]`

### Delete an account by id.
`DELETE /users/{id}` 

Response - `204 No Content`
