import {
  ChatBubbleOutlineOutlined,
  VisibilityOutlined,
  FavoriteOutlined,
  ShareOutlined,
} from "@mui/icons-material";
import { Box, Divider, IconButton, Typography, useTheme, useMediaQuery } from "@mui/material";
import FlexBetween from "components/FlexBetween";
import WidgetWrapper from "components/WidgetWrapper";
import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import dayjs from "dayjs";
import relativeTime from 'dayjs/plugin/relativeTime';
import UserImage from "components/UserImage";
import config from "config";

dayjs.extend(relativeTime);
const ASPBACKEND = config.ASPBACKEND;

const CategoryWidget = ({
  categoryId,
  categoryTitle,
  commentCount,
  createdDate,
  lastCommentDate,
  lastCommentUserId,
  lastCommentUsername,
  title,
  description,
  views
}) => {
  const [isComments, setIsComments] = useState(false);
  const { palette } = useTheme();
  const main = palette.neutral.main;
  const light = palette.neutral.light;
  const primary = palette.primary.main;
  const isNonMobile = useMediaQuery("(min-width:600px)");

  return (
    <WidgetWrapper m="1rem 0" display="flex" >
      <Box m="0.5rem" display="flex" alignItems="center" >
        <UserImage size="35px" />
      </Box>
      <Box mx="1rem" my="0.5rem" display="flex" flexDirection="column" alignItems="flex-start">
        <Typography color={main} variant="h5" fontWeight="500">{title}</Typography>
        <Typography color={main} variant="h6" fontWeight="500">{description}</Typography>
      </Box>
    </WidgetWrapper>
  );
};

export default CategoryWidget;
