# API Specification

## FACTIONS
### Return a list of all factions.
`GET /factions` 

Response:
```
[
  {
    "id": 1,
    "name": "Beastmen"
  },
  {
    "id": 2,
    "name": "Bretonnia"
  }
etc...
]
```

### Return a specific faction by id.
`GET /factions/{factionId}`

Response:
```
[
  {
    "id": 13,
    "name": "Norsca"
  }
]
```

## UNITS
### Return a list of all units.
`GET /units` 

Response:
```
[
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
]
```

### Return a specific unit by id.
`GET /units/{unitId}`

Response:
```
[
  {
    "id": 11,
    "name": "Tzar Guard",
    "cost": 1000,
    "avatar_id:" "11"
  }
]
```

### Return all units which belong to a faction.
`GET /factions/{factionId}/units` 

Response: 
```
[
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
]
```

### Return units associated with a composition.
`GET compositions/{compositionId}/units` 

Response:
```
[
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
]
```

## COMPOSITIONS
### Return a list of all compositions.
`GET /compositions` 

Response:
```
[
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
]
```

### Return a specific composition by id.
`GET /compositions/{compositionId}` 

Response:
```
[
  {
    "id": 66,
    "name": "Empire Wagons VS TK",
    "battle_type": "Domination",
    "faction_id": "6"
    "avatar_id": "344"
  }
]
```

### Return compositions made by a specific account.
`GET /accounts/{accountId}/compositions` 

Response:
```
[
  {
    "id": 756,
    "name": "Dark Elves OP",
    "battle_type": "Land Battle",
    "faction_id": "4"
    "avatar_id": "744"
  },
etc...
]
```

### Create a new composition tied to an account.
`POST /accounts/{accountId}/compositions` 

Request:
```
[
  {
    "id": 999,
    "name": "New Composition",
    "battle_type": "Land Battle",
    "faction_id": "1"
    "avatar_id": "1"
  }
]
```

Response: 
`201 Created`

### Update a composition by id.
`PATCH /compositions/{compositionId}` 

Request:
```
[
  {
    "name": "updated_name",
    "battle_type": "updated_battletype"
    "faction_id": "updated_faction"
    "avatar_id": "updated_avatar"
  }
]
```

### Delete an account by id.
`DELETE /compositions/{compositionId}` 

Response - `204 No Content`


## ACCOUNT
### Return a account by id.
`GET /account/{id}` 

Response:
```
[
  {
    "id": 12345,
    "username": "Joe Bloggs",
  }
]
```

### Create a new account.
`POST /account` 

Request:
```
[
  {
    "username": "new_user",
    "password": "new_password"
  }
]
```

Response:
`201 Created`

### Update an account by id.
`PUT /account/{accountId}` 

Request:
```
[
  {
    "username": "updated_username",
    "password": "updated_password"
  }
]
```

### Delete an account by id.
`DELETE /account/{accountId}` 

Response - `204 No Content`
