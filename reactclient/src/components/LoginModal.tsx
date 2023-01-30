
import * as React from 'react';
import { Box, Typography, useTheme, useMediaQuery, Dialog } from '@mui/material';
import Form from './Form';

const LoginModal: React.FC<{ open: boolean, handleClose: () => void }> = ({ open, handleClose }) => {
  const theme = useTheme();
  const isNonMobileScreens = useMediaQuery("(min-width: 1000px)");
  return (
    <Dialog
      open={open}
      onClose={() => handleClose()}
      PaperProps={{
        style: { borderRadius: "1.5rem" }
      }}
      scroll="body"
    >
      <Box
        p="1rem"
        bgcolor={theme.palette.background.alt}
        borderRadius="1.5rem">
        <Typography fontWeight="500" variant="h5" sx={{ mb: "1.5rem" }} textAlign="center">
          Welcome to TalkingMusic!
        </Typography>
        <Form closeModal={handleClose} />
      </Box>
    </Dialog>

  );
};

export default LoginModal;
