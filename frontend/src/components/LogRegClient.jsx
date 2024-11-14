/* eslint-disable react/prop-types */
import React from 'react';
import { useTranslation } from 'react-i18next';
import { Link } from 'react-router-dom';

// engleski PREVEDENO
function LogRegClient({ naslov, tekst, linkTo }) {
  const { t } = useTranslation();
  return (
    <div className="z-10 mb-10 flex w-full flex-row justify-between bg-gradient-to-tr from-snclpink to-sncpink p-4 py-14 shadow-lg">
      <div className=" flex flex-col justify-between">
        <p className=" text-3xl font-bold text-white">
          {naslov}
        </p>
        <p className=" text-xl font-light text-white">
          {tekst}
        </p>
        <Link className="w-fit rounded-md bg-sncpink p-2 text-3xl font-bold text-white hover:animate-pop" to={linkTo}>
          {t('register')}
        </Link>
      </div>
      <img src="../../assets/sncWHITE.svg" alt="SNC" className="float-right w-40 fill-white" />
    </div>
  );
}

export default LogRegClient;
