import React, { useEffect, useState } from 'react';
import './App.css';

import { getQrCode } from './Api'; 

function App() {
  const [textoQr, setTextoQr] = useState('');  
  const [image, setImage] = useState('');
  
  useEffect(() => {
     (async () => setImage(await getQrCode(textoQr)))(); 
  }, [textoQr]); 

  return (
    <div className="App">
      <input
        type="text"
        value={textoQr}  
        onChange={(e) => setTextoQr(e.target.value)}
       /> 
      <br />
      {image ? <img src={image} alt="dasd" width={500} /> : 'Carregando ....'} 
    </div>
  );
}

export default App;
