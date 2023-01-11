import * as React from "react";
import Box from "@mui/material/Box";
import {
  DataGrid,
  GridColDef,
  GridToolbar,
  GridValueGetterParams,
} from "@mui/x-data-grid";
import type {} from "@mui/x-data-grid/themeAugmentation";

const columns: GridColDef[] = [
  {
    field: "id",
    headerName: "Id",
    editable: false,
  },
  {
    field: "name",
    headerName: "Name",
    editable: false,
  },
  {
    field: "author",
    headerName: "Author",
    editable: false,
  },
  {
    field: "battle_type",
    headerName: "Battle Type",
    editable: false,
  },
  {
    field: "faction",
    headerName: "Faction",
    editable: false,
  },
  {
    field: "budget",
    headerName: "Budget",
    type: "number",
    editable: false,
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
];

export default function CompositionGrid() {
  return (
    <Box sx={{ height: 400, width: "100%" }}>
      <DataGrid
        autoHeight
        rows={rows}
        columns={columns}
        pageSize={10}
        rowsPerPageOptions={[10]}
        disableSelectionOnClick
        components={{ Toolbar: GridToolbar }}
      />
    </Box>
  );
}
