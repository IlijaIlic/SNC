/* eslint-disable eqeqeq */
/* eslint-disable no-unused-vars */
/* eslint-disable react/prop-types */
import React, { useState, useEffect } from "react";
import IconButton from "@mui/material/IconButton";
import FavoriteIcon from "@mui/icons-material/Favorite";
import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";
import axios from "axios"; // Ensure axios is installed and imported

function LikeButton({ korisnik, oglas }) {
  const [liked, setLiked] = useState(false);

  useEffect(() => {
    console.log(oglas.Liked);
    if (oglas.Liked == true) {
      setLiked(true);
    } else {
      setLiked(false);
    }
  }, [korisnik]);

  const handleLike = async () => {
    setLiked(!liked);
    const endpoint = liked
      ? "http://localhost:8080/deleteLikedEntity"
      : "http://localhost:8080/addLikedEntity";
    try {
      await axios.post(endpoint, {
        UID: korisnik.uid,
        Type: oglas.type, // Ensure Type is correctly defined in korisnik
        EntityID: oglas.ID,
      });
      console.log(liked ? "Deleted like" : "Added like");
    } catch (error) {
      console.error("Error updating like status:", error);
    }
  };

  return (
    <div className="flex items-center">
      <IconButton
        onClick={handleLike}
        aria-label="like post"
        sx={{
          transform: "scale(1.2)", // Make the button 1.2 times bigger
        }}
      >
        {liked ? (
          <FavoriteIcon sx={{ color: "red" }} />
        ) : (
          <FavoriteBorderIcon />
        )}
      </IconButton>
    </div>
  );
}

export default LikeButton;
