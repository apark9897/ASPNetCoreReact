import "@mui/material/styles/createTheme";
import "@mui/material/styles/createPalette";
declare module "@mui/material/styles/createTheme" {
  interface PaletteOptions {
    neutral: PaletteColorOptions;
  }
}

declare module "@mui/material/styles/createPalette" {
  interface TypeBackground {
    alt: string;
  }

  interface Palette {
    neutral: PaletteColor
  }
}
