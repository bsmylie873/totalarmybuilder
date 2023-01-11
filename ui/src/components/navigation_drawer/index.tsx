import React from "react";
import { useState } from "react";
import Drawer from "@mui/material/Drawer";
import MenuIcon from "@mui/icons-material/Menu";
import {
  IconButton,
  Box,
  Divider,
  ListItemButton,
  ListItemText,
} from "@mui/material";
import BookIcon from "@mui/icons-material/Book";
import FestivalIcon from "@mui/icons-material/Festival";
import HomeIcon from "@mui/icons-material/Home";
import QuestionMarkIcon from "@mui/icons-material/QuestionMark";
import SearchIcon from "@mui/icons-material/Search";
import CloseIcon from "@mui/icons-material/Close";

export default function NavigationDrawer() {
  const [open, setState] = useState(false);

  const toggleDrawer = (open: any) => (event: any) => {
    if (
      event.type === "keydown" &&
      (event.key === "Tab" || event.key === "Shift")
    ) {
      return;
    }
    setState(open);
  };

  return (
    <>
      <IconButton
        edge="start"
        color="inherit"
        aria-label="open drawer"
        onClick={toggleDrawer(true)}
        sx={{ mr: 2, display: { xs: "block", sm: "none" } }}
      >
        <MenuIcon />
      </IconButton>
      <Drawer
        anchor="left" //from which side the drawer slides in
        variant="persistent" //if and how easily the drawer can be closed
        open={open} //if open is true, drawer is shown
        onClose={toggleDrawer(false)} //function that is called when the drawer should closefunction that is called when the drawer should open
      >
        <Box
          sx={{
            p: 2,
            height: 1,
            backgroundColor: "#dbc8ff",
          }}
        ></Box>

        <IconButton sx={{ mb: 2 }}>
          <CloseIcon onClick={toggleDrawer(false)} />
        </IconButton>

        <Divider sx={{ mb: 2 }} />

        <Box sx={{ mb: 2 }}>
          <ListItemButton>
            <HomeIcon></HomeIcon>
            <ListItemText primary="Home" />
          </ListItemButton>

          <ListItemButton>
            <FestivalIcon></FestivalIcon>
            <ListItemText primary="My Builds" />
          </ListItemButton>

          <ListItemButton>
            <SearchIcon></SearchIcon>
            <ListItemText primary="Search" />
          </ListItemButton>

          <ListItemButton>
            <QuestionMarkIcon></QuestionMarkIcon>
            <ListItemText primary="Tutorial" />
          </ListItemButton>

          <ListItemButton>
            <BookIcon></BookIcon>
            <ListItemText primary="Blog/F.A.Q" />
          </ListItemButton>
        </Box>
      </Drawer>
    </>
  );
}
