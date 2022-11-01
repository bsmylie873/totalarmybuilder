# TotalArmyBuilder

This repository is for the Total War Army Builder COE project for Unosquare.

## What is the application being made?

The Total War Army Builder is an application designed to be used in tandem with the Total War game franchise, specifically with the Total War Warhammer subfranchise. It is focused around allowing users to create, modify and share army compositions for the two mulitplayer modes found within the game: Land Battles and Domination, each with different restrictions and options available. Anyone using the application will be able to also search and filter through their created compositions as well as compositions created (and made public) by other users. The user will be able to restrict access to only themselves if requested. Each composition will also be updated with wins or losses in the game, manually updated by the composition created.

## Why is the application being made?
The Total War Warhammer franchise consists of 3 titles; Total War: Warhammer, Total War: Warhammer II and Total War: Warhammer III, with each building upon each other adding new factions, units and maps amongst other features. The games are quite intensive in terms of performance, and so players are forced to have access to a appropriate laptop or desktop in order to experiment with different builds. There is no functinality in-game to share compositions with other players, the only option is to export the army composition as a file. An existing service does exist, hosted at https://www.honga.net/totalwar/, however the focuses mostly on the single player experience and has not been updated for Total War: Warhammer 3. 

## How is the application being made?

A user will need to go through an account creation process which will record parameters such as which games/DLCs are owned, it may be possible to link to their Steam/Epic account and automate this process. When logged in a user can create, modify and delete army compositions. The user will have to provide an email address, a username, a password, the data listed above and signup with Google OAuth.

### When creating an army composition, the user needs:
* To select which game mode the composition is for, Land Battles or Domination.

### For making both Land Battles and Domination compositions the user needs:
* To select a faction to build from.
* To select the gold budget, by default this will use the values found in Quick Battles.
* To provide a name for the army composition, e.g Khorne Rush.
* To provide an avatar for the army composition from a curated selection of in-game unit cards..
* Optionally provide a brief description on how to play the army composition, such as optimal opponent factions.

### For making a Land Battles composition:
* Create a composition following the Land Battles ruleset.

### For making a Domination composition:
* Create a composition following the Domination ruleset, including a starting army and a reinforcement pool.

After a user creates an army composition, they will see it amongst any other army compositions they have made stored within their profile. The user will be able to search this repository of army composition using keyword matching as well as by using various filters (Game Mode, Faction, Battle Count, Wins, Losses, Win/Loss Ratio, Gold Budget etc.) The repository should be displayed in a list format whereby the thumbnail will be present on the left hand side with some of the most pertinent army list details adjacent. Selecting an item will load the army list and allow the user to modify parameters. The user will also be able to delete lists from the list view without a bin icon present on the right. Some visualisation for the win/loss statistics should be provided for each composition.

Eventually this should be expanded to allow users to view other users' compositions, with a possible rating system and the ability to leave comments. Authors of multiple highly-rated compositions may get a leaderboard of their own.

### Entity Relationship Diagram:

[![](https://mermaid.ink/img/pako:eNqFkUEOgjAQRa_SzNp4gO4qYEKiYABdNTETGJQEiillYcS7WwwaRQxdTWfeb-fn3yCtMwIOpN0CTxorqdj77GMvYl23XHYdc8LtLoz9xA8DxlmqCQ01n_AnMGj2gZ_EPV0rg4Waw8VBJCKy_Bnn0LVwhk0m2OPGE64XrUIRudPrj0S9zynR0_8P_fp7ZHL85rM940yq79u_CWOwgIp0hUVmw7r1MwnmTBVJ4LbMKMe2NBKkulsUW1PHV5UCN7qlBbSXzMY1JAw8x7Kh-wN_B4tT?type=png)](https://mermaid.live/edit#pako:eNqFkUEOgjAQRa_SzNp4gO4qYEKiYABdNTETGJQEiillYcS7WwwaRQxdTWfeb-fn3yCtMwIOpN0CTxorqdj77GMvYl23XHYdc8LtLoz9xA8DxlmqCQ01n_AnMGj2gZ_EPV0rg4Waw8VBJCKy_Bnn0LVwhk0m2OPGE64XrUIRudPrj0S9zynR0_8P_fp7ZHL85rM940yq79u_CWOwgIp0hUVmw7r1MwnmTBVJ4LbMKMe2NBKkulsUW1PHV5UCN7qlBbSXzMY1JAw8x7Kh-wN_B4tT)

### MVP (Minimum-Viable Product)
* User account creation/login system.
* Create army compositions for each game mode (following appopriate rule-sets).
* Track wins/losses for each army composition.
* Allow modification and deleting of existing army compositions.

### V1
* Allow optional sharing of army compositions.
* Add public list of (public) army compositions.
* Add comments for each army composition page.
* Add visualisation for wins/losses.

### V2
* Allow forking of existing public army compositions.
* Allow export of army lists to be imported directly into Total War: Warhammer III (needs further investigation).
* Allow authors to add replays of the army list (files or YouTube video links) in the description of the list.

## Misc. Links
ER Diagram: https://lucid.app/lucidchart/f1948f56-e07a-4611-a066-1d924d4d9c88/edit?viewport_loc=-267%2C-26%2C2460%2C1134%2C0_0&invitationId=inv_8920fb5c-98ba-4b28-b4b6-6f1213ef623c
