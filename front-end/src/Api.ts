import axios from 'axios';

const getQrCode = async function (dado: string) {
  if (!dado) return '';
  const result = await axios.post(
    'https://localhost:44302/api/QRCodeGenerator',
    { dado }
  );
  return 'data:image/png;base64, ' + result.data;
};

export { getQrCode };
