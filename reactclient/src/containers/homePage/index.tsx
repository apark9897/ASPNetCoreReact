import { Box, Typography, useMediaQuery } from "@mui/material";
import React from "react";
import { useSelector } from "react-redux";

import PostsWidget from "containers/widgets/PostsWidget";
import CategoriesWidget from "containers/widgets/CategoriesWidget";

const HomePage: React.FC = () => {
  const isNonMobileScreens = useMediaQuery("(min-width:1000px)");

  return (
    <Box display="flex" flexWrap="wrap">
      <Box
        width={isNonMobileScreens ? "60%" : "100%"}
        padding="2rem 4%"
        display="block"
      >
        <Box>
          <PostsWidget />
        </Box>
      </Box>
      <Box
        width={isNonMobileScreens ? "40%" : "100%"}
        padding="2rem 4%"
        display="block"
      >
        <Box>
          <CategoriesWidget />
        </Box>
      </Box>
    </Box>
  );
}

export default HomePage;
