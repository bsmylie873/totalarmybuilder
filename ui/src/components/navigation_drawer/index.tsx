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
import ListIcon from "@mui/icons-material/List";
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
      >
        <MenuIcon />
      </IconButton>
      <Drawer
        anchor="left"
        variant="persistent"
        open={open}
        onClose={toggleDrawer(false)}
      >
        <IconButton sx={{ mb: 2 }}>
          <CloseIcon onClick={toggleDrawer(false)} />
        </IconButton>

        <Divider sx={{ mb: 2 }} />

        <Box sx={{ mb: 2 }}>
          <ListItemButton href="/home">
            <HomeIcon></HomeIcon>
            <ListItemText primary="Home" />
          </ListItemButton>

          <ListItemButton href="/mybuilds">
            <ListIcon></ListIcon>
            <ListItemText primary="My Builds"></ListItemText>
          </ListItemButton>

          <ListItemButton href="/composition/new">
            <FestivalIcon></FestivalIcon>
            <ListItemText primary="Create a new build"></ListItemText>
          </ListItemButton>

          <ListItemButton href="/search">
            <SearchIcon></SearchIcon>
            <ListItemText primary="Search" />
          </ListItemButton>

          <ListItemButton href="/tutorial">
            <QuestionMarkIcon></QuestionMarkIcon>
            <ListItemText primary="Tutorial" />
          </ListItemButton>

          <ListItemButton href="/blog">
            <BookIcon></BookIcon>
            <ListItemText primary="Blog/F.A.Q" />
          </ListItemButton>
        </Box>
      </Drawer>
    </>
  );
}