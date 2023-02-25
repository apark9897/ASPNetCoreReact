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
import { useNavigate, useParams } from 'react-router-dom';
import FlexBetween from 'components/FlexBetween';
import config from "config";
import axios from 'axios';
import WidgetWrapper from 'components/WidgetWrapper';
import dayjs from 'dayjs';
import relativeTime from 'dayjs/plugin/relativeTime';
dayjs.extend(relativeTime);
const ASPBACKEND = config.ASPBACKEND;

interface post {
  $id: string,
  categoryId: number,
  categoryTitle: string,
  content: string,
  postId: number,
  title: string,
  userId: number,
  username: string,
  createdDate: string,
  views: number
}

const MainPost: FC = (props) => {
  const [post, setPost] = useState<post>({} as post);
  const [comments, setComments] = useState([]);
  const { postId } = useParams();
  const { palette } = useTheme();
  const main = palette.neutral.main;
  const light = palette.neutral.light;
  const isNonMobileScreens = useMediaQuery("(min-width:1000px)");

  const getPost = async () => {
    const response = await axios(`${ASPBACKEND}posts/${postId}`);
    setPost(response.data);
    console.log(post);
  }

  const getComments = async () => {
    const response = await axios(`${ASPBACKEND}comments`, { params: { postId } });
    setComments(response.data);
    console.log(comments);
  }

  useEffect(() => {
    getPost();
    getComments();
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  return (
    <WidgetWrapper m="1rem 0" display="flex" flexDirection="column" >
      <Box>
        <Typography color={main} variant="subtitle1">{`${post.username}, ${dayjs(post.createdDate).fromNow()}, in ${post.categoryTitle}`}</Typography>
      </Box>
      <Box paddingTop="0.5rem" paddingBottom="1rem">
        <Typography variant="h3" fontWeight="600">{post.title}</Typography>
      </Box>
      <Box paddingBottom="1rem">
        <Typography color={main} variant="body1">{post.content}</Typography>
      </Box>
    </WidgetWrapper>
  );
}

export default MainPost;
