import { Container, Grid, Button, Box } from "@mui/material";
import React from "react";
import { useNavigate } from "react-router-dom";
import CompositionGrid from "../../components/composition_grid";
import { DataGrid, GridColDef, GridValueGetterParams } from "@mui/x-data-grid";

const Search = () => {
  return (
    <>
      <div>
        <CompositionGrid></CompositionGrid>
      </div>
    </>
  );
};

export default Search;
