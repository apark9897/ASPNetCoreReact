import { useState, FC, useEffect, useMemo } from 'react';
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
import RCE from 'components/RCE';
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

const CommentCreator: FC = (props) => {
  const postComment = (html: any) => {
    console.log(html);
  }

  useEffect(() => {
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  return (
    <RCE handleSubmit={postComment} />
  );
}

export default CommentCreator;
