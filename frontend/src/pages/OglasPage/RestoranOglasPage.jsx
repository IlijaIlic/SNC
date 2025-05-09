/* eslint-disable max-len */
/* eslint-disable jsx-a11y/img-redundant-alt */
import React, { useEffect, useState } from 'react';
import { Carousel } from '@material-tailwind/react';
import Rating from '@mui/material/Rating';
import { useNavigate, useParams } from 'react-router-dom';
import axios from 'axios';
import { useTranslation } from 'react-i18next';

// engleski PREVEDENO
function ResotranOglasPage() {
  const { t } = useTranslation();
  const [naziv, setNaziv] = useState('');
  const [osnovniPodaci, setOsnovniPodaci] = useState('');
  const [brTelefona, setBrTelefona] = useState('');
  const [images, setImages] = useState([]);
  const [email, setEmail] = useState('');
  const [ocena, setOcena] = useState('');
  const navigate = useNavigate();

  const { id } = useParams();

  useEffect(() => {
    // Function to fetch profile data
    async function fetchProfileData() {
      try {
        const response = await axios.get(`http://localhost:5555/restorani/prekoid/${id}`);
        const fetchedData = response.data;
        console.log(fetchedData);
        setNaziv(fetchedData.naziv);
        setOsnovniPodaci(fetchedData.opis);
        setEmail(fetchedData.email);
        setBrTelefona(fetchedData.brojTelefona);
        setOcena(fetchedData.ocena);
      } catch (error) {
        console.error('Failed to fetch profile data:', error);
        navigate('/badRequest');
      }
    }

    fetchProfileData();
  }, []); // Empty dependency array ensures this runs only once

  // useEffect(() => {
  //   async function fetchImages() {
  //     const responeSlike = await axios.get(`http://localhost:8080/slikeRestoran/url/${id}`);
  //     const dataSlike = responeSlike.data;
  //     setImages(dataSlike.images);

  //     console.log(dataSlike);
  //   }
  //   fetchImages();
  // }, []);

  return (
    <div className=" relative h-full w-full">
      <img
        src="../../assets/pexels-pixabay-260922.jpg"
        alt="image 1"
        className="h-96 w-full object-cover shadow-lg"
      />
      <div className="pointer-events-none absolute inset-0 mt-32 flex flex-col items-center justify-items-start text-center">
        <h1 className=" mb-3 text-7xl font-bold text-white drop-shadow-lg">{naziv}</h1>
        <h1 className="text-xl text-white drop-shadow-lg">{t('RESTORAN')}</h1>
      </div>
      <div className="flex h-full flex-col items-center">
        <div className="mt-5 flex w-full flex-row flex-wrap justify-around p-2 px-5">
          <div className="mx-2 my-3 w-96">
            <div className="text-center font-bold">{t('OsnovniPodaci')}</div>
            <hr className="my-3 h-1 border-0 bg-sncpink" />
            <p className="text-justify">
              {osnovniPodaci}
            </p>
          </div>
          <div className="mx-2 my-3 w-96">
            <div className="text-center font-bold">{t('Contact')}</div>
            <hr className="my-3 h-1 border-0 bg-sncpink" />
            <p>
              {t('phoneNumber')}
              :
              {brTelefona}
            </p>
            <p>
              Email:
              {email}
            </p>
          </div>
          <div className="mx-2 my-3 w-96">
            <div className="text-center font-bold">{t('Fotografije')}</div>
            <hr className="my-3 h-1 border-0 bg-sncpink" />
            <div className="flex w-full justify-center">
              <div className="w-full text-center">
                <Carousel className="h-full w-full ">
                  {images.map((image) => (
                    <img
                      src={image}
                      alt="image 1"
                      className="h-auto max-w-full  shadow-lg"
                    />
                  ))}
                </Carousel>
              </div>
            </div>
          </div>
        </div>
        <div className="flex flex-row">
          <p className="mx-2">
            {' '}
            {t('ocena')}
            :
          </p>
          <Rating
            name="readOnly"
            value={ocena}
            readOnly
            precision={0.1}
          />
          <p className="mx-2">
            {ocena}
          </p>
        </div>
      </div>
    </div>
  );
}

export default ResotranOglasPage;
