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
using Recurso;
using Microsoft.Win32;


namespace Rss
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>   titulo, url, descricao alteracao, data, autor, pass,
    public partial class MainWindow : Window
    {
        App app = App.Current as App;
        Rss_Feed Current_Feed;
        Rss_Item Current_Item;
        Notificacao notif;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = app.RssFeed;
            lstText.ItemsSource = app.RssFeed;
            notif = app.notif;
           
        }
        private WindowState m_storedWindowState = WindowState.Normal;

        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            notif.OnClose();
        }

        private void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CheckTrayIcon();
        }

        private void OnStateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
                notif.OnStateChanged();
            }
            else
                m_storedWindowState = WindowState;
        }

        /*public void abrir()
        {
            Show();
            WindowState = m_storedWindowState;
        }*/

        void CheckTrayIcon()
        {
            notif.ShowTrayIcon(!IsVisible);
        }

        private void AdicionarFeed_Click(object sender, RoutedEventArgs e)
        {
            AdicionarFeed dlg = new AdicionarFeed();
            if (dlg.ShowDialog() == true)
            {
                app.RssFeed.Add(dlg.feed);
                lstText.Items.Refresh();
            }
        }

        private void lstText_Selected(object sender, RoutedEventArgs e)
        {
            if (lstText.SelectedItem == null)
                return;
            if (Current_Feed == null)
            {
                foreach (var x in app.RssFeed)
                    if (lstText.SelectedItem == x)
                        Current_Feed = x;
                Header.Text = Current_Feed.Titulo;
                DataContext = Current_Feed.items;
                lstText.ItemsSource = Current_Feed.items;
                back.IsEnabled = true;
            }
            else if (Current_Item == null)
            {
                foreach (var x in Current_Feed.items)
                    if (lstText.SelectedItem == x)
                        Current_Item = x;
                ItemView View = new ItemView(Current_Feed, Current_Item);
                View.ShowDialog();
                Current_Item = null;
                lstText.Items.Refresh();
                back.IsEnabled = true;
            }
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            if (Current_Feed != null)
            {
                DataContext = app.RssFeed;
                lstText.ItemsSource = app.RssFeed;
                Header.Text = "Feeds";
                Current_Feed = null;
                return;
            }
        }

        private void MenuItem_RemoveFeed(object sender, RoutedEventArgs e)
        {
            if (Current_Feed != null && Current_Feed != app.Arquivo && Current_Feed != app.Notificacao)
            {
                if (MessageBox.Show("Deseja apagar o feed?", "Remover", MessageBoxButton.YesNo).ToString() == "Yes")
                {
                    app.RssFeed.Remove(Current_Feed);
                    DataContext = app.RssFeed;
                    lstText.ItemsSource = app.RssFeed;
                    Header.Text = "Feeds";
                    Current_Feed = null;
                    return;
                }
                return;
            }
            if (Current_Feed == null)
                MessageBox.Show("Tem de entrar dentro do feed para o poder remover!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                MessageBox.Show("Não é possivel remover o Arquivo/Notificações!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void MenuItem_Edit(object sender, RoutedEventArgs e)
        {
            if(Current_Feed != null && Current_Feed != app.Arquivo && Current_Feed != app.Notificacao)
            {
                AdicionarFeed dlg = new AdicionarFeed(Current_Feed);
                if(dlg.ShowDialog() == true)
                {
                    app.RssFeed.Remove(Current_Feed);
                    app.RssFeed.Add(dlg.feed);
                    Current_Feed = dlg.feed;
                    lstText.Items.Refresh();
                }
            }
            else if (Current_Feed == null)
                MessageBox.Show("Tem de entrar dentro do feed para o poder editar!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                MessageBox.Show("Não é possivel editar o Arquivo/Notificações!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void MenuItem_Arquivo(object sender, RoutedEventArgs e)
        {
            Current_Feed = app.Arquivo;
            Header.Text = Current_Feed.Titulo;
            DataContext = Current_Feed.items;
            lstText.ItemsSource = Current_Feed.items;

        }

        private void MenuItem_Notific(object sender, RoutedEventArgs e)
        {
            Current_Feed = app.Notificacao;
            Header.Text = Current_Feed.Titulo;
            DataContext = Current_Feed.items;
            lstText.ItemsSource = Current_Feed.items;
        }

        private void MenuItem_Atualizar(object sender, RoutedEventArgs e)
        {
            if (Current_Feed != null)
            {
                lstText.Items.Refresh();
                MessageBox.Show("Atualizado com sucesso!", "Sucesso", MessageBoxButton.OK);
            }
            else
                MessageBox.Show("Entre num Feed para o atualizar!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void MenuItem_Auto(object sender, RoutedEventArgs e)
        {
            Horas dlg = new Horas();
            if (dlg.ShowDialog() == true)
            {
                if (Current_Feed != null)
                {
                    MessageBox.Show("Horário definido!", "Sucesso", MessageBoxButton.OK);

                    if (DateTime.Now.Hour.ToString() == dlg.Hora && DateTime.Now.Minute.ToString() == dlg.Minuto)
                    {
                        lstText.Items.Refresh();
                        MessageBox.Show("Atualizado com sucesso!", "Sucesso", MessageBoxButton.OK);
                    }
                }
                else
                    MessageBox.Show("Entre num Feed para o atualizar!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        
    }
}
