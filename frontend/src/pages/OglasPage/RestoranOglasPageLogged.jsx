/* eslint-disable no-restricted-syntax */
/* eslint-disable no-console */
/* eslint-disable no-await-in-loop */
/* eslint-disable max-len */
/* eslint-disable jsx-a11y/img-redundant-alt */
import React, { useEffect, useState } from 'react';
import { Carousel } from '@material-tailwind/react';
import Rating from '@mui/material/Rating';
import { Button } from '@mui/base';
import FavoriteIcon from '@mui/icons-material/Favorite';
import Tooltip from '@mui/material/Tooltip';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import { useNavigate, useParams } from 'react-router-dom';
import HeartBrokenIcon from '@mui/icons-material/HeartBroken';
import axios from 'axios';
import { useTranslation } from 'react-i18next';
// eslint-disable-next-line import/no-named-as-default
import auth from '../../firebase';

// engleski PREVEDENO
function ResotranOglasPageLogged() {
  const { t } = useTranslation();
  const [selectedDate, setSelectedDate] = useState(null);
  const [images, setImages] = useState([]);
  const [lajkovano, setLajkovano] = useState(false);
  const navigate = useNavigate();
  const [jela, setJela] = useState([]);
  const [idMl, setIdMl] = useState(0);
  const [izabranaJela, setIzabranaJela] = useState([]);
  const [izabranaCena, setIzabranaCena] = useState(0);
  const [slobodniTermini, setSlobodniTermini] = useState([]);
  const [disabledButtons, setDisabledButtons] = useState([]);
  const [naziv, setNaziv] = useState('');
  const [osnovniPodaci, setOsnovniPodaci] = useState('');
  const [brTelefona, setBrTelefona] = useState('');
  const [email, setEmail] = useState('');
  const [neMoze, setNeMoze] = useState(false);
  const [ocena, setOcena] = useState('');
  const [minCena, setMinCena] = useState(0);
  const { id } = useParams();

  const isDateReserved = (date) => !slobodniTermini.some((item) => {
    const dbDate = new Date(item.termin); // Convert database string to Date object

    return dbDate.toISOString().slice(0, 10) === date.toISOString().slice(0, 10);
  });

  function handleOdaberi(jelo) {
    setIzabranaJela([...izabranaJela, jelo]);
    setIzabranaCena(izabranaCena + jelo.cena);
    setDisabledButtons([...disabledButtons, jelo.id]);
    console.log(jelo);
  }

  useEffect(() => {
    // Function to fetch profile data
    async function fetchProfileData() {
      try {
        const response = await axios.get(`http://localhost:5555/restorani/prekoid/${id}`);
        const fetchedData = response.data;
        setNaziv(fetchedData.restoran.naziv);
        setOsnovniPodaci(fetchedData.restoran.opis);
        setEmail(fetchedData.restoran.email);
        setBrTelefona(fetchedData.restoran.brojTelefona);
        setOcena(fetchedData.restoran.ocena);
        setMinCena(fetchedData.restoran.cena);

        setJela(fetchedData.jelovnik.sort((a, b) => a.TIP - b.TIP));
        console.log(jela);
        setSlobodniTermini(fetchedData.slobodniTermini);

        console.log('OKVIR');
        console.log(fetchedData.slobodniTermini);
        console.log(slobodniTermini);
        console.log('OKVIR');

        // console.log(slobodniTermini);

        // const responseZakazano = await axios.get(`http://localhost:8080/zakazanomladencima/prekouid/${auth.currentUser.uid}`);
        // const fetchedResponseZakazano = responseZakazano.data;
        // if (fetchedResponseZakazano[0].Restoran_Termin !== null) {
        // setNeMoze(true);
        // }

        const responseZaID = await axios.get(`http://localhost:5555/mladenci/${auth.currentUser.uid}`);
        const fetchedDataZaID = responseZaID.data;
        console.log(fetchedData.id);
        setIdMl(fetchedDataZaID.id);
      } catch (error) {
        console.error('Failed to fetch profile data:', error);
        navigate('/badRequest');
      }
    }

    fetchProfileData();
  }, []); // Empty dependency array ensures this runs only once

  useEffect(() => {
    const fetchData = async () => {
      try {
        const responseLiked = await axios.get('http://localhost:5555/restorani/liked/', {
          params: {
            UID: auth.currentUser.uid,
            RestoranID: id,
          },
        });

        const isLiked = responseLiked.data;

        if (isLiked) {
          setLajkovano(true);
        }
      } catch (error) {
        console.error('Error fetching liked status:', error);
      }
    };

    fetchData();
  }, [id]);

  // useEffect(() => {
  //   async function fetchJela() {
  //     try {
  //       if (id !== 0) {
  //         const responseJela = await axios.get(`http://localhost:8080/jelovnik/${id}`);
  //         const fetchedDataJela = responseJela.data;
  //         fetchedDataJela.sort((a, b) => a.TIP - b.TIP);
  //         setJela(fetchedDataJela);
  //         console.log(jela);
  //       }
  //     } catch (error) {
  //       console.error('Failed to fetch guests data:', error);
  //     }
  //   }
  //   fetchJela();
  // }, [id]);

  useEffect(() => {
    async function fetchImages() {
      const responeSlike = await axios.get(`http://localhost:8080/slikeRestoran/url/${id}`);
      const dataSlike = responeSlike.data;
      setImages(dataSlike.images);

      console.log(dataSlike);
    }
    fetchImages();
  }, []);

  const handleSacuvaj = async () => {
    try {
      await fetch('http://localhost:5555/like/Like/addLikedEntity', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          UID: auth.currentUser.uid,
          Type: 'Restoran',
          EntityID: id,
        }),
      });
      setLajkovano(true);
    } catch (err) {
      console.log(err);
    }
  };

  const handleIzbaci = async () => {
    try {
      await fetch('http://localhost:5555/like/Like/deleteLikedEntity', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          UID: auth.currentUser.uid,
          Type: 'Restoran',
          EntityID: id,
        }),
      });
      setLajkovano(false);
    } catch (err) {
      console.log(err);
    }
  };

  const handleRezervisi = async () => {
    if (selectedDate == null) {
      alert('Morate izabrati datum');
      return;
    }
    if (izabranaCena > minCena) {
      const formattedDate = selectedDate.toISOString().slice(0, 19).replace('T', ' ');
      console.log(izabranaJela);
      try {
        for (const ijelo of izabranaJela) {
          console.log(ijelo);
          await fetch(`http://localhost:5555/jelovnikzakazano/${idMl}`, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
              ImeJela: ijelo.ImeJela,
              TipJela: ijelo.TIP,
              Cena: ijelo.Cena,
              Gramaza: ijelo.Kolicina,
            }),
          });
        }

        console.log('ASDF');
        console.log(idMl);
        console.log('ASDF');

        await fetch('http://localhost:5555/zakazano/restoran', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            mladenciID: idMl,
            RestoranTermin: formattedDate,
            CenaRestorana: izabranaCena,
            RestoranID: id,
          }),
        });
        // window.location.reload();
        // pozovi put za rezervaciju
      } catch (err) {
        // asdf
      }
    } else {
      // ne moze
    }
  };
  const handleReset = () => {
    setIzabranaJela([]);
    setIzabranaCena(0);
    setDisabledButtons([]);
    console.log(slobodniTermini);
  };

  return (
    <div className=" relative h-full w-full">
      <img
        src="../../assets/pexels-pixabay-260922.jpg"
        alt="image 1"
        className="h-96 w-full object-cover shadow-lg "
      />
      <div className="pointer-events-none absolute inset-0 mt-32 flex flex-col items-center justify-items-start text-center">
        <h1 className=" mb-3 text-7xl font-bold text-white drop-shadow-lg">{naziv}</h1>
        <h1 className="text-xl text-white drop-shadow-lg">{t('RESTORAN')}</h1>
      </div>
      <div className="flex h-full flex-col items-center">
        <div className="mt-5 flex w-full flex-row flex-wrap justify-around p-2 px-5">

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
              {' '}
              {brTelefona}
            </p>
            <p>
              Email:
              {email}
            </p>

          </div>
        </div>
        <div className="flex flex-row">
          <p className="mx-2">
            {t('ocena')}
            :
            {' '}
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
          <Tooltip title={lajkovano ? 'Izbaci' : 'Sacuvaj'} placement="top" arrow>
            <Button className="text-sncpink hover:text-snclpink " onClick={lajkovano ? handleIzbaci : handleSacuvaj}>
              {lajkovano ? <HeartBrokenIcon /> : <FavoriteIcon />}
            </Button>
          </Tooltip>
        </div>
      </div>
      {neMoze ? null : (
        <div className="my-3 flex w-full flex-col items-center">
          <hr className="my-3 h-1 w-11/12 border-0 bg-sncpink" />
          <p className="mb-3 text-xl font-bold">
            {t('minimumcenaMenijaPoOsobi')}
            <span className="text-xl font-normal">
              {' '}
              {minCena}
              {' '}
              din
            </span>
          </p>
          <div className="mb-3 flex flex-col gap-3">
            {jela.map((jelo) => (
              <div className="flex flex-row items-center justify-center gap-3" key={jelo.id}>
                <p><span className="font-bold">{jelo.tipJela}</span></p>
                <p>{jelo.imeJela}</p>
                <p>
                  {jelo.cena}
                  {' '}
                  <span className="font-bold">din</span>
                </p>
                <p>
                  {jelo.kolicina}
                  {' '}
                  <span className="font-bold">g</span>
                </p>
                <button disabled={disabledButtons.includes(jelo.id)} type="button" className={disabledButtons.includes(jelo.id) ? 'h-6 w-6 rounded-md bg-sncdbrown text-white ' : 'h-6 w-6 rounded-md bg-snclbrown text-white hover:bg-sncdbrown'} onClick={() => handleOdaberi(jelo)}>{disabledButtons.includes(jelo.id) ? ' ' : '+'}</button>
              </div>
            ))}
            <p className=" text-xl font-bold">
              {t('UkupnaCenaMenijaPoOsobi')}
              <span className="text-xl font-normal">
                {' '}
                {izabranaCena}
                {' '}
                din
              </span>
              <button type="button" className="mx-2 h-fit w-fit rounded-md bg-snclbrown p-1 text-center text-white hover:bg-sncdbrown" onClick={handleReset}>RESET</button>

            </p>
          </div>
          <div>
            <h1>{t('kalendarZaRezervisanje')}</h1>
            <DatePicker
              isClearable
              selected={selectedDate}
              onChange={(date) => setSelectedDate(date)}
              minDate={new Date()}
              filterDate={(date) => !isDateReserved(date)}
              className="border-2"
              popperPlacement="bottom"
            />
          </div>
          <Button onClick={handleRezervisi} disabled={izabranaCena < minCena} className={izabranaCena < minCena ? 'mt-5 rounded-md bg-sncdbrown p-2 shadow-lg' : 'mt-5 rounded-md bg-snclbrown p-2 shadow-lg hover:bg-sncdblue hover:text-white '} icon={<FavoriteIcon />}>Zakazi</Button>

        </div>
      )}
    </div>
  );
}

export default ResotranOglasPageLogged;
