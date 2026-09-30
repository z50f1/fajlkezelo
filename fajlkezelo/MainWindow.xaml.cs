
using System;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;

namespace fajlkezelo
{
    public partial class MainWindow : Window
    {
        string aktualis;

        public MainWindow()
        {
            InitializeComponent();
            aktualis = Directory.GetCurrentDirectory();
            betolt();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory("valami");
            betolt();
        }

        public void betolt()
        {
            fajllista.Items.Clear();
            aktualislabel.Content = aktualis;
            fajllista.Items.Add("..");


            
            string[] mappak = Directory.GetDirectories(aktualis);

            foreach (string mappa in mappak)
            {
                string nev = mappa.Split('\\').Last();
                fajllista.Items.Add("📁 " + nev);
            }


            
            string[] fajlok = Directory.GetFiles(aktualis);

            foreach (string fajl in fajlok)
            {
                string nev = fajl.Split('\\').Last();
                fajllista.Items.Add("📄 " + nev);
            }
        }


        private void fajl(object sender, MouseButtonEventArgs e)
        {
            string kivalasztott = fajllista.SelectedItem.ToString();


            
            if (kivalasztott == "..")
            {
                DirectoryInfo szulo = Directory.GetParent(aktualis);
                if (szulo != null)
                {
                    aktualis = szulo.FullName;
                }
                betolt();
            }


            
            else if (kivalasztott.StartsWith("📁"))
            {
                string nev = kivalasztott.Substring(3);
                aktualis = aktualis + "\\" + nev;
                betolt();
            }


            
            else if (kivalasztott.StartsWith("📄"))
            {
                string nev = kivalasztott.Substring(3);
                string fajl = aktualis + "\\" + nev;
                StreamReader sr = new StreamReader(fajl);
                fajlbetoltese.Text = sr.ReadToEnd();
            }
        }
    }
}
