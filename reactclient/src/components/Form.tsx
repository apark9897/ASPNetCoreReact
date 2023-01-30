import { useState } from "react";
import {
  Box,
  Button,
  TextField,
  useMediaQuery,
  Typography,
  useTheme,
} from "@mui/material";
import EditOutlinedIcon from "@mui/icons-material/EditOutlined";
import { FormikHelpers, useFormik } from "formik";
import * as yup from "yup";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import { setLogin } from "state";
import Dropzone from "react-dropzone";
import FlexBetween from "components/FlexBetween";
import config from "../config"
import axios from "axios";

const BASEURL = config.ASPBACKEND;

const registerSchema = yup.object().shape({
  username: yup.string().required("required"),
  email: yup.string().email("invalid email").required("required"),
  password: yup.string().required("required"),
});

const loginSchema = yup.object().shape({
  username: yup.string().required("required"),
  password: yup.string().required("required"),
});

const initialValuesRegister = {
  username: "",
  email: "",
  password: "",
  avatar: null,
};

const initialValuesLogin = {
  username: "",
  password: "",
};

type IInitValues = {
  username: string,
  email?: string,
  password: string,
  avatar?: File | null
}

interface FormProps {
  closeModal: () => void
}

const Form: React.FC<FormProps> = ({ closeModal }) => {
  const [pageType, setPageType] = useState("login");
  const { palette } = useTheme();
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const isNonMobile = useMediaQuery("(min-width:600px)");
  const isLogin = pageType === "login";
  const isRegister = pageType === "register";
  const validationSchema = isLogin ? loginSchema : registerSchema;

  const register = async (values: IInitValues, onSubmitProps: FormikHelpers<IInitValues>) => {
    axios.post(
      `${BASEURL}auth/register`,
      values
    )
      .then(() => {
        onSubmitProps.resetForm();
        setPageType("login");
      })
      .catch((err) => {
        alert("User creation failed, " + err);
      })
  };

  const login = async (values: IInitValues, onSubmitProps: FormikHelpers<IInitValues>) => {
    axios.post(
      `${BASEURL}auth/login`,
      values
    )
      .then((response: any) => {
        onSubmitProps.resetForm();
        dispatch(
          setLogin({
            user: values.username,
            token: response?.token,
          })
        );
        closeModal();
      })
      .catch((err) => {
        alert("User login failed, " + err);
      })
  };

  const handleFormSubmit = async (values: IInitValues, onSubmitProps: FormikHelpers<IInitValues>) => {
    console.log('submitting')
    if (isLogin) await login(values, onSubmitProps);
    if (isRegister) await register(values, onSubmitProps);
  };

  const initialValues: IInitValues = isLogin ? initialValuesLogin : initialValuesRegister;

  const { values, errors, handleBlur, handleChange, handleSubmit, touched, setFieldValue, resetForm } = useFormik({
    initialValues: initialValues,
    validationSchema: validationSchema,
    onSubmit: handleFormSubmit
  })

  return (
    <form onSubmit={handleSubmit}>
      {isRegister && (
        <>
          <TextField
            label="Email"
            onBlur={handleBlur}
            onChange={handleChange}
            value={values.email}
            name="email"
            margin="dense"
            fullWidth
            error={Boolean(touched.email) && Boolean(errors.email)}
            helperText={touched.email && errors.email}
          />
          <Box
            gridColumn="span 4"
            border={`1px solid ${palette.neutral.medium}`}
            borderRadius="5px"
            p="1rem"
            m="0.5rem 0"
          >
            <Dropzone
              accept={{ 'image/jpeg': [], 'image/png': [] }}
              multiple={false}
              onDrop={(acceptedFiles) => {
                setFieldValue("avatar", acceptedFiles[0]);
                console.log(acceptedFiles[0]);
              }}
            >
              {({ getRootProps, getInputProps }) => (
                <Box
                  {...getRootProps()}
                  border={`2px dashed ${palette.primary.main}`}
                  p="1rem"
                  sx={{ "&:hover": { cursor: "pointer" } }}
                >
                  <input {...getInputProps()} />
                  {!values.avatar ? (
                    <p>Add Avatar Here</p>
                  ) : (
                    <FlexBetween>
                      <Typography>{values.avatar.name}</Typography>
                      <EditOutlinedIcon />
                    </FlexBetween>
                  )}
                </Box>
              )}
            </Dropzone>
          </Box>
        </>
      )}

      <TextField
        label="Username"
        onBlur={handleBlur}
        onChange={handleChange}
        value={values.username}
        name="username"
        margin="dense"
        fullWidth
        error={
          Boolean(touched.username) && Boolean(errors.username)
        }
        helperText={touched.username && errors.username}
      />
      <TextField
        label="Password"
        type="password"
        onBlur={handleBlur}
        onChange={handleChange}
        value={values.password}
        name="password"
        margin="dense"
        fullWidth
        error={Boolean(touched.password) && Boolean(errors.password)}
        helperText={touched.password && errors.password}
      />

      {/* BUTTONS */}
      <Box>
        <Button
          fullWidth
          type="submit"
          sx={{
            m: "2rem 0 1rem 0",
            p: "1rem",
            backgroundColor: palette.primary.main,
            color: palette.background.alt,
            "&:hover": { color: palette.primary.main },
          }}
        >
          {isLogin ? "LOGIN" : "REGISTER"}
        </Button>
        <Typography
          onClick={() => {
            setPageType(isLogin ? "register" : "login");
            resetForm();
          }}
          textAlign="center"
          p="0.5rem 0"
          sx={{
            textDecoration: "underline",
            color: palette.primary.main,
            "&:hover": {
              cursor: "pointer",
              color: palette.primary.light,
            },
          }}
        >
          {isLogin
            ? "Don't have an account? Sign Up here."
            : "Already have an account? Login here."}
        </Typography>
      </Box>
    </form >
  );
};

export default Form;
