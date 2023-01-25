import * as React from "react";
import ArrowOutwardIcon from "@mui/icons-material/ArrowOutward";
import ClearIcon from "@mui/icons-material/Clear";
import NorthIcon from "@mui/icons-material/North";
import ShieldIcon from "@mui/icons-material/Shield";
import { Composition } from "../../types/composition";
import { Unit } from "../../types/unit";
import useSWR from "swr";
import {
  Autocomplete,
  Avatar,
  IconButton,
  List,
  ListItem,
  ListItemAvatar,
  ListItemButton,
  ListItemText,
  MenuItem,
  Stack,
  TextField,
} from "@mui/material";
import { Box } from "@mui/system";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import {
  CompositionService,
  FactionService,
  UnitsService,
} from "../../services";

function getInitialState() {}

function addItem(unit: any) {}

function deleteItem(args: any) {}

const options = [
  { label: "Archers" },
  { label: "Spearmen" },
  { label: "Swordsmen" },
];

interface props {
  unit: Unit;
}

function getCompositionById() {
  return fetch("/composition/${id}").then((response) => response.json());
}

export default function PrimaryUnitList() {
  const [dropdownData, setDropDownData] = useState([]);
  const [unitListData, setUnitListData] = useState([]);
  const [compositionData, setCompositionData] = useState([]);
  const [selectedUnit, setSelectedUnit] = useState<Unit | null>(null);
  let { compositionId } = useParams();

  async function translateFactionIds(faction: number) {
    var factionResponse = FactionService.getFaction(faction);
    const factions = (await factionResponse).json();
    return factions;
  }

  async function getUnitByFactionData() {
    const factionUnitReponse = await FactionService.getFactionUnits(7);
    if (factionUnitReponse.status === 200) {
      const factionUnits = await factionUnitReponse.json();
      const factionsUnitsMapped = factionUnits.flatMap((x: any) => {
        return {
          id: x.id,
          name: x.name,
          cost: x.cost,
          avatarId: x.avatarId,
        };
      });
      setDropDownData(factionsUnitsMapped);
    }
  }

  async function getCompositionData() {
    const compositionResponse = await CompositionService.getComposition(
      compositionId as string
    );
    if (compositionResponse.status === 200) {
      const composition = await compositionResponse.json();
      const compositionMapped = composition.flatMap((x: any) => {
        return {
          id: x.id,
          name: x.name,
          author: x.author,
          battleType: x.battleType,
          faction: translateFactionIds(x.faction),
          budget: x.budget,
        };
      });
      setCompositionData(compositionMapped);
    }
  }

  async function getCompositionUnitData() {
    const compositionUnitResponse =
      await CompositionService.getCompositionUnits(compositionId as string);
    if (compositionUnitResponse.status === 200) {
      const compositionUnits = await compositionUnitResponse.json();
      const compositionUnitsMapped = compositionUnits.flatMap((x: any) => {
        return {
          id: x.id,
          name: x.name,
          cost: x.cost,
          avatarId: x.avatarId,
        };
      });
      setUnitListData(compositionUnitsMapped);
    }
  }

  useEffect(() => {
    getCompositionData();
    getCompositionUnitData();
    getUnitByFactionData();
  }, []);

  return (
    <Stack
      sx={{
        display: "flex",
        justifyContent: "center",
        width: "100%",
        bgcolor: "background.paper",
      }}
    >
      <h1>{compositionData}</h1>
      <h4>Primary Army:</h4>
      <TextField
        id="primary-unit-selection"
        select
        label="Select"
        sx={{ width: "100%" }}
        helperText="Please select some units..."
      >
        {dropdownData.map((option: Unit) => (
          <MenuItem key={option.id} value={option.name}>
            {option.name}
          </MenuItem>
        ))}
      </TextField>
      <Box sx={{ height: 400, width: "100%", overflow: "auto" }}>
        <List dense>
          {unitListData.map((item: any) => (
            <ListItem key={item.id}>
              <ListItemButton>
                <ListItemAvatar>
                  <Avatar>{item.icon}</Avatar>
                </ListItemAvatar>
                <ListItemText primary={item.name} />
              </ListItemButton>
              <IconButton edge="end" aria-label="delete">
                <ClearIcon />
              </IconButton>
            </ListItem>
          ))}
        </List>
      </Box>
    </Stack>
  );
}
