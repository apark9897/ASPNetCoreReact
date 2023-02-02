import {
  ChatBubbleOutlineOutlined,
  FavoriteBorderOutlined,
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

const PostWidget = ({
  postId,
  categoryId,
  categoryTitle,
  commentCount,
  createdDate,
  lastCommentDate,
  lastCommentUserId,
  lastCommentUsername,
  title,
  userId,
  username,
  views
}) => {
  const [isComments, setIsComments] = useState(false);
  const { palette } = useTheme();
  const main = palette.neutral.main;
  const light = palette.neutral.light;
  const primary = palette.primary.main;
  const isNonMobileScreens = useMediaQuery("(min-width:1000px)");

  return (
    <WidgetWrapper m="1rem 0" display="flex" >
      <Box m="0.5rem" display="flex" alignItems="center" >
        <UserImage size="35px" />
      </Box>
      <Box m="1rem" display="flex" flexDirection="column" alignItems="flex-start" width="70%">
        <Typography color={main} variant="h5" fontWeight="500">{title}</Typography>
        <Typography color={main} fontSize="14" fontWeight="300">{`${username}, ${dayjs(createdDate).fromNow()}, ${categoryTitle}`}</Typography>
      </Box>
      <Divider orientation="vertical" color={light} flexItem />
      <Box m="1rem" >
        <FlexBetween>
          <Typography color={main} fontSize="14" fontWeight="300">Comments: </Typography>
          <Typography color={main} fontSize="14" fontWeight="500">{commentCount}</Typography>
        </FlexBetween>
        <FlexBetween>
          <Typography color={main} fontSize="14" fontWeight="300">Views: </Typography>
          <Typography color={main} fontSize="14" fontWeight="500">{views}</Typography>
        </FlexBetween>
      </Box>
      <FlexBetween mt="0.25rem">
        <FlexBetween gap="1rem">
          <FlexBetween gap="0.3rem">
            <Typography>{commentCount}</Typography>
          </FlexBetween>
        </FlexBetween>

        <IconButton>
          <ShareOutlined />
        </IconButton>
      </FlexBetween>
    </WidgetWrapper>
  );
};

export default PostWidget;
