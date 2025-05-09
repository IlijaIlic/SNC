/* eslint-disable no-plusplus */
/* eslint-disable import/no-named-as-default */
/* eslint-disable max-len */
/* eslint-disable no-unused-vars */
/* eslint-disable eqeqeq */
import React, { useState } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import LooksOneRoundedIcon from "@mui/icons-material/LooksOneRounded";
import LooksTwoRoundedIcon from "@mui/icons-material/LooksTwoRounded";
import Looks3RoundedIcon from "@mui/icons-material/Looks3Rounded";
import { useTranslation } from "react-i18next";
import { Link, useNavigate } from "react-router-dom";
import { useFormik } from "formik";
import { createUserWithEmailAndPassword } from "firebase/auth";
import axios from "axios";
import { loginSchema } from "../schemas/schema";
import auth from "../firebase";
// PREVEDENO NA ENGLISH
function RegisterDekoraterPage() {
  const [selectedDate, setSelectedDate] = useState(null);
  const { t } = useTranslation();
  const navigate = useNavigate();
  const [selectedFiles, setSelectedFiles] = useState(null);

  const inputDugmeKlasa = "h-7 w-64 rounded-md px-2 shadow-md";
  const inputDugmeKlasaLosa =
    " ring-red ring-1 outline-none h-7 w-64 rounded-md px-2 shadow-md";

  const handleSubmit = async (values) => {
    try {
      const sigCode = await axios.get(
        `http://localhost:5555/api/SigurnosniKod/${values.skod}`
      );
      const fetchedSigCode = sigCode.data;
      console.log(fetchedSigCode);

      if (fetchedSigCode.sigKod == values.skod) {
        await createUserWithEmailAndPassword(
          auth,
          values.email,
          values.password
        );

        await fetch("http://localhost:5555/dekorateri", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            UID: auth.currentUser.uid,
            SigurnosniKod: values.skod,
            Naziv: values.naziv,
            Opis: values.opis,
            Email: values.email,
            Sifra: values.password,
            Lokacija: values.lokacija,
            Cena: values.cenaUsluge,
            DatumOsnivanja: values.datum,
            BrojTelefona: values.brojTelefona,
          }),
        });

        navigate("/");
        window.location.reload();
      }
    } catch (err) {
      console.error("Error posting data:", err);
      console.log("Greska u registrovanju");
      console.error(err);
    }
  };

  // const { uid } = auth.currentUser.uid;

  // const [image, setImage] = useState();

  // const submitImage = async (e) => {
  //   e.preventDefault();

  //   const formData1 = new FormData();
  //   formData1.append('image', image);

  //   const result = await axios
  //     .post(`http://localhost:8080/slikeDekorater/${auth.currentUser.uid}`, formData1, {
  //       headers: {
  //         'Content-Type': 'multipart/form-data',
  //       },
  //     });
  //   console.log(result);
  // };

  // const onInputChange = (e) => {
  //   console.log(e.target.files[0]);
  //   setImage(e.target.files[0]);
  // };

  // const handleFileChange = (event) => {
  //   setSelectedFiles(event.target.files);
  // };

  const { values, handleBlur, handleChange, errors, touched, dirty, isValid } =
    useFormik({
      initialValues: {
        naziv: "",
        datum: "",
        cenaUsluge: "",
        email: "",
        skod: "",
        password: "",
        confirmPassword: "",
        opis: "",
        lokacija: "",
        prethodniRadovi: "",
        brojTelefona: "",
      },
      validationSchema: loginSchema,
      onSubmit: () => {
        handleSubmit(values);
      },
    });

  const formSubmitHandler = (e) => {
    e.preventDefault();
    handleSubmit(values);
  };

  return (
    <div className="flex size-full flex-row flex-wrap-reverse items-center justify-around p-3">
      <div className="m-6 mx-10 items-center self-center text-center">
        <Link to="/" className="hover:text-snclbrown">
          <p className="font-sncFont4 text-6xl">Svadba Na Click</p>
          <p className="my-3 text-center font-thin">{t("organizeWedding")}</p>
        </Link>
      </div>
      <form
        onSubmit={formSubmitHandler}
        className=" flex w-2/5 min-w-80 flex-row flex-wrap items-center justify-center  gap-3 rounded-lg bg-snclbrown p-3  shadow-lg"
      >
        <div className="w-full">
          <div className="my-3 flex w-full flex-row items-center text-center text-2xl font-bold text-snclgray">
            <LooksOneRoundedIcon className="text-white" />
            <span>{t("Osnovne informacije o vama")}</span>
          </div>
          <hr className="mx-2 h-0.5 border-0 bg-snclgray" />

          <div className="mt-3 flex flex-col items-center">
            <div className="flex flex-row flex-wrap justify-center">
              <div className="mx-3">
                <p className="text-xl font-bold text-white">
                  {t("ImeAgencije")}
                </p>
                <input
                  name="naziv"
                  placeholder={t("AgencijaPlaceHolder")}
                  type="text"
                  className={
                    errors.naziv && touched.naziv
                      ? inputDugmeKlasaLosa
                      : inputDugmeKlasa
                  }
                  onChange={handleChange}
                  value={values.naziv}
                  onBlur={handleBlur}
                />
                {errors.naziv && touched.naziv && (
                  <p className="text-red">{errors.naziv}</p>
                )}
              </div>
              <div className="mx-3">
                <h1 className="text-xl font-bold text-white">
                  {t("Datum osnivanja")}
                </h1>
                <DatePicker
                  isClearable
                  selected={selectedDate}
                  onChange={(date) => {
                    setSelectedDate(date);
                    handleChange({ target: { name: "datum", value: date } }); // Add this line to set the value in formik
                  }}
                  className="h-8  w-64 rounded-md border-2 shadow-md"
                  popperPlacement="bottom"
                  showIcon
                  placeholderText={t("Unesite datum osnivanja")}
                />
              </div>
              <div className="mx-3">
                <p className="text-xl font-bold text-white">
                  {t("Cena Usluge")}
                </p>
                <input
                  name="cenaUsluge"
                  placeholder={t("Cena vasih usluga u dinarima...")}
                  type="text"
                  className={
                    errors.cenaUsluge && touched.cenaUsluge
                      ? inputDugmeKlasaLosa
                      : inputDugmeKlasa
                  }
                  onChange={handleChange}
                  value={values.cenaUsluge}
                  onBlur={handleBlur}
                />
                {errors.cenaUsluge && touched.cenaUsluge && (
                  <p className="text-red">{errors.cenaUsluge}</p>
                )}
              </div>
              <div className="mx-3">
                <p className="text-xl font-bold text-white">
                  {t("Broj Telefona")}
                </p>
                <input
                  name="brojTelefona"
                  placeholder={t("Vas broj telefona...")}
                  type="text"
                  className={
                    errors.brojTelefona && touched.brojTelefona
                      ? inputDugmeKlasaLosa
                      : inputDugmeKlasa
                  }
                  onChange={handleChange}
                  value={values.brojTelefona}
                  onBlur={handleBlur}
                />
                {errors.brojTelefona && touched.brojTelefona && (
                  <p className="text-red">{errors.brojTelefona}</p>
                )}
              </div>
            </div>
            {/* Repeat similar input fields for other form elements */}
          </div>
        </div>
        <div className="w-full">
          <div className="my-3 flex w-full flex-row items-center text-center text-2xl font-bold text-snclgray">
            <LooksTwoRoundedIcon className="text-white" />
            {t("Informacije o nalogu")}
          </div>
          <hr className="mx-2 h-0.5 border-0 bg-snclgray" />

          <div className="mt-3 flex flex-col flex-wrap items-center">
            <div className="flex flex-row flex-wrap  justify-center">
              <div className="mx-3">
                <p className="text-xl font-bold text-white">{t("E-mail")}</p>
                <input
                  name="email"
                  placeholder={t("Unesite vas email...")}
                  type="text"
                  className={
                    errors.email && touched.email
                      ? inputDugmeKlasaLosa
                      : inputDugmeKlasa
                  }
                  onChange={handleChange}
                  value={values.email}
                  onBlur={handleBlur}
                />
                {errors.email && touched.email && (
                  <p className="text-red">{errors.email}</p>
                )}
              </div>{" "}
              <div className="mx-3">
                <p className="text-xl font-bold text-white">
                  {t("Sigurnosni kod")}
                </p>
                <input
                  name="skod"
                  placeholder={t("Unestie vas sigurnosni kod...")}
                  type="text"
                  className={
                    errors.skod && touched.skod
                      ? inputDugmeKlasaLosa
                      : inputDugmeKlasa
                  }
                  onChange={handleChange}
                  value={values.skod}
                  onBlur={handleBlur}
                />
                {errors.skod && touched.skod && (
                  <p className="text-red">{errors.skod}</p>
                )}
              </div>
            </div>
            <div className="flex flex-row flex-wrap  justify-center ">
              <div className="mx-3">
                <p className="text-xl font-bold text-white">{t("password")}</p>
                <input
                  name="password"
                  placeholder={t("Upisite vasu sifru...")}
                  type="password"
                  className={
                    errors.password && touched.password
                      ? inputDugmeKlasaLosa
                      : inputDugmeKlasa
                  }
                  onChange={handleChange}
                  value={values.password}
                  onBlur={handleBlur}
                />
                {errors.password && touched.password && (
                  <p className="text-red">{errors.password}</p>
                )}
              </div>
              <div className="mx-3">
                <p className="text-xl font-bold text-white">
                  {t("confirmPassword")}
                </p>
                <input
                  name="confirmPassword"
                  placeholder={t("Potvrdite vasu sifru...")}
                  type="password"
                  className={
                    errors.confirmPassword && touched.confirmPassword
                      ? inputDugmeKlasaLosa
                      : inputDugmeKlasa
                  }
                  onChange={handleChange}
                  value={values.confirmPassword}
                  onBlur={handleBlur}
                />
                {errors.confirmPassword && touched.confirmPassword && (
                  <p className="text-red">{errors.confirmPassword}</p>
                )}
              </div>
            </div>
          </div>
        </div>
        <div className="w-full">
          <div className="my-3 flex w-full flex-row items-center text-center text-2xl font-bold text-snclgray">
            <Looks3RoundedIcon className="text-white" />
            Ostale informacije
          </div>
          <hr className="mx-2 h-0.5 border-0 bg-snclgray" />

          <div className="mt-6 flex flex-col items-center px-6">
            <textarea
              placeholder={t("Dodajte kratak opis...")}
              name="opis"
              type="text"
              className={
                errors.opis && touched.opis
                  ? "h-32 w-full rounded-md px-2 shadow-md outline-none ring-1 ring-red"
                  : "h-32 w-full rounded-md px-2 shadow-md"
              }
              onChange={handleChange}
              value={values.opis}
              onBlur={handleBlur}
              maxLength={200} // Limit the number of characters (words)
              rows={2} // Set the initial number of visible rows
              style={{ resize: "vertical", textAlign: "start" }}
            />
            {errors.opis && touched.opis && (
              <p className="text-red">{errors.opis}</p>
            )}
            <div className="mt-3 flex flex-row flex-wrap justify-center">
              <div className="mx-2">
                <p className="text-xl font-bold text-white">{t("Lokacija")}</p>
                <input
                  name="lokacija"
                  type="text"
                  className={
                    errors.lokacija && touched.lokacija
                      ? inputDugmeKlasaLosa
                      : inputDugmeKlasa
                  }
                  onChange={handleChange}
                  value={values.lokacija}
                  onBlur={handleBlur}
                  placeholder={t("Vasa lokacija")}
                />
                {errors.lokacija && touched.lokacija && (
                  <p className="text-red">{errors.lokacija}</p>
                )}
              </div>{" "}
            </div>
            <button
              type="submit"
              className=" my-6 h-10 w-36  rounded-lg bg-sncpink text-white shadow-lg hover:bg-snclpink"
            >
              {t("Registruj se")}
            </button>
            <h1 className="mx-2 mb-3 text-center">
              {t("Vec imas nalog?")}
              <span>
                <button
                  type="button"
                  className=" mx-2 text-sncpink hover:text-snclpink"
                >
                  {t("Prijavi se!")}
                </button>
              </span>
            </h1>
          </div>
        </div>
      </form>
    </div>
  );
}

export default RegisterDekoraterPage;
// Kul stvar
// <div className=" flex size-full flex-col items-center justify-center bg-snclbrown">
// <span className="-rotate-90 transform text-8xl font-bold text-white">Svadba na Klik</span>
// </div>
