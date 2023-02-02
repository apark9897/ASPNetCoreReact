import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { setPosts } from "state";
import PostWidget from "./PostWidget";
import {CircularProgress} from '@mui/material';
import axios from "axios";
import config from "config";
const ASPBACKEND = config.ASPBACKEND;

const PostsWidget = ({ userId = null, isProfile = false }) => {
  const token = useSelector((state) => state.token);
  const [posts, setPosts] = useState([]);
  const [isPostsLoading, setPostsLoading] = useState(true);

  const getPosts = async () => {
    const response = await axios(`${ASPBACKEND}posts`);
    setPosts(response.data?.$values);
    setPostsLoading(false);
  };

  const getUserPosts = async () => {
    const response = await axios(`${ASPBACKEND}posts/${userId}`);
    setPosts(response.data?.$values);
    setPostsLoading(false);
  };

  useEffect(() => {
    if (isProfile) {
      getUserPosts();
    } else {
      getPosts();
    }
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  return (
    <>
      {isPostsLoading ? <CircularProgress /> : posts.map(
        ({
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
        }) => (
          <PostWidget
            key={postId}
            postId={postId}
            postUserId={userId}
            username={username}
            title={title}
            views={views}
            commentCount={commentCount}
            categoryTitle={categoryTitle}
            categoryId={categoryId}
            createdDate={createdDate}
            lastCommentDate={lastCommentDate}
            lastCommentUserId={lastCommentUserId}
            lastCommentUsername={lastCommentUsername}
          />
        )
      )}
    </>
  );
};

export default PostsWidget;
