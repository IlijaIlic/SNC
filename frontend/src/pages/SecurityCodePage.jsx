import { useFormik } from 'formik';
import React from 'react';
import { useTranslation } from 'react-i18next';
import { useNavigate } from 'react-router-dom';
import { Button } from '@mui/base';
import { skodSchema } from '../schemas/schema';

// engleski PREVEDENO
function SecurityCodePage() {
  const { t } = useTranslation();
  const inputDugmeKlasa = 'h-7 w-64 rounded-md px-2 shadow-md ring-snc-dblue ring-1 outline-none';
  const inputDugmeKlasaLosa = ' ring-red ring-1 outline-none h-7 w-64 rounded-md px-2 shadow-md';
  const navigate = useNavigate();

  const handleSubmit = async (values) => {
    try {
      await fetch('http://localhost:8080/email', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          Email: values.email,
        }),
      });
      navigate('/');
      window.location.reload();
    } catch (err) {
      console.error('Error posting data:', err);
      console.log('Greska u registrovanju');
    }
  };

  const {
    values, handleBlur, handleChange, errors, touched, dirty, isValid,
  } = useFormik({
    initialValues: {
      email: '',
    },
    validationSchema: skodSchema,
    onSubmit: () => {
      handleSubmit(values);
    },
  });

  const formSubmitHandler = (e) => {
    e.preventDefault();
    handleSubmit(values);
  };

  return (
    <div className="flex h-full w-full flex-col items-center justify-around p-2 pt-20">
      <div>
        <div className=" flex  w-full  flex-row flex-wrap">
          <div className="m-2 flex h-60 w-1/2 flex-grow flex-col  justify-evenly rounded-lg bg-snclpink p-3  text-white shadow-lg md:w-1/3">
            <p className="text-2xl font-semibold">
              {t('whatIsCode')}
            </p>
            <div className="text-left ">
              <p>
                {t('security1')}
                <span className="font-extrabold">{t('security2')}</span>
                {t('security3')}
                <span className="font-extrabold">
                  {t('security4')}
                </span>
                {t('security5')}
              </p>
            </div>
          </div>
          <div className="m-2 flex h-60 w-1/2 flex-grow flex-col justify-evenly rounded-lg bg-snclpink p-3 text-white shadow-lg md:w-1/3">
            <p className="my-2 text-2xl font-semibold">
              {t('howToGetCodeQ')}
            </p>
            <div className="text-left ">
              <p>
                {t('howToGetCodeA')}
              </p>
            </div>
          </div>
        </div>
      </div>
      <form onSubmit={formSubmitHandler} className="  flex  items-center  p-3">
        <input
          className={errors.email && touched.email ? inputDugmeKlasaLosa : inputDugmeKlasa}
          onChange={handleChange}
          value={values.email}
          onBlur={handleBlur}
          placeholder={t('emailExample')}
          name="email"
        />
        <Button disabled={!(dirty && isValid)} type="submit" value="Posalji" className={!(dirty && isValid) ? 'mx-3 my-20 h-10 w-1/3 rounded-lg  bg-snclgray text-white shadow-lg' : 'mx-3 my-20 h-10 w-1/3 rounded-lg  bg-sncpink text-white shadow-lg hover:bg-snclpink'}>
          {' '}
          {t('send')}
        </Button>
      </form>
    </div>
  );
  //   return (
  //     <div className="flex w-full flex-col flex-wrap items-center">
  //       <div className="mt-3 text-center text-4xl font-bold">
  //         SIGURNOSNI KOD
  //       </div>
  //       <div className="my-7 flex w-full flex-row items-center justify-center ">

//         <div className="flex w-full flex-col items-center">
//           <p className="my-2 text-left  text-2xl font-semibold">
//             Šta je sigurnosni kod?
//           </p>
//           <div className="w-2/3  p-3  text-left ">
//             <p>
//               Sigurnosni kodovi nam pomažu da sačuvamo
//               {' '}
//               <span className="font-extrabold">integritet</span>
//               {' '}
//               naše platforme.
//               Oni osiguravaju
//               {' '}
//               <span className="font-extrabold">legitimitet </span>
//               {' '}
//               vaše firme, i neophodne su za poslovenje
//               preko naše aplikacije.
//             </p>
//           </div>
//           <div className="flex w-full flex-col items-center">
//             <p className="my-2  text-left text-2xl font-semibold">
//               Kako da dobijem sigurnosni kod?
//             </p>
//             <div className="w-2/3   p-3  text-left ">
//               <p>
//                 Sigurnosni kod možete dobiti dostavljanjem vaše poslovne email
//                 adrese u input polju. Naši administratori će vas kontaktirati
//                 u što moguće kraćem roku i nakon par pitanja poslati vaš kod.
//               </p>
//             </div>
//           </div>
//         </div>
//         <div className="mx-10 flex flex-row items-center">
//           <input className="mx-2 w-full rounded-lg  border-2 border-l-sncdblue
//  bg-white p-1 text-sncdblue shadow-lg outline-none hover:ring-1 hover:ring-snclblue focus:ring-2
// focus:ring-snclblue" onChange={(e) => setemail(e.target.value)} value={email}
// placeholder="Vaša email adresa" />
//  <Button value="Posalji" type="button" className="rounded-md bg-snclbrown p-2 hover:bg-snclgray
//  hover:text-white"> Pošalji</Button>
//         </div>
//       </div>
//     </div>
//   );
}

export default SecurityCodePage;
