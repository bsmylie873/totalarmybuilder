import {
  Avatar,
  Box,
  Button,
  Container,
  Grid,
  Stack,
  TextField,
} from "@mui/material";
import BookIcon from "@mui/icons-material/Book";
import FestivalIcon from "@mui/icons-material/Festival";
import ListIcon from "@mui/icons-material/List";
import QuestionMarkIcon from "@mui/icons-material/QuestionMark";
import SearchIcon from "@mui/icons-material/Search";
import React from "react";
import { Title } from "../../components";
import { useNavigate } from "react-router-dom";

const Home = () => {
  const navigate = useNavigate();

  return (
    <>
      <Container fixed>
        {
          <Stack spacing={8} style={{ marginTop: 100 }}>
            <Button
              variant="contained"
              startIcon={<ListIcon />}
              onClick={() => navigate("/mybuilds")}
            >
              My Builds
            </Button>
            <Button
              variant="contained"
              startIcon={<SearchIcon />}
              onClick={() => navigate("/search")}
            >
              Search Builds
            </Button>
            <Button
              variant="contained"
              startIcon={<QuestionMarkIcon />}
              onClick={() => navigate("/tutorial")}
            >
              Tutorial
            </Button>
            <Button
              variant="contained"
              startIcon={<BookIcon />}
              onClick={() => navigate("/blog")}
            >
              Blog
            </Button>
          </Stack>
        }
      </Container>
    </>
  );
};
export default Home;
