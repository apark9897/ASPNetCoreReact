import { Box, Typography, useMediaQuery } from "@mui/material";
import React from "react";
import { useSelector } from "react-redux";

import PostsWidget from "containers/widgets/PostsWidget";

const HomePage: React.FC = () => {
  const isNonMobileScreens = useMediaQuery("(min-width:1000px)");

  return (
    <Box>
      <Box
        width="100%"
        padding="2rem 6%"
        display="block"
      >
        <Box>
          <Typography variant="h3" fontWeight="600">Popular Posts</Typography>
          <PostsWidget />
        </Box>
      </Box>
    </Box>
  );
}

export default HomePage;
