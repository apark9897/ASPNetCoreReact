import { useState, FC, useEffect } from 'react';
import {
  Box,
  IconButton,
  InputBase,
  Typography,
  Select,
  MenuItem,
  FormControl,
  useTheme,
  useMediaQuery
} from '@mui/material';
import {
  Search,
  Message,
  DarkMode,
  LightMode,
  Notifications,
  Help,
  Menu,
  Close
} from '@mui/icons-material';
import { useDispatch, useSelector } from 'react-redux';
import { setMode, setLogout, IndexState } from 'state';
import { useNavigate } from 'react-router-dom';
import FlexBetween from 'components/FlexBetween';
import AccountMenu from './AccountMenu';
import NavLink from 'components/NavLink';
import SignInMenu from './SignInMenu';

const Navbar: FC = (props) => {
  console.log(props);
  const [isMobileMenuToggled, setIsMobileMenuToggled] = useState(false);
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const loggedIn = Boolean(useSelector((state: IndexState) => state.user));
  const isNonMobileScreen = useMediaQuery('(min-width: 1000px');

  const theme = useTheme();
  const neutralLight = theme.palette.neutral.light;
  const dark = theme.palette.neutral.dark;
  const background = theme.palette.background.default;
  const primaryLight = theme.palette.primary.light;
  const alt = theme.palette.background.alt;

  return (
    <FlexBetween padding='1rem 6%' bgcolor={alt}>
      <FlexBetween gap='2.5rem'>
        <Typography
          fontWeight='bold'
          fontSize='clamp(1rem, 2rem, 2.25rem)'
          color='primary'
          onClick={() => navigate('/')}
          sx={{
            '&:hover': {
              color: primaryLight,
              cursor: 'pointer'
            }
          }}
        >
          TalkingMusic
        </Typography>
        {isNonMobileScreen && (
          <FlexBetween gap='1rem'>
            <NavLink onClick={() => navigate('/categories')}>Categories</NavLink>
            <NavLink onClick={() => navigate('/users')}>Users</NavLink>
            <NavLink>Rules/FAQs</NavLink>
          </FlexBetween>
        )}
      </FlexBetween>

      {/*Desktop nav */}
      {isNonMobileScreen ? (
        <FlexBetween gap='2rem'>
          <IconButton onClick={() => dispatch(setMode())}>
            {theme.palette.mode === "dark" ? (
              <DarkMode sx={{ fontSize: '25px' }} />
            ) : (
              <LightMode sx={{ color: dark, fontSize: '25px' }} />
            )}
          </IconButton>
          <Message sx={{ fontSize: '25px' }} />
          <Notifications sx={{ fontSize: '25px' }} />
          {loggedIn ? <AccountMenu /> : <SignInMenu />}

        </FlexBetween>
      )
        : (
          <IconButton
            onClick={() => setIsMobileMenuToggled(!isMobileMenuToggled)}
          >
            <Menu />
          </IconButton>
        )}

      {/* MOBILE NAV */}
      {!isNonMobileScreen && isMobileMenuToggled && (
        <Box
          position="fixed"
          right="0"
          bottom="0"
          height="100%"
          zIndex="10"
          maxWidth="500px"
          minWidth="300px"
          bgcolor={background}
        >
          {/* CLOSE ICON */}
          <Box display="flex" justifyContent="flex-end" p="1rem">
            <IconButton
              onClick={() => setIsMobileMenuToggled(!isMobileMenuToggled)}
            >
              <Close />
            </IconButton>
          </Box>

          {/* MENU ITEMS */}
          <FlexBetween
            display="flex"
            flexDirection="column"
            justifyContent="center"
            alignItems="center"
            gap="2rem"
          >
            <NavLink onClick={() => navigate('/categories')}>Categories</NavLink>
            <NavLink onClick={() => navigate('/users')}>Users</NavLink>
            <NavLink>Rules/FAQs</NavLink>
            <IconButton
              onClick={() => dispatch(setMode())}
              sx={{ fontSize: "25px" }}
            >
              {theme.palette.mode === "dark" ? (
                <DarkMode sx={{ fontSize: "25px" }} />
              ) : (
                <LightMode sx={{ color: dark, fontSize: "25px" }} />
              )}
            </IconButton>
            <Message sx={{ fontSize: "25px" }} />
            <Notifications sx={{ fontSize: "25px" }} />
            {loggedIn ? <AccountMenu /> : <SignInMenu />}
          </FlexBetween>
        </Box>
      )}
    </FlexBetween>
  );
}

export default Navbar;
