/* eslint-disable react/jsx-props-no-multi-spaces */
/* eslint-disable no-underscore-dangle */
/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
/* eslint-disable react/jsx-props-no-spreading */
import TryIcon from '@mui/icons-material/Try';
import Box from '@mui/material/Box';
import Badge from '@mui/material/Badge';
import NewReleasesIcon from '@mui/icons-material/NewReleases';
import Button from '@mui/material/Button';
import SendIcon from '@mui/icons-material/Send';
import Stack from '@mui/material/Stack';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import * as React from 'react';
import { styled } from '@mui/material/styles';
import Card from '@mui/material/Card';
import CardHeader from '@mui/material/CardHeader';
import CardMedia from '@mui/material/CardMedia';
import CardContent from '@mui/material/CardContent';
import CardActions from '@mui/material/CardActions';
import Collapse from '@mui/material/Collapse';
import Avatar from '@mui/material/Avatar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import { red } from '@mui/material/colors';
import FavoriteIcon from '@mui/icons-material/Favorite';
import ShareIcon from '@mui/icons-material/Share';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import MoreVertIcon from '@mui/icons-material/MoreVert';
import { HiCamera } from 'react-icons/hi';
import Rating from '@mui/material/Rating';
import { useState, useEffect } from 'react';
import { useTranslation } from 'react-i18next';
import FotografClass from './FotografClass';
import LikeButton from './LikeButton';

// engleski PREVEDENO
const ExpandMore = styled((props) => {
  const { expand, ...other } = props;
  return <IconButton {...other} />;
})(({ theme, expand }) => ({
  transform: !expand ? 'rotate(0deg)' : 'rotate(180deg)',
  marginLeft: 'auto',
  transition: theme.transitions.create('transform', {
    duration: theme.transitions.duration.shortest,
  }),
}));

export default function OglasiCardMladenac({ fotograf, korisnik }) {
  const { t } = useTranslation();
  const [isNew, setisNew] = useState(false);
  console.log('uso sam');
  const [expanded, setExpanded] = React.useState(false);
  // console.log(fotograf);
  const url = `/fotograf/${fotograf.ID}`;
  const handleExpandClick = () => {
    setExpanded(!expanded);
  };
  console.log('evo me!');
  console.log(`${fotograf.Ocena} ${fotograf.Liked}`);
  useEffect(() => {
    if (fotograf.Ocena == null) {
      setisNew(true);
    } else {
      setisNew(false);
    }
  }, [fotograf]);

  return (
    <Card sx={{
      maxWidth: 345, bgcolor: '#EAE4CC', border: '3px solid #B4436C', position: 'relative',
    }}
    >
      {isNew && (
      <Badge
        color="primary"
        badgeContent={(
          <Box
            sx={{
              display: 'flex',
              alignItems: 'center',
              justifyContent: 'center',
              fontSize: 16,
              fontWeight: 'bold',
              color: 'white',
            }}
          >
            <TryIcon sx={{ fontSize: 24, marginRight: 0.5 }} />
            New
          </Box>
         )}
        sx={{
          position: 'absolute',
          top: 18,
          right: 50,
          zIndex: 1,
          transform: 'translate(50%, -50%)', // Adjust positioning if needed
        }}
      />
      )}

      <CardHeader
        avatar={(
          <Avatar sx={{ bgcolor: red[500] }} aria-label="recipe">
            <HiCamera />
          </Avatar>
        )}

        title={fotograf._NazivAgencije}
        subheader={(
          <>
            <Typography variant="body2" color="text.secondary">
              {t('Datumi Osnivanja')}
              {' '}
              {fotograf._Datumosnivanja.toDateString()}
            </Typography>
            <Rating name="read-only" value={fotograf.Ocena} precision={0.1} readOnly />
          </>
        )}
      />
      <Typography
        sx={{
          display: 'flex',
          alignItems: 'center', // Align vertically
          justifyContent: 'start', // Align horizontally
          paddingLeft: '16px',
        }}
      >
        {`Lokacija : ${fotograf._Lokacija}`}
      </Typography>
      <CardContent>
        <Typography variant="body2" color="text.secondary">
          {fotograf._OpisKompanije}
        </Typography>
      </CardContent>
      <CardActions disableSpacing>

        <Link className="ml-2 mr-20 hover:text-snclbrown" to={url}>
          <Button variant="contained" endIcon={<SendIcon />}>
            {' '}
            {t('visitAd')}
            {' '}
          </Button>
        </Link>

        <LikeButton korisnik={korisnik} oglas={fotograf} />

      </CardActions>

    </Card>
  );
}
