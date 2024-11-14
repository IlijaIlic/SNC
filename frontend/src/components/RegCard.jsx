/* eslint-disable react/prop-types */
import React from 'react';
import { Link } from 'react-router-dom';

// engleski PREVEDENO
function RegCard({ naziv, linkTo }) {
  return (
    <Link to={linkTo} className="m-3 h-10 w-32 rounded-md bg-sncpink p-2 text-center text-white shadow-lg transition-colors duration-300 hover:animate-pop hover:bg-sncgradientpink">
      {naziv}
    </Link>
  );
}

export default RegCard;
