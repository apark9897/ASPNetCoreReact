import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import CategoryWidget from "./CategoryWidget";
import {CircularProgress, Typography} from '@mui/material';
import axios from "axios";
import config from "config";
const ASPBACKEND = config.ASPBACKEND;

const CategoriesWidget = () => {
  const token = useSelector((state) => state.token);
  const [categories, setCategories] = useState([]);
  const [isCategoriesLoading, setCategoriesLoading] = useState(true);

  const getCategories = async () => {
    setCategories([1, 2, 3, 4, 5, 6]);
    return setCategoriesLoading(false);
    const response = await axios(`${ASPBACKEND}categories`);
    setCategories(response.data?.$values);
    setCategoriesLoading(false);
  };

  useEffect(() => {
    getCategories();
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  return (
    <>
      <Typography variant="h3" fontWeight="600">Popular Categories</Typography>
      {isCategoriesLoading ? <CircularProgress /> : categories.map(
        () => (
          <CategoryWidget
            title="Category test"
            description="Test description, lorem ipsum piggy poodle"
          />
        )
      )}
    </>
  );
};

export default CategoriesWidget;
