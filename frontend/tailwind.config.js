/* eslint-disable quote-props */
/** @type {import('tailwindcss').Config} */
const withMT = require('@material-tailwind/react/utils/withMT');

module.exports = withMT({
  content: [
    './index.html',
    './src/**/*.{js,ts,jsx,tsx}',
  ],
  theme: {
    fontFamily: {
      sncFont1: ['Lato'],
      sncFont2: ['Barlow'],
      sncFont3: ['Lobster'],
      sncFont4: ['Modak'],
      sncFont5: ['Hubot Sans'],
    },
    colors: {
      transparent: 'transparent',
      current: 'currentColor',
      'white': '#ffffff',
      'black': '#000000',
      'purple': '#3f3cbb',
      'red': '#8B0000',
      'midnight': '#121063',
      'metal': '#565584',
      'tahiti': '#3ab7bf',
      'silver': '#ecebff',
      'bubble-gum': '#ff77e9',
      'bermuda': '#78dcca',
      'snclpink': '#F1B4BB',
      'sncdblue': '#132043',
      'sncpink': '#B4436C',
      'snclbrown': '#EDCBB1',
      'snclblue': '#1F4172',
      'snclgray': '#35393C',
      'sncdbrown': '#B39986',
      'sncgradientpink': '#F5A0A9',
      'sncnewbrown': '#443737',
      'sncnewpurple': '#987284',
      'sncnewcol1': '#D5AA9F',
      'sncnewcol2': '#E8D5B7',
      'sncnewcol3': '#F4E1D2',
    },
    extend: {
      animation: {
        pop: 'pop 0.3s ease-in-out forwards',
      },
      keyframes: {
        pop: {
          '100%': { transform: 'scale(1.05)' },
        },
      },
    },
  },
  plugins: [],
});
