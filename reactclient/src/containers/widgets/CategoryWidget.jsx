import {
  ChatBubbleOutlineOutlined,
  VisibilityOutlined,
  FavoriteOutlined,
  ShareOutlined,
  ArticleOutlined
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
  postCount,
  createdDate,
  lastPostId,
  lastPostTitle,
  lastPostDate,
  lastPostUserId,
  lastPostUsername,
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
  const showLastPost = isNonMobile && lastPostId;

  return (
    <WidgetWrapper m="1rem 0" display="flex" >
      <Box m="0.5rem" display="flex" alignItems="center" >
        <UserImage size="35px" />
      </Box>
      <Box mx="1rem" my="0.5rem" display="flex" flexDirection="column" alignItems="flex-start" width={showLastPost ? "60%" : "100%"}>
        <Typography color={main} variant="h5" fontWeight="500">{title}</Typography>
        <Typography color={main} variant="body1" fontWeight="500">{description}</Typography>
        <FlexBetween gap="0.25rem">
          <ArticleOutlined fontSize="small" />
          <Typography color={main} variant="subtitle1">{postCount}</Typography>
        </FlexBetween>
      </Box>
      {showLastPost &&
      <>
        <Box width="40%" display="flex" alignItems="center" >
          <Divider orientation="vertical" color={light} flexItem />
          <Box m="1rem" display="flex" alignItems="center" >
            <UserImage size="35px" />
          </Box>
          <Box m="0.25rem" display="flex" flexDirection="column" alignItems="flex-start">
          <Typography color={main} fontSize="14" fontWeight="300">{lastPostTitle}</Typography>
            <Typography color={main} fontSize="12" fontWeight="300">{`${lastPostUsername}, ${dayjs(lastPostDate).fromNow()}`}</Typography>
          </Box>
        </Box>
      </>
      }
    </WidgetWrapper>
  );
};

export default CategoryWidget;
