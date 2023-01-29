
import * as React from 'react';
import { Box, Typography, useTheme, useMediaQuery, Dialog } from '@mui/material';
import Form from './Form';

const LoginModal: React.FC<{ open: boolean, handleClose: () => void }> = ({ open, handleClose }) => {
  const theme = useTheme();
  const isNonMobileScreens = useMediaQuery("(min-width: 1000px)");
  return (
    <Dialog open={open} onClose={() => handleClose()}>
      <Box>
        <Box
          width="100%"
          bgcolor={theme.palette.background.alt}
          p="1rem 6%"
          textAlign="center"
        >
          <Typography fontWeight="bold" fontSize="32px" color="primary">
            TalkingMusic
          </Typography>
        </Box>
        <Box
          width={isNonMobileScreens ? "50%" : "93%"}
          p="2rem"
          m="2rem auto"
          borderRadius="1.5rem"
          bgcolor={theme.palette.background.alt}
        >
          <Typography fontWeight="500" variant="h5" sx={{ mb: "1.5rem" }}>
            Welcome to Socipedia, the Social Media for Sociopaths!
          </Typography>
          <Form />
        </Box>
      </Box>
    </Dialog>

  );
};

export default LoginModal;
