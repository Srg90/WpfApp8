using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ComboFN.ItemsSource = new string[5] { "Arial", "Times New Roman", "Verdana", "Comic Sans MS", "Gabriola" };
            ComboFS.ItemsSource = new int[14] { 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        }
        private void Select1(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem).ToString();
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void Select2(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = ((sender as ComboBox).SelectedItem).ToString();
            double FS = Double.Parse(fontSize);
            if (textBox != null)
            {
                textBox.FontSize = FS;
            }
        }
        private void ClickBold(object sender, ExecutedRoutedEventArgs e)
        {
            if (bold.IsChecked == true)
            {
                textBox.FontWeight = FontWeights.Bold;
            }
            else
            {
                textBox.FontWeight = FontWeights.Regular;
            }
        }
        private void ClickItalic(object sender, ExecutedRoutedEventArgs e)
        {
            if (italic.IsChecked == true)
            {
                textBox.FontStyle = FontStyles.Italic;
            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;
            }
        }
        private void ClickUnderline(object sender, ExecutedRoutedEventArgs e)
        {
            if (underline.IsChecked == true)
            {
                textBox.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                textBox.TextDecorations = null;
            }
        }
        private void Color(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox != null & colorBlack.IsChecked == true)
            {
                textBox.Foreground = Brushes.Black;
            }
            else if (textBox != null & colorBlack.IsChecked != true)
            {
                textBox.Foreground = Brushes.Red;
            }
        }
        private void Open(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Format (*.txt)|*.txt|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(dlg.FileName);
            }
        }
        private void Save(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text Format (*.txt)|*.txt|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, textBox.Text);
            }
        }
        private void Close(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
