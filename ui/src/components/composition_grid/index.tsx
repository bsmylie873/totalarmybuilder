import * as React from "react";
import { Box, Button } from "@mui/material";
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

const columns: GridColDef[] = [
  {
    field: "id",
    headerName: "Id",
    hide: true,
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
    hide: true,
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
  {
    disableColumnMenu: true,
    flex: 0.15,
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
  return (
    <div style={{ display: "flex", height: "100%" }}>
      <div style={{ flexGrow: 2 }}>
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
