import React from 'react';
import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
// mt je bilo 0 na prvi div promenio sam ga na mt-2 da bi mi bolje radilo tebi nista nije sjebalo

// engleski PREVEDENO
function Footer() {
  const { t } = useTranslation();

  return (
    <div className=" mt-2 flex w-full flex-col flex-wrap items-center justify-center gap-3 bg-sncpink  p-6 text-center text-white sm:flex-row sm:justify-around">
      <Link to="/" className="flex w-1/3 flex-col hover:text-snclbrown">
        <p className="font-sncFont4 text-4xl ">Svadba Na Click</p>
        <p className="font-thin">{t('yourDreamWedding')}</p>
      </Link>
      <div>
        <Link to="/skod" className="font-thin hover:text-snclbrown">{t('safetyCode')}</Link>
      </div>
      <div className="flex w-1/3 flex-col gap-3">
        <Link to="/about" className="font-thin hover:text-snclbrown">{t('about')}</Link>
        <Link to="/contact" className="font-thin hover:text-snclbrown">{t('contact')}</Link>
      </div>
    </div>
  );
}

export default Footer;
// h-32 je bilo u prvi div hteo sam da vidim sta ce se desi ako nestaane jer tehnicki nije flex?!
