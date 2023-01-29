import { Typography } from '@mui/material';
import { styled } from '@mui/system';

const NavLink = styled(Typography)(({ theme }) => ({
  padding: '0.75rem 1rem',
  color: theme.palette.neutral.dark,
  fontWeight: 'bold',
  '&:hover': {
    background: theme.palette.neutral.light,
    borderRadius: '0.25rem',
    cursor: 'pointer'
  }
}));



export default NavLink;
