CREATE TABLE accounts IF NOT EXISTS(
    id INT INCREMENT PRIMARY KEY,
    email VARCHAR(255) UNIQUE NOT NULL,
    username VARCHAR(50) UNIQUE NOT NULL,
  	password VARCHAR(50) NOT NULL,
)

CREATE TABLE accounts_compositions IF NOT EXISTS(
    account_id INT NOT NULL,
    composition_id INT NOT NULL,
  	PRIMARY KEY (account_id, composition_id),
  	FOREIGN KEY (account_id)
      REFERENCES accounts (id),
  	FOREIGN KEY (composition_id)
      REFERENCES compositions (id)
)

CREATE TABLE compositions IF NOT EXISTS(
    id INT INCREMENT PRIMARY KEY,
    NAME VARCHAR(255) UNIQUE NOT NULL,
  	battle_type INT not NULL,
  	faction_id INT NOT NULL,
  	avatar_id INT NOT NULL,
  	FOREIGN KEY (faction_id)
      REFERENCES factions (id),
  	FOREIGN KEY (avatar_id)
      REFERENCES avatar (id)
)

CREATE TABLE avatar IF NOT EXISTS(
    id INT INCREMENT PRIMARY KEY,
  	url VARCHAR(255) NOT NULL
)

CREATE TABLE units IF NOT EXISTS(
    id INT INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
  	cost INT NOT NULL,
  	avatar_id INT NOT NULL,
  	FOREIGN KEY (avatar_id)
      REFERENCES avatar (id)
)

CREATE TABLE compositions_units IF NOT EXISTS(
    composition_id INT NOT NULL,
  	unit_id INT NOT NULL,
  	PRIMARY KEY (composition_id, unit_key),
  	FOREIGN KEY (composition_id)
      REFERENCES compositions (id),
  	FOREIGN KEY (unit_id)
      REFERENCES units (id)
)

CREATE TABLE compositions_units IF NOT EXISTS(
    composition_id INT NOT NULL,
  	unit_id INT NOT NULL,
  	PRIMARY KEY (composition_id, unit_key),
  	FOREIGN KEY (composition_id)
      REFERENCES compositions (id),
  	FOREIGN KEY (unit_id)
      REFERENCES units (id)
)

CREATE TABLE restrictors IF NOT EXISTS(
    id INT INCREMENT PRIMARY KEY,
  	name VARCHAR(50) NOT NULL,
  	limit INT NOT NULL
)

CREATE TABLE units_restrictors IF NOT EXISTS(
    unit_id INT NOT NULL,
  	restrictor_id INT NOT NULL,
  	PRIMARY KEY (unit_id, restrictor_id),
  	FOREIGN KEY (composition_id)
      REFERENCES compositions (id),
  	FOREIGN KEY (unit_id)
      REFERENCES units (id)
)

CREATE TABLE lords_restrictors IF NOT EXISTS(
    lord_id INT NOT NULL,
  	restrictor_id INT NOT NULL,
  	PRIMARY KEY (lord_id, restrictor_id),
  	FOREIGN KEY (lord_id)
      REFERENCES lordorherocustomisation (unit_id),
  	FOREIGN KEY (unit_id)
      REFERENCES units (id)
)

CREATE TABLE heroes_restrictors IF NOT EXISTS(
    hero_id INT NOT NULL,
  	restrictor_id INT NOT NULL,
  	PRIMARY KEY (hero_id, restrictor_id),
  	FOREIGN KEY (hero_id)
      REFERENCES lordorherocustomisation (unit_id),
  	FOREIGN KEY (unit_id)
      REFERENCES units (id)
)

CREATE TABLE heroes_restrictors IF NOT EXISTS(
    hero_id INT NOT NULL,
  	restrictor_id INT NOT NULL,
  	PRIMARY KEY (hero_id, restrictor_id),
  	FOREIGN KEY (hero_id)
      REFERENCES lordorherocustomisation (unit_id),
  	FOREIGN KEY (unit_id)
      REFERENCES units (id)
)

CREATE TABLE factions IF NOT EXISTS(
    id INT INCREMENT PRIMARY KEY,
  	name VARCHAR(50) NOT NULL,
)

CREATE TABLE units_factions IF NOT EXISTS(
    unit_id INT NOT NULL,
  	faction_id INT NOT NULL,
  	PRIMARY KEY (unit_id, faction_id),
  	FOREIGN KEY (unit_id)
      REFERENCES units (id),
  	FOREIGN KEY (faction_id)
      REFERENCES factions (id)
)

CREATE TABLE lords_factions IF NOT EXISTS(
    lord_id INT NOT NULL,
  	faction_id INT NOT NULL,
  	PRIMARY KEY (lord_id, faction_id),
  	FOREIGN KEY (lord_id)
      REFERENCES lordorherocustomisation (id),
  	FOREIGN KEY (faction_id)
      REFERENCES factions (id)
)

CREATE TABLE heroes_factions IF NOT EXISTS(
    hero_id INT NOT NULL,
  	faction_id INT NOT NULL,
  	PRIMARY KEY (hero_id, faction_id),
  	FOREIGN KEY (hero_id)
      REFERENCES lordorherocustomisation (id),
  	FOREIGN KEY (faction_id)
      REFERENCES factions (id)
)

CREATE TABLE attributes IF NOT EXISTS(
    id INT INCREMENT PRIMARY KEY,
  	name VARCHAR(50) NOT NULL,
  	limit INT NOT NULL,
)

CREATE TABLE units_attributes IF NOT EXISTS(
    unit_id INT NOT NULL,
  	attribute_id INT NOT NULL,
  	PRIMARY KEY (unit_id, attribute_id),
  	FOREIGN KEY (unit_id)
      REFERENCES units (id),
  	FOREIGN KEY (attribute_id)
      REFERENCES attributes (id)
)

CREATE TABLE lords_attributes IF NOT EXISTS(
    lord_id INT NOT NULL,
  	attribute_id INT NOT NULL,
  	PRIMARY KEY (lord_id, attribute_id),
  	FOREIGN KEY (lord_id)
      REFERENCES lordorherocustomisation (id),
  	FOREIGN KEY (attribute_id)
      REFERENCES attributes (id)
)

CREATE TABLE heroes_attributes IF NOT EXISTS(
    hero_id INT NOT NULL,
  	attribute_id INT NOT NULL,
  	PRIMARY KEY (hero_id, attribute_id),
  	FOREIGN KEY (hero_id)
      REFERENCES lordorherocustomisation (id),
  	FOREIGN KEY (attribute_id)
      REFERENCES attributes (id)
)

CREATE TABLE lordorherocustomisation IF NOT EXISTS(
    unit_id INT NOT NULL,
  	spell_id INT,
  	ability_id INT,
  	item_id INT,
  	mount_id INT,
  	PRIMARY KEY (unit_id, spell_id, ability_id, item_id, mount_id),
  	FOREIGN KEY (unit_id)
      REFERENCES units (id),
  	FOREIGN KEY (spell_id)
      REFERENCES spells (id),
  	FOREIGN KEY (ability_id)
      REFERENCES abilites (id),
  	FOREIGN KEY (item_id)
      REFERENCES items (id)
  	FOREIGN KEY (mount_id)
      REFERENCES mounts (id)
)

CREATE TABLE spells IF NOT EXISTS(
    id INT INCREMENT PRIMARY KEY,
  	name VARCHAR(50) NOT NULL,
  	description VARCHAR(255) NOT NULL,
  	cost INT NOT NULL,
  	lore ENUM NOT NULL,
)

CREATE TABLE abilities IF NOT EXISTS(
    id INT INCREMENT PRIMARY KEY,
  	name VARCHAR(50) NOT NULL,
  	description VARCHAR(255) NOT NULL,
  	cost INT NOT NULL,
  	passive BOOLEAN NOT NULL,
)

CREATE TABLE items IF NOT EXISTS(
    id INT INCREMENT PRIMARY KEY,
  	name VARCHAR(50) NOT NULL,
  	description VARCHAR(255) NOT NULL,
  	cost INT NOT NULL,
  	passive BOOLEAN NOT NULL,
)

CREATE TABLE mounts IF NOT EXISTS(
    id INT INCREMENT PRIMARY KEY,
  	name VARCHAR(50) NOT NULL,
  	description VARCHAR(255) NOT NULL,
  	cost INT NOT NULL,
  	flying BOOLEAN NOT NULL,
)
;
