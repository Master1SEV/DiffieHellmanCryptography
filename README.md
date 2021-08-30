# DiffieHellman
## Генерация открытого ключа A 
// Импорт пространства имён System.Security.Cryptography
using System.Security.Cryptography;
private void button1_Click(object sender, EventArgs e)
{
            ECDH = new ECDiffieHellmanCng();
            ECDH.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            ECDH.HashAlgorithm = CngAlgorithm.Sha256;
            publicKeyATextBox.Text = BitConverter.ToString(ECDH.PublicKey.ToByteArray());

            // проверка указания открытого ключа своей стороны 
            if (string.IsNullOrEmpty(publicKeyATextBox.Text))
            {
                MessageBox.Show("Свой открытый ключ не указан");
                return;
            }
            // проверка указания открытого ключа второй стороны
            if (string.IsNullOrEmpty(publicKeyATextBox.Text))
            {
                MessageBox.Show("Открытый ключ второй стороны не указан");
                return;
            }
}
private void createSecretKey_Click(object sender, EventArgs e)
        {
            // Для обработки ошибок, возникающих при формировании 
            // общего секретного ключа 
            try
            {
                string[] strKey = publicKeyBTextBox.Text.Split('-');
                byte[] bKey = new byte[strKey.Length];
                for (int i = 0; i < strKey.Length; i++)
                {
                    uint num = uint.Parse(strKey[i], System.Globalization.NumberStyles.AllowHexSpecifier);
                    bKey[i] = Convert.ToByte(num);
                }
                byte[] aKey = ECDH.DeriveKeyMaterial(CngKey.Import(bKey, CngKeyBlobFormat.EccPublicBlob));
                // Отображение секретного ключа в текстовом поле 
                secretKeyTextBox.Text = BitConverter.ToString(aKey);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

## Шифрование текстовой информации
private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(secretKeyTextBox.Text))
            {
                MessageBox.Show("Секретный ключ не сформирован");
                return;
            }

            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Исходный текст не введен");
                return;
            }
            // Для обработки ошибок, возникающих при формировании 
            // общего секретного ключа 
            try
            {
                // чтение секретного ключа шифровая
                string[] strKey = secretKeyTextBox.Text.Split('-');
                byte[] aesKey = new byte[strKey.Length];
                for (int i = 0; i < strKey.Length; i++)
                {
                    uint num =
                    uint.Parse(strKey[i], System.Globalization.NumberStyles.AllowHexSpecifier);
                    aesKey[i] = Convert.ToByte(num);
                }
                // чтение вектора инициализации
                string[] strIV = secretKeyTextBox.Text.Split('-');
                byte[] aesIV = new byte[16];
                for (int i = 0; i < 16; i++)
                {
                    uint num =
                    uint.Parse(strIV[i], System.Globalization.NumberStyles.AllowHexSpecifier);
                    aesIV[i] = Convert.ToByte(num);
                }
                byte[] inputbuffer = Encoding.Unicode.GetBytes(richTextBox1.Text);
                // создание экземпляр класса алгоритма AES и передача ему 
                // сформированный общего секретного ключа и вектора инициализации
                Aes aes = Aes.Create();
                aes.Key = aesKey;
                aes.IV = aesIV;
                // Режим шифрования: сцепление блоков шифротекста Cipher Block Chaining (CBC)
                aes.Mode = CipherMode.CBC;
                ICryptoTransform transform = aes.CreateEncryptor(aesKey, aesIV);
                byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                richTextBox2.Text = Convert.ToBase64String(outputBuffer);
                // Отображение секретного ключа в текстовом поле
                secretKeyTextBox.Text = BitConverter.ToString(aesKey);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
## Дешифрование
private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(secretKeyTextBox.Text))
            {
                MessageBox.Show("Секретный ключ не сформирован");
                return;
            }

            if (string.IsNullOrEmpty(richTextBox2.Text))
            {
                MessageBox.Show("Исходный текст не введен");
                return;
            }
            // Для обработки ошибок, возникающих при формировании 
            // общего секретного ключа 
            try
            {
                // чтение секретного ключа шифровая
                string[] strKey = secretKeyTextBox.Text.Split('-');
                byte[] aesKey = new byte[strKey.Length];
                for (int i = 0; i < strKey.Length; i++)
                {
                    uint num =
                    uint.Parse(strKey[i], System.Globalization.NumberStyles.AllowHexSpecifier);
                    aesKey[i] = Convert.ToByte(num);
                }
                // чтение вектора инициализации
                string[] strIV = secretKeyTextBox.Text.Split('-');
                byte[] aesIV = new byte[16];
                for (int i = 0; i < 16; i++)
                {
                    uint num =
                    uint.Parse(strIV[i], System.Globalization.NumberStyles.AllowHexSpecifier);
                    aesIV[i] = Convert.ToByte(num);
                }
                // чтения закодированного текста
                //byte[] inputbuffer = Encoding.Unicode.GetBytes(richTextBox2.Text);
                // чтения закодированного текста
                byte[] inputbuffer = Convert.FromBase64String(richTextBox2.Text);

                // создание экземпляр класса алгоритма AES и передача ему сформированный общего секретного ключа
                // и вектора инициализации
                Aes aes = Aes.Create();
                aes.Key = aesKey;
                aes.IV = aesIV;
                // режим шифрования: сцепление блоков шифротекста Cipher Block Chaining (CBC)
                aes.Mode = CipherMode.CBC;
                // Создание дешифратора
                ICryptoTransform transform = aes.CreateDecryptor(aesKey, aesIV);
                // расшифровка закодированного текста
                byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                // вывод расшифрованного текста в текстовое поле richTextBox1
                richTextBox1.Text = Encoding.Unicode.GetString(outputBuffer);
                // Отображение секретного ключа в текстовом поле 
                secretKeyTextBox.Text = BitConverter.ToString(aesKey);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   


2.	Образец пары сгенерированных открытых ключей.
![image](https://user-images.githubusercontent.com/20966308/131289773-15fba92d-c390-47e0-8ac7-ed76e8c758a7.png)

3.	Образец сформированного секретного ключа; 
![image](https://user-images.githubusercontent.com/20966308/131289784-a5a7161e-bde2-436d-b354-6a2bc0a2e0e6.png)

4.	Образец исходного текста
![image](https://user-images.githubusercontent.com/20966308/131289788-e33dd5d7-903c-45e3-b0a4-42b8f6591a42.png)


5.	Результат зашифрованного текста
![image](https://user-images.githubusercontent.com/20966308/131289798-fd027b09-f478-49c1-b04a-39bec2f6640d.png)

6. Результат расшифрованного текста.
![image](https://user-images.githubusercontent.com/20966308/131289810-fadc222e-9645-4d12-a8f7-ce2a758b2201.png)

7. Преимущества гибридного метода шифрования
В симметричных криптосистемах существует опасность раскрытия секретного ключа во время передачи. Комбинированный (гибридный) метод шифрования позволяет сочетать преимущества высокой секретности, предоставляемые асимметричными криптосистемами с открытым ключом, с преимуществами высокой скорости работы, присущими симметричным криптосистемам с секретным ключом. В результате криптосистема с открытым ключом не заменяет симметричную криптосистему с секретным ключом, а лишь дополняет ее, позволяя повысить в целом защищенность передаваемой информации. Два пользователя, желающие обменяться криптографически защищенной информацией, должны обладать общим секретным ключом. Эти пользователи должны обменяться общим ключом по каналу связи безопасным образом. 
Способ безопасного распространения секретных ключей основан на применении алгоритма открытого распределения ключей Диффи-Хеллмана. 
Преимущества алгоритма Диффи – Хеллмана
Этот алгоритм позволяет пользователям обмениваться ключами по незащищенным каналам связи.
Алгоритм Диффи-Хеллмана - криптографический алгоритм, позволяющий двум и более сторонам получить общий секретный ключ K, используя незащищенный от прослушивания канал связи. Полученный ключ используется для шифрования дальнейшего обмена с помощью алгоритмов симметричного шифрования.
Недостатки алгоритма Диффи - Хеллмана
Алгоритм Диффи - Хеллмана работает только на линиях связи, надёжно защищённых от модификации. В тех случаях, когда в канале возможна модификация данных, появляется очевидная возможность вклинивания в процесс генерации ключей «злоумышленника-посредника».
