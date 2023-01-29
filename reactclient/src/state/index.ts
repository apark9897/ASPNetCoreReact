import { PaletteMode } from "@mui/material";
import { createSlice } from "@reduxjs/toolkit";

export interface IndexState {
  mode: PaletteMode,
  user: any | null,
  token: string | null
}

const initialState: IndexState = {
  mode: "light" as PaletteMode,
  user: null,
  token: null
}

export const indexSlice = createSlice({
  name: "index",
  initialState,
  reducers: {
    setMode: (state) => {
      state.mode = state.mode === "light" as PaletteMode ? "dark" as PaletteMode : "light" as PaletteMode;
    },
    setLogin: (state, action) => {
      state.user = action.payload.user;
      state.token = action.payload.token;
    },
    setLogout: (state) => {
      state.user = null;
      state.token = null;
    }
  }
})

export const { setMode, setLogin, setLogout } = indexSlice.actions;
export default indexSlice.reducer;
