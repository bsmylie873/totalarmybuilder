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

CREATE TABLE lords IF NOT EXISTS(
    id INT INCREMENT PRIMARY KEY,
  	unit_id INT NOT NULL,
  	FOREIGN KEY (unit_id)
      REFERENCES units (id)
)

CREATE TABLE heroes IF NOT EXISTS(
    id INT INCREMENT PRIMARY KEY,
  	unit_id INT NOT NULL,
  	FOREIGN KEY (unit_id)
      REFERENCES units (id)
);
