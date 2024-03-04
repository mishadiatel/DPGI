using System;
using System.Globalization;
using System.Text;
using System.Windows;



namespace Lab3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Шифрування тексту
        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (ShiftTextBox.Text.Trim().Length == 0 || !int.TryParse(ShiftTextBox.Text, out _))
            {
                MessageBox.Show("Please enter shift");
                return;
            }
            int shift = int.Parse(ShiftTextBox.Text);
            string plaintext = InputTextBox.Text;
            string ciphertext = Encrypt(plaintext, shift);
            OutputTextBox.Text = ciphertext;
        }

        // Розшифрування тексту
        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (ShiftTextBox.Text.Trim().Length == 0 || !int.TryParse(ShiftTextBox.Text, out _))
            {
                MessageBox.Show("Please enter shift");
                return;
            }
            int shift = int.Parse(ShiftTextBox.Text);
            string ciphertext = InputTextBox.Text;
            string plaintext = Decrypt(ciphertext, shift);
            OutputTextBox.Text = plaintext;
        }

        // Метод шифрування тексту шифром Цезаря
        
        public string Encrypt(string input, int key) {  
            string output = string.Empty;  
  
            foreach(char ch in input)  
                output += (char)((ch + key));  
  
            return output;  
        }  
  
        public string Decrypt(string input, int key) {  
            return Encrypt(input,  -key);  
        }
    }
}