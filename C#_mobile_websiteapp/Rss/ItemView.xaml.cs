using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using Recurso;
using Microsoft.Win32;

namespace Rss
{
    /// <summary>
    /// Interaction logic for ItemView.xaml
    /// </summary>
    public partial class ItemView : Window
    {
        Rss_Item item;
        Rss_Feed feed;
        App app;
        public ItemView(Rss_Feed Rsfeed, Rss_Item RsItem)
        {
            InitializeComponent();
            app = App.Current as App;
            feed = Rsfeed;
            item = RsItem;
            Uri uri = new Uri(RsItem.Link);
            webBrowser.Navigate(uri);
        }

        private void MenuItem_Browser(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo(@"C:\Program Files\Internet Explorer\iexplore.exe", item.Link);
            Process.Start(info);
            this.Close();
        }

        private void MenuItem_Arquivar(object sender, RoutedEventArgs e)
        {
            app.Arquivo.items.Add(item);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Ficheiros XML|*.xml|Todos os ficheiros|*.*";
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    app.ficheiro.WriteToXML(dlg.FileName);
                }
                catch (InvalidOperationException erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
            MessageBox.Show("Arquivado com sucesso!", "Sucesso", MessageBoxButton.OK);
        }

        private void MenuItem_Remover(object sender, RoutedEventArgs e)
        {
            feed.items.Remove(item);
            MessageBox.Show("Item removido com sucesso!", "Sucesso", MessageBoxButton.OK);
        }
    }
}
