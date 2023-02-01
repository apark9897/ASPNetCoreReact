import { Box, useMediaQuery } from "@mui/material";
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
        display={isNonMobileScreens ? "flex" : "block"}
        gap="0.5rem"
        justifyContent="space-between"
      >
        <Box
          flexBasis={isNonMobileScreens ? "42%" : undefined}
          mt={isNonMobileScreens ? undefined : "2rem"}
        >
          <PostsWidget />
        </Box>
      </Box>
    </Box>
  );
}

export default HomePage;
