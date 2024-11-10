import { initializeApp } from 'firebase/app';

import { getAuth } from 'firebase/auth';

const firebaseConfig = {
  apiKey: 'AIzaSyA3Tt0dzRLBborRPn3_gs__WN5zU4JFjsU',
  authDomain: 'auth-development-6584b.firebaseapp.com',
  projectId: 'auth-development-6584b',
  storageBucket: 'auth-development-6584b.appspot.com',
  messagingSenderId: '250391925995',
  appId: '1:250391925995:web:31d9016a49da66c8d35aae',
  measurementId: 'G-F2ZKMFW2N0',
};

const app = initializeApp(firebaseConfig);
export const auth = getAuth(app);
export default auth;
