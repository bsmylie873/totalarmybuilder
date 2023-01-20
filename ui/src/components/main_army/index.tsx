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
  Stack,
  TextField,
} from "@mui/material";
import { Box } from "@mui/system";
import { useState } from "react";
import { useParams } from "react-router-dom";

function getInitialState() {}

function addItem(unit: any) {}

function deleteItem(args: any) {}

const unitList = [
  {
    id: 1,
    name: "Spearmen",
    icon: <NorthIcon />,
  },
  {
    id: 2,
    name: "Swordsmen",
    icon: <ShieldIcon />,
  },
  {
    id: 3,
    name: "Archers",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 4,
    name: "Archers2",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 5,
    name: "Archers3",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 6,
    name: "Archers4",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 7,
    name: "Archers5",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 8,
    name: "Archers6",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 9,
    name: "Archers7",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 10,
    name: "Archers8",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 11,
    name: "Spearmen1",
    icon: <NorthIcon />,
  },
  {
    id: 12,
    name: "Swordsmen2",
    icon: <ShieldIcon />,
  },
  {
    id: 13,
    name: "Archers66",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 14,
    name: "Archers77",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 15,
    name: "Archers",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 16,
    name: "Archers88",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 17,
    name: "Archers99",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 18,
    name: "Archers11",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 19,
    name: "Archers22",
    icon: <ArrowOutwardIcon />,
  },
  {
    id: 20,
    name: "Archers33",
    icon: <ArrowOutwardIcon />,
  },
];

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

function getUnitsByFaction() {
  return fetch("/${id}/units").then((response) => response.json());
}

export default function PrimaryUnitList() {
  const [selectedUnit, setSelectedUnit] = useState<Unit | null>(null);
  const { compositionId } = useParams();
  const { data, error, isLoading } = useSWR(
    ["compositions", compositionId],
    getCompositionById
  );
  const currentComposition: Composition = data;
  if (isLoading) return <div>Loading</div>;

  return (
    <Stack
      sx={{
        display: "flex",
        justifyContent: "center",
        width: "100%",
        bgcolor: "background.paper",
      }}
    >
      {/* <h1>{currentComposition.name}</h1> */}
      <h4>Primary Army:</h4>
      <Autocomplete
        multiple={false}
        onChange={(_event, newUnit) => {
          setSelectedUnit(selectedUnit);
        }}
        disablePortal
        id="primary-unit-selection"
        options={options}
        sx={{ width: "100%" }}
        renderInput={(params) => <TextField {...params} label="" />}
      />
      <Box sx={{ height: 400, width: "100%", overflow: "auto" }}>
        <List dense>
          {unitList.map((item: any) => (
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
