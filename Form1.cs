using System;
using System.Windows.Forms;

namespace SzyfrCezara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Definicja pełnego alfabetu polskiego, który uwzględnia polskie znaki
        private static readonly string Alphabet = "aąbcćdeęfghijklłmnńoóprsśtuwyzźż";

        // Funkcja szyfrująca tekst za pomocą szyfru Cezara z obsługą polskich znaków
        private string Encrypt(string input, int shift)
        {
            string result = "";
            foreach (char c in input.ToLower()) // Przekształcamy tekst na małe litery
            {
                int index = Alphabet.IndexOf(c);
                if (index >= 0)
                {
                    int newIndex = (index + shift) % Alphabet.Length;
                    if (newIndex < 0) newIndex += Alphabet.Length; // Zapewnienie pozytywnego przesunięcia
                    result += Alphabet[newIndex];
                }
                else
                {
                    result += c; // Inne znaki nie są zmieniane
                }
            }
            return result;
        }

        // Funkcja deszyfrująca tekst za pomocą szyfru Cezara
        private string Decrypt(string input, int shift)
        {
            return Encrypt(input, -shift); // Deszyfrowanie to szyfrowanie z odwrotnym przesunięciem
        }

        // Funkcja obsługująca kliknięcie przycisku szyfrowania
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtShift.Text, out int shift))
            {
                string input = txtInput.Text;
                string encryptedText = Encrypt(input, shift);
                txtOutput.Text = encryptedText;
            }
            else
            {
                MessageBox.Show("Proszę podać poprawne przesunięcie.");
            }
        }

        // Funkcja obsługująca kliknięcie przycisku deszyfrowania
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtShift.Text, out int shift))
            {
                string input = txtInput.Text;
                string decryptedText = Decrypt(input, shift);
                txtOutput.Text = decryptedText;
            }
            else
            {
                MessageBox.Show("Proszę podać poprawne przesunięcie.");
            }
        }
    }
}
