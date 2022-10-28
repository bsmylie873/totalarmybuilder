SET session_replication_role = 'replica';

INSERT INTO factions(name) values ('Beastmen');
INSERT INTO factions(name) values ('Bretonnia');
INSERT INTO factions(name) values ('Daemons of Chaos');
INSERT INTO factions(name) values ('Dark Elves');
INSERT INTO factions(name) values ('Dwarfs');
INSERT INTO factions(name) values ('The Empire');
INSERT INTO factions(name) values ('Grand Cathay');
INSERT INTO factions(name) values ('Greenskins');
INSERT INTO factions(name) values ('High Elves');
INSERT INTO factions(name) values ('Khorne');
INSERT INTO factions(name) values ('Kislev');
INSERT INTO factions(name) values ('Lizardmen');
INSERT INTO factions(name) values ('Norsca');
INSERT INTO factions(name) values ('Nurgle');
INSERT INTO factions(name) values ('Ogre Kingdoms');
INSERT INTO factions(name) values ('Skaven');
INSERT INTO factions(name) values ('Slaanesh');
INSERT INTO factions(name) values ('Tomb Kings');
INSERT INTO factions(name) values ('Tzeentch');
INSERT INTO factions(name) values ('Vampire Coast');
INSERT INTO factions(name) values ('Vampire Counts');
INSERT INTO factions(name) values ('Warriors of Chaos');
INSERT INTO factions(name) values ('Wood Elves');

INSERT INTO avatars(id, url) values (0, 'null');
INSERT INTO avatars(id, url) values (1, 'null1');

INSERT INTO units(name, cost, avatar_id) values ('Boyar', 1550, 1);
INSERT INTO units(name, cost, avatar_id) values ('Ice Witch (Ice)', 2062, 1);
INSERT INTO units(name, cost, avatar_id) values ('Ice Witch (Tempest)', 2062, 1);
INSERT INTO units(name, cost, avatar_id) values ('Kotaltyn', 2100, 1);
INSERT into units(name, cost, avatar_id) values ('Tzarina Katarin', 2312, 1);
INSERT into units(name, cost, avatar_id) values ('Patriarch', 1500, 1);
INSERT into units(name, cost, avatar_id) values ('Frost Maiden (Ice)', 1712, 1);
INSERT into units(name, cost, avatar_id) values ('Frost Maiden (Tempest)', 1712, 1);
INSERT into units(name, cost, avatar_id) values ('Armoured Kossars', 650, 1);
INSERT into units(name, cost, avatar_id) values ('Armoured Kossars (Great Weapons)', 700, 1);
INSERT into units(name, cost, avatar_id) values ('Tzar Guard', 1000, 1);
INSERT into units(name, cost, avatar_id) values ('Tzar Guard (Great Weapons)', 1100, 1);
INSERT into units(name, cost, avatar_id) values ('Kossars', 450, 1);
INSERT into units(name, cost, avatar_id) values ('Kossars (Spears)', 500, 1);
INSERT into units(name, cost, avatar_id) values ('Streltsi', 850, 1);
INSERT into units(name, cost, avatar_id) values ('Ice Guard (Swords)', 1100, 1);
INSERT into units(name, cost, avatar_id) values ('Ice Guard (Glaives)', 1150, 1);
INSERT into units(name, cost, avatar_id) values ('Kossovite Dervishes', 450, 1);
INSERT into units(name, cost, avatar_id) values ('Winged Lancers', 850, 1);
INSERT into units(name, cost, avatar_id) values ('Gryphon Legion', 1150, 1);
INSERT into units(name, cost, avatar_id) values ('War Bear Riders', 1600, 1);
INSERT into units(name, cost, avatar_id) values ('Horse Archers', 600, 1);
INSERT into units(name, cost, avatar_id) values ('Light War Sleds', 1100, 1);
INSERT into units(name, cost, avatar_id) values ('Heavy War Sleds', 1350, 1);
INSERT into units(name, cost, avatar_id) values ('Snow Leopard', 650, 1);
INSERT into units(name, cost, avatar_id) values ('Elemental Bear', 1900, 1);
INSERT into units(name, cost, avatar_id) values ('Little Grom', 650, 1);

INSERT into units_factions(unit_id, faction_id) values (0,10);
INSERT into units_factions(unit_id, faction_id) values (1,10);
INSERT into units_factions(unit_id, faction_id) values (2,10);
INSERT into units_factions(unit_id, faction_id) values (3,10);
INSERT into units_factions(unit_id, faction_id) values (4,10);
INSERT into units_factions(unit_id, faction_id) values (5,10);
INSERT into units_factions(unit_id, faction_id) values (6,10);
INSERT into units_factions(unit_id, faction_id) values (7,10);
INSERT into units_factions(unit_id, faction_id) values (8,10);
INSERT into units_factions(unit_id, faction_id) values (9,10);
INSERT into units_factions(unit_id, faction_id) values (10,10);
INSERT into units_factions(unit_id, faction_id) values (11,10);
INSERT into units_factions(unit_id, faction_id) values (12,10);
INSERT into units_factions(unit_id, faction_id) values (13,10);
INSERT into units_factions(unit_id, faction_id) values (14,10);
INSERT into units_factions(unit_id, faction_id) values (15,10);
INSERT into units_factions(unit_id, faction_id) values (16,10);
INSERT into units_factions(unit_id, faction_id) values (17,10);
INSERT into units_factions(unit_id, faction_id) values (18,10);
INSERT into units_factions(unit_id, faction_id) values (19,10);
INSERT into units_factions(unit_id, faction_id) values (20,10);
INSERT into units_factions(unit_id, faction_id) values (21,10);
INSERT into units_factions(unit_id, faction_id) values (22,10);
INSERT into units_factions(unit_id, faction_id) values (23,10);
INSERT into units_factions(unit_id, faction_id) values (24,10);
INSERT into units_factions(unit_id, faction_id) values (25,10);
INSERT into units_factions(unit_id, faction_id) values (26,10);

/*
INSERT into lords(unit_id) values (0);
INSERT into lords(unit_id) values (1);
INSERT into lords(unit_id) values (2);
INSERT into lords(unit_id) values (3);
INSERT into lords(unit_id) values (4);

INSERT into heroes(unit_id) values (5);
INSERT into heroes(unit_id) values (6);
INSERT into heroes(unit_id) values (7); */ 

SET session_replication_role = 'origin';