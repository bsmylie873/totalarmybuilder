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
import { CompositionService, FactionService } from "../../services";
import { useEffect, useState } from "react";
import toast from "react-hot-toast";

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
    field: "battleType",
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
  const [gridData, setGridData] = useState([]);

  async function translateFactionIds(faction: number) {
    var factionResponse = FactionService.getFaction(faction);
    const factions = (await factionResponse).json();
    return factions;
  }

  const getCompositionsData = async () => {
    const compositionsResponse = await CompositionService.getCompositions();
    if (compositionsResponse.status === 200) {
      const compositions = await compositionsResponse.json();
      const compositionsMapped = compositions.flatMap((x: any) => {
        return {
          id: x.id,
          name: x.name,
          author: x.author,
          battleType: x.battleType,
          faction: translateFactionIds(x.faction),
          budget: x.budget,
        };
      });
      debugger;
      setGridData(compositionsMapped);
      toast.success("Data successfully loaded!");
      console.log(compositionsMapped);
    } else {
      toast.error("No data found!");
    }
  };

  useEffect(() => {
    getCompositionsData();
  }, []);

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
          rows={gridData}
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
