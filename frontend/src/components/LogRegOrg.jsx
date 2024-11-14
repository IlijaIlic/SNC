/* eslint-disable react/prop-types */
import React from 'react';
import { useTranslation } from 'react-i18next';
import { Link } from 'react-router-dom';

// engleski PREVEDENO
function LogRegOrg({ naslov, tekst, linkTo }) {
  const { t } = useTranslation();
  return (
    <div className="flex w-full flex-row-reverse justify-between bg-white p-4">
      <div className="flex flex-col justify-between text-right">
        <p className="text-3xl font-bold text-sncpink">
          {naslov}
        </p>
        <p className="text-xl font-light text-sncpink">
          {tekst}
        </p>
        <div className="flex w-full flex-row justify-end">
          <Link className=" w-fit  rounded-md bg-sncpink p-2 text-3xl font-bold text-white hover:animate-pop hover:bg-snclpink" to={linkTo}>
            {t('register')}
          </Link>
        </div>
      </div>
      <img src="../../assets/cakePINK-cropped.svg" alt="SNC" className="float-right h-80" />

    </div>
  );
}

export default LogRegOrg;
