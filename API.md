# API Specification

## FACTIONS
### Return a list of all factions.
`GET /factions` 

Response:
```json
[
  {
    "id": 1,
    "name": "Beastmen"
  },
  {
    "id": 2,
    "name": "Bretonnia"
  }
]
```

### Return a specific faction by id.
`GET /factions/{factionId}`

Response:
```json
[
  {
    "id": 13,
    "name": "Norsca"
  }
]
```

## UNITS
### Return a specific unit by id.
`GET /units/{unitId}`

Response:
```json
[
  {
    "id": 11,
    "name": "Tzar Guard",
    "cost": 1000,
    "avatar": {   
          "id": 11,
          "url": "https://imagebucket.com/11"
        }
  }
]
```

### Return all units which belong to a faction.
`GET /factions/{factionId}/units` 

Response: 
```json
[
  {
    "id": 28,
    "name": "Lord Magistrate",
    "cost": 1300,
    "avatar": {   
          "id": 28,
          "url": "https://imagebucket.com/28"
        }
  },
  {
    "id": 29,
    "name": "Dragon-blooded Shugengan Lord (Yin)",
    "cost": 2062,
    "avatar": {   
          "id": 29,
          "url": "https://imagebucket.com/29"
        }
  }
]
```

### Return units associated with a composition.
`GET compositions/{compositionId}/units` 

Response:
```json
[
  {
    "id": 11,
    "name": "Tzar Guard",
    "cost": 1000,
    "avatar": {   
          "id": 11,
          "url": "https://imagebucket.com/11"
        }
  },
  {
    "id": 11,
    "name": "Tzar Guard",
    "cost": 1000,
    "avatar": {   
          "id": 11,
          "url": "https://imagebucket.com/11"
        }
  },
]
```

## COMPOSITIONS
### Return a list of all compositions.
`GET /compositions` 

Response:
```json
[
  {
    "id": 1,
    "name": "Khorne Rush",
    "battle_type": "Land Battle",
    "faction": {
          "id": 10,
          "name": "Khorne"
        },
    "avatar": {   
          "id": 145,
          "url": "https://imagebucket.com/145"
        }
  },
  {
    "id": 2,
    "name": "Wood Elf Skirmish",
    "battle_type": "Domination",
    "faction": {
          "id": 23,
          "name": "Wood Elves"
        },
    "avatar": {   
          "id": 786,
          "url": "https://imagebucket.com/786"
        }
  }
]
```

### Return a specific composition by id.
`GET /compositions/{compositionId}` 

Response:
```json
[
  {
    "id": 66,
    "name": "Kislev VS TK",
    "battle_type": "Domination",
    "faction": {
          "id": 11,
          "name": "Kislev"
        },
    "avatar": {   
          "id": 13,
          "url": "https://imagebucket.com/13"
        },
    "units": [
      {
        {
          "id": 11,
          "name": "Tzar Guard",
          "cost": 1000,
          "avatar_id": 11
        },
        {   
          "id": 11,
          "name": "Tzar Guard",
          "cost": 1000,
          "avatar_id": 11
        }
      }
    ]
  }
]
```

### Return compositions made by a specific account.
`GET /accounts/{accountId}/compositions` 

Response:
```json
[
  {
    "id": 756,
    "name": "Dark Elves OP",
    "battle_type": "Land Battle",
    "faction": {
          "id": 4,
          "name": "Dark Elves"
        },
    "avatar": {   
          "id": 532,
          "url": "https://imagebucket.com/532"
        },
    "units":[
      {
        {   
          "id": 532,
          "name": "Malus Darkblade",
          "cost": 2316,
          "avatar": {   
                "id": 532,
                "url": "https://imagebucket.com/532"
                }
        }
      }
    ]
  }
]
```

### Create a new composition tied to an account.
`POST /accounts/{accountId}/compositions` 

Request:
```json
[
  {
    "id": 999,
    "name": "New Composition",
    "battle_type": "Land Battle",
    "faction": {
          "id": 1,
          "name": "Beastmen"
        },
    "avatar": {   
          "id": 1,
          "url": "https://imagebucket.com/1"
        },
    "units": [
      {

      }
    ]
  }
]
```

Response: 
`201 Created`

### Update a composition by id.
`PATCH /compositions/{compositionId}` 

Request:
```json
[
  {
    "name": "updated_name",
    "battle_type": "updated_battletype",
    "faction": {
          "id": 0,
          "name": "updated_faction"
        },
    "avatar": {   
          "id": 0,
          "url": "https://imagebucket.com/new_avatar"
        },
    "units": [
      {   
          "id": 9999,
          "name": "New Unit",
          "cost": 9999,
          "avatar": {   
                "id": 0,
                "url": "https://imagebucket.com/new_avatar"
        }
      }
    ]
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
```json
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
```json
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
```json
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

