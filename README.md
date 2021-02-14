# QRCode-Generate-Api-ReactJS
Projeto de Front-End + Back-End (C# e React) para gerar QRCode

## Back-End

O projeto do Back-end está em C# e utiliza o QRCoder

```xml
<PackageReference Include="QRCoder" Version="1.4.1" />
```

Código de exemplo para gerar o QRCode

```c#
  [HttpPost]
  public string Generate([FromBody] Parametro data)
  {
      var qrCodeData = new QRCodeGenerator().CreateQrCode(data.Dado, QRCodeGenerator.ECCLevel.M);
      var qrCode = new QRCode(qrCodeData);
      var qrCodeImage = qrCode.GetGraphic(20);
      return Convert.ToBase64String(ImageToByte(qrCodeImage));
  }

  private static byte[] ImageToByte(Image img)
  {
      var converter = new ImageConverter();
      return (byte[])converter.ConvertTo(img, typeof(byte[]));
  }
```

## Front-End

O Front-end está desenvolvido em React e consome a API no change do input *** somente por motivos de testes (estudo) ***

```js
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
```
Para fazer o post para a api é utilizado o axios

```js
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
```
