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
import MainPost from './MainPost';
import CommentCreator from 'containers/widgets/CommentCreator';
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

const PostPage: FC = (props) => {
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
    <Box
      display="flex"
      flexDirection="column"
      padding="2rem 4%"
    >
      <Box
        maxWidth="950px"
        width={isNonMobileScreens ? "80%" : "100%"}
        display="block"
        alignSelf={isNonMobileScreens ? "flex-start" : "center"}
      >
        <MainPost />
        <CommentCreator />
      </Box>
    </Box>
  );
}

export default PostPage;
