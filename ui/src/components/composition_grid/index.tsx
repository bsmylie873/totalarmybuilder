import * as React from "react";
import { Button } from "@mui/material";
import {
  DataGrid,
  GridColDef,
  GridRenderCellParams,
  GridToolbarColumnsButton,
  GridToolbarContainer,
  GridToolbarDensitySelector,
  GridToolbarFilterButton,
} from "@mui/x-data-grid";
import type {} from "@mui/x-data-grid/themeAugmentation";
import { Link } from "react-router-dom";
import useSWR from "swr";

const columns: GridColDef[] = [
  {
    field: "id",
    headerName: "Id",
    hide: true,
    editable: false,
    flex: 1,
    align: "center",
    headerAlign: "center",
  },
  {
    field: "name",
    headerName: "Name",
    editable: false,
    flex: 1,
    align: "center",
    headerAlign: "center",
  },
  {
    field: "author",
    headerName: "Author",
    hide: true,
    editable: false,
    flex: 1,
    align: "center",
    headerAlign: "center",
  },
  {
    field: "battle_type",
    headerName: "Battle Type",
    editable: false,
    flex: 1,
    align: "center",
    headerAlign: "center",
  },
  {
    field: "faction",
    headerName: "Faction",
    editable: false,
    flex: 1,
    align: "center",
    headerAlign: "center",
  },
  {
    field: "budget",
    headerName: "Budget",
    type: "number",
    editable: false,
    flex: 1,
    align: "center",
    headerAlign: "center",
  },
  {
    disableColumnMenu: true,
    flex: 1,
    align: "center",
    headerAlign: "center",
    sortable: false,
    field: "actions",
    headerName: "Actions",
    renderCell: (params: GridRenderCellParams): React.ReactElement => {
      const navigationTarget = `/composition/${params.id}`;
      return (
        <Button component={Link} color="inherit" to={navigationTarget}>
          View
        </Button>
      );
    },
  },
];

const rows = [
  {
    id: 1,
    name: "Hungry Hungry Ogres",
    author: "OgreTyrant985",
    battle_type: "Land Battles",
    faction: "Ogre Kingdoms",
    budget: 9000,
  },

  {
    id: 2,
    name: "Chaos Knights Are Bad",
    author: "bigchungus98",
    battle_type: "Domination",
    faction: "Warriors Of Chaos",
    budget: 120000,
  },

  {
    id: 3,
    name: "Kislev Draft1",
    author: "user8573666",
    battle_type: "Domination",
    faction: "Beastmen",
    budget: 9000,
  },

  {
    id: 4,
    name: "New Build",
    author: "admin",
    battle_type: "Land Battles",
    faction: "Beastmen",
    budget: 100000000,
  },

  {
    id: 5,
    name: "The Empire ENDURES",
    author: "SigmarSon32",
    battle_type: "Domination",
    faction: "The Empire",
    budget: 9000,
  },

  {
    id: 6,
    name: "Malekith Carry build",
    author: "jeep013",
    battle_type: "Domination",
    faction: "Dark Elves",
    budget: 9000,
  },

  {
    id: 7,
    name: "Malus Carry build",
    author: "jeep013",
    battle_type: "Domination",
    faction: "Dark Elves",
    budget: 9000,
  },

  {
    id: 8,
    name: "Morathi Carry build",
    author: "jeep013",
    battle_type: "Domination",
    faction: "Dark Elves",
    budget: 9000,
  },

  {
    id: 9,
    name: "New Build testing build",
    author: "admin",
    battle_type: "Domination",
    faction: "Grand Cathay",
    budget: 9000,
  },

  {
    id: 10,
    name: "The French",
    author: "ihatespeakingenglish",
    battle_type: "Land Battles",
    faction: "Bretonnia",
    budget: 9000,
  },

  {
    id: 11,
    name: "KNOWLEDGE",
    author: "freebirdsolo",
    battle_type: "Land Battles",
    faction: "Tzeentch",
    budget: 9000,
  },
];

function CustomToolbar() {
  return (
    <GridToolbarContainer>
      <GridToolbarColumnsButton />
      <GridToolbarFilterButton />
      <GridToolbarDensitySelector />
    </GridToolbarContainer>
  );
}

export default function CompositionGrid() {
  function getCompositions() {
    return fetch("/compositions/").then((response) => response.json());
  }

  const { data, error, isLoading } = useSWR(["compositions"], getCompositions);

  console.log(data);

  return (
    <div
      style={{
        display: "flex",
        height: "100%",
      }}
    >
      <div
        style={{
          flexGrow: 2,
          display: "flex",
          height: "100%",
          justifyContent: "center",
        }}
      >
        <DataGrid
          autoHeight
          rows={rows}
          columns={columns}
          pageSize={10}
          rowsPerPageOptions={[10]}
          disableSelectionOnClick
          components={{ Toolbar: CustomToolbar }}
        />
      </div>
    </div>
  );
}
