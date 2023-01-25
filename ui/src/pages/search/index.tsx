import { Container, Grid, Button, Box } from "@mui/material";
import React from "react";
import { useNavigate, useParams } from "react-router-dom";
import CompositionGrid from "../../components/composition_grid";
import { DataGrid, GridColDef, GridValueGetterParams } from "@mui/x-data-grid";

const Search = () => {
  const { searchValue } = useParams<{ searchValue: string }>();
  return (
    <>
      <div>
        <CompositionGrid></CompositionGrid>
      </div>
    </>
  );
};

export default Search;
