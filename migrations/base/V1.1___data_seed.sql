SET
session_replication_role = 'replica';

INSERT INTO factions(name)
VALUES ('Beastmen');
INSERT INTO factions(name)
VALUES ('Bretonnia');
INSERT INTO factions(name)
VALUES ('Daemons of Chaos');
INSERT INTO factions(name)
VALUES ('Dark Elves');
INSERT INTO factions(name)
VALUES ('Dwarfs');
INSERT INTO factions(name)
VALUES ('The Empire');
INSERT INTO factions(name)
VALUES ('Grand Cathay');
INSERT INTO factions(name)
VALUES ('Greenskins');
INSERT INTO factions(name)
VALUES ('High Elves');
INSERT INTO factions(name)
VALUES ('Khorne');
INSERT INTO factions(name)
VALUES ('Kislev');
INSERT INTO factions(name)
VALUES ('Lizardmen');
INSERT INTO factions(name)
VALUES ('Norsca');
INSERT INTO factions(name)
VALUES ('Nurgle');
INSERT INTO factions(name)
VALUES ('Ogre Kingdoms');
INSERT INTO factions(name)
VALUES ('Skaven');
INSERT INTO factions(name)
VALUES ('Slaanesh');
INSERT INTO factions(name)
VALUES ('Tomb Kings');
INSERT INTO factions(name)
VALUES ('Tzeentch');
INSERT INTO factions(name)
VALUES ('Vampire Coast');
INSERT INTO factions(name)
VALUES ('Vampire Counts');
INSERT INTO factions(name)
VALUES ('Warriors of Chaos');
INSERT INTO factions(name)
VALUES ('Wood Elves');

INSERT INTO avatars(id, url)
VALUES (0, 'null');
INSERT INTO avatars(id, url)
VALUES (1, 'null1');

/* Kislev */
INSERT INTO units(name, cost, avatar_id)
VALUES ('Boyar', 1550, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Ice Witch (Ice)', 2062, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Ice Witch (Tempest)', 2062, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Kotaltyn', 2100, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Tzarina Katarin', 2312, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Patriarch', 1500, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Frost Maiden (Ice)', 1712, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Frost Maiden (Tempest)', 1712, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Armoured Kossars', 650, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Armoured Kossars (Great Weapons)', 700, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Tzar Guard', 1000, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Tzar Guard (Great Weapons)', 1100, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Kossars', 450, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Kossars (Spears)', 500, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Streltsi', 850, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Ice Guard (Swords)', 1100, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Ice Guard (Glaives)', 1150, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Kossovite Dervishes', 450, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Winged Lancers', 850, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Gryphon Legion', 1150, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('War Bear Riders', 1600, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Horse Archers', 600, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Light War Sleds', 1100, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Heavy War Sleds', 1350, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Snow Leopard', 650, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Elemental Bear', 1900, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Little Grom', 650, 1);

INSERT INTO units_factions(unit_id, faction_id)
VALUES (1, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (2, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (3, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (4, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (5, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (6, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (7, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (8, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (9, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (10, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (11, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (12, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (13, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (14, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (15, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (16, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (17, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (18, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (19, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (20, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (21, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (22, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (23, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (24, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (25, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (26, 11);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (27, 11);

INSERT INTO lords(unit_id)
VALUES (1);
INSERT INTO lords(unit_id)
VALUES (2);
INSERT INTO lords(unit_id)
VALUES (3);
INSERT INTO lords(unit_id)
VALUES (4);
INSERT INTO lords(unit_id)
VALUES (5);

INSERT INTO heroes(unit_id)
VALUES (6);
INSERT INTO heroes(unit_id)
VALUES (7);
INSERT INTO heroes(unit_id)
VALUES (8);

/*Grand Cathay*/
INSERT INTO units(name, cost, avatar_id)
VALUES ('Lord Magistrate', 1300, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Dragon-blooded Shugengan Lord (Yin)', 2062, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Dragon-blooded Shugengan Lord (Yang)', 2062, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Zhao Ming the Iron Dragon', 3112, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Miao Ying the Storm Dragon', 3362, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Alchemist', 1512, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Astromancer', 1562, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Peasant Long Spearmen', 350, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Jade Warriors', 500, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Jade Warriors (Halberds)', 700, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Celestial Dragon Guard', 1050, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Peasant Archers', 400, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Iron Hail Gunners', 500, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Jade Warrior Crossbowmen', 600, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Jade Warrior Crossbowmen (Shields)', 700, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Crane Gunners', 1000, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Celestial Dragon Crossbowmen', 1050, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Peasant Horsemen', 400, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Jade Lancers', 800, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Great Longma Riders', 1400, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Terracotta Sentinel', 1600, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Sky Lantern', 800, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Sky-junk', 1500, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Grand Cannon', 900, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Wu Xing War Compass', 950, 1);
INSERT INTO units(name, cost, avatar_id)
VALUES ('Fire Rain Rocket', 1100, 1);

INSERT INTO units_factions(unit_id, faction_id)
VALUES (28, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (29, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (30, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (31, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (32, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (33, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (34, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (35, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (36, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (37, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (38, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (39, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (40, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (41, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (42, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (43, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (44, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (45, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (46, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (47, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (48, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (49, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (50, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (51, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (52, 7);
INSERT INTO units_factions(unit_id, faction_id)
VALUES (53, 7);

INSERT INTO lords(unit_id)
VALUES (28);
INSERT INTO lords(unit_id)
VALUES (29);
INSERT INTO lords(unit_id)
VALUES (30);
INSERT INTO lords(unit_id)
VALUES (31);
INSERT INTO lords(unit_id)
VALUES (32);

INSERT INTO heroes(unit_id)
VALUES (33);
INSERT INTO heroes(unit_id)
VALUES (34);
INSERT INTO heroes(unit_id)
VALUES (35);

INSERT INTO accounts(username, email, password)
VALUES('JohnDoe', 'johndoe@example.com', '$2a$11$78nO9BRsnqm6f6U0VngPLecM9yJLX02Vfqn3OO0xIGVpLwd13ZtRS');

INSERT INTO compositions(name, battle_type, faction_id, avatar_id, budget, date_created, wins, losses)
VALUES('Comp1', 'Land Battles', 1, 1, 9000, '2011-05-16 15:36:38', 0, 0 );

INSERT INTO compositions(name, battle_type, faction_id, avatar_id, budget, date_created, wins, losses)
VALUES('james', 'Domination', 2, 1, 7220, '2011-06-16 18:36:38', 1, 0 );

INSERT INTO compositions(name, battle_type, faction_id, avatar_id, budget, date_created, wins, losses)
VALUES('purple', 'Domination', 2, 1, 10000, '2015-06-16 18:36:38', 1, 1 );

SET
session_replication_role = 'origin';

