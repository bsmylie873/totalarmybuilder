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
import { NavigationRoutes } from "../../constants";

const Home = () => {
  const navigate = useNavigate();

  return (
    <>
      <Container fixed>
        {
          <>
            <Title title={"TotalArmyBuilder"}></Title>
            <Stack spacing={8} style={{ marginTop: 100 }}>
              <Button
                variant="contained"
                startIcon={<ListIcon />}
                onClick={() => navigate(NavigationRoutes.MyBuilds)}
              >
                My Builds
              </Button>
              <Button
                variant="contained"
                startIcon={<SearchIcon />}
                onClick={() => navigate(NavigationRoutes.Search)}
              >
                Search Builds
              </Button>
              <Button
                variant="contained"
                startIcon={<FestivalIcon />}
                onClick={() => navigate(NavigationRoutes.CompositionNew)}
              >
                Create A New Composition
              </Button>
              <Button
                variant="contained"
                startIcon={<BookIcon />}
                onClick={() => navigate(NavigationRoutes.Blog)}
              >
                Blog (W.I.P)
              </Button>
              <Button
                variant="contained"
                startIcon={<QuestionMarkIcon />}
                onClick={() => navigate(NavigationRoutes.Tutorial)}
              >
                Tutorial (W.I.P)
              </Button>
            </Stack>
          </>
        }
      </Container>
    </>
  );
};
export default Home;
