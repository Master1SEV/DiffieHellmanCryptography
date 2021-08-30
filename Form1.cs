using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {   
        public ECDiffieHellmanCng ECDH;

        public Form1()
        {
            InitializeComponent();
        }

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

        private void publicKeyATextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void publicKeyBTextBox_TextChanged(object sender, EventArgs e)
        {

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
                // Для чтения ключа второй стороны 
                secretKeyTextBox.Text = BitConverter.ToString(aKey);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void secretKeyTextBox_TextChanged(object sender, EventArgs e)
        {

        }

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
                // создание экземпляр класса алгоритма AES и передача ему сформированный общего секретного ключа
                // и вектора инициализации
                Aes aes = Aes.Create();
                aes.Key = aesKey;
                aes.IV = aesIV;
                // режим шифрования: сцепление блоков шифротекста Cipher Block Chaining (CBC)
                aes.Mode = CipherMode.CBC;
                ICryptoTransform transform = aes.CreateEncryptor(aesKey, aesIV);
                byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                richTextBox2.Text = Convert.ToBase64String(outputBuffer);
                // Для чтения ключа второй стороны 
                secretKeyTextBox.Text = BitConverter.ToString(aesKey);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

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
                // Для чтения ключа второй стороны 
                secretKeyTextBox.Text = BitConverter.ToString(aesKey);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
