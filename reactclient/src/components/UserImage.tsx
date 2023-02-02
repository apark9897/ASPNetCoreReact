import { Box } from '@mui/material';
import { styled } from '@mui/system';
import config from "config";
const ASPBACKEND = config.ASPBACKEND;

const UserImage = ({ image = '', size = '60px' }) => {
  return (
    <Box width={size} height={size}>
      <img
        style={{ objectFit: 'cover', borderRadius: '50%' }}
        width={size}
        height={size}
        alt='user'
        src={`http://localhost:3000/logo192.png`}
      />
    </Box>
  )
}

export default UserImage;
