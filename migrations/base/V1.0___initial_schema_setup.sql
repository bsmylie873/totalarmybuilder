CREATE TABLE IF NOT EXISTS accounts (
    id serial PRIMARY KEY,
    email VARCHAR(255) UNIQUE NOT NULL,
    username VARCHAR(50) UNIQUE NOT NULL,
  	password VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS factions(
    id serial PRIMARY KEY,
  	name VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS avatars(
    id serial PRIMARY KEY,
  	url VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS compositions(
    id serial PRIMARY KEY,
    name VARCHAR(255) UNIQUE NOT NULL,
  	battle_type INT not NULL,
  	faction_id INT NOT NULL,
  	avatar_id INT NOT NULL,
    date_created TIMESTAMP NOT NULL,
  	FOREIGN KEY (faction_id)
      REFERENCES factions (id),
  	FOREIGN KEY (avatar_id)
      REFERENCES avatars (id)
);

CREATE TABLE IF NOT EXISTS units(
    id serial PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
  	cost INT NOT NULL,
  	avatar_id INT NOT NULL,
  	FOREIGN KEY (avatar_id)
      REFERENCES avatars (id)
);

CREATE TABLE IF NOT EXISTS lords(
    id serial PRIMARY KEY,
  	unit_id INT NOT NULL,
  	FOREIGN KEY (unit_id)
      REFERENCES units (id)
);

CREATE TABLE IF NOT EXISTS heroes(
    id serial PRIMARY KEY,
  	unit_id INT NOT NULL,
  	FOREIGN KEY (unit_id)
      REFERENCES units (id)
);

CREATE TABLE IF NOT EXISTS accounts_compositions (
    id serial PRIMARY KEY,
    account_id INT NOT NULL,
    composition_id INT NOT NULL,
  	FOREIGN KEY (account_id)
      REFERENCES accounts (id),
  	FOREIGN KEY (composition_id)
      REFERENCES compositions (id)
);

CREATE TABLE IF NOT EXISTS compositions_units(
    id serial PRIMARY KEY,
    composition_id INT NOT NULL,
  	unit_id INT NOT NULL,
  	FOREIGN KEY (composition_id)
      REFERENCES compositions (id),
  	FOREIGN KEY (unit_id)
      REFERENCES units (id)
);

CREATE TABLE IF NOT EXISTS units_factions(
    id serial PRIMARY KEY,
    unit_id INT NOT NULL,
  	faction_id INT NOT NULL,
  	FOREIGN KEY (unit_id)
      REFERENCES units (id),
  	FOREIGN KEY (faction_id)
      REFERENCES factions (id)
);
