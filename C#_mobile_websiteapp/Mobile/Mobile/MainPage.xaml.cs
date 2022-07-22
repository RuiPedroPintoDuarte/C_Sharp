using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RecursoM;

namespace Mobile
{
    public partial class MainPage : ContentPage
    {
        App app;
        Rss_FeedM CurrentFeed;
        List<String> options;
        public MainPage()
        {
            InitializeComponent();
            app = App.Current as App;
            BindingContext = app.RssFeed;
            lstText.ItemsSource = app.RssFeed;
            options = new List<string>();
            options.Add("Adicionar Feed");
        }

        private void lstText_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (CurrentFeed == null)
            {
                CurrentFeed = (Rss_FeedM)lstText.SelectedItem;
                BindingContext = CurrentFeed.itemsM;
                lstText.ItemsSource = CurrentFeed.itemsM;
                options = new List<string>();
                options.Add("Recarregar o feed");
                options.Add("Editar o feed"); 
                options.Add("Remover feed");
            }
        }

        private void Button_Back(object sender, EventArgs e)
        {
            if (lstText.IsVisible == false)
            {
                lstText.IsVisible = true;
                lstOptions.IsVisible = false;
            }
            else if (CurrentFeed != null)
            {
                CurrentFeed = null;
                BindingContext = app.RssFeed;
                lstText.ItemsSource = app.RssFeed;
                options = new List<string>();
                options.Add("Adicionar Feed");
                
            }
        }

        private void Button_opt(object sender, EventArgs e)
        {
            if (lstText.IsVisible == false)
            {
                lstText.IsVisible = true;
                lstOptions.IsVisible = false;
                BindingContext = app.RssFeed;
                lstText.ItemsSource = app.RssFeed;
            }
            else
            {
                lstText.IsVisible = false;
                lstOptions.IsVisible = true;
                BindingContext = options;
                lstOptions.ItemsSource = options;
            }
        }

        private void Button_Feeds(object sender, EventArgs e)
        {
            if (lstText.IsVisible == false)
            {
                lstText.IsVisible = true;
                lstOptions.IsVisible = false;
            }
            CurrentFeed = null;
            BindingContext = app.RssFeed;
            lstText.ItemsSource = app.RssFeed;
            options = new List<string>();
            options.Add("Adicionar Feed");
        }

        private void Button_Arq(object sender, EventArgs e)
        {
            if (lstText.IsVisible == false)
            {
                lstText.IsVisible = true;
                lstOptions.IsVisible = false;
            }
            CurrentFeed = app.Arquivo;
            BindingContext = CurrentFeed.itemsM;
            lstText.ItemsSource = CurrentFeed.itemsM;
            options = new List<string>();
            options.Add("Recarregar o feed");
        }

        private void Button_Not(object sender, EventArgs e)
        {
            if (lstText.IsVisible == false)
            {
                lstText.IsVisible = true;
                lstOptions.IsVisible = false;
            }
            CurrentFeed = app.Notificacao;
            BindingContext = CurrentFeed.itemsM;
            lstText.ItemsSource = CurrentFeed.itemsM;
            options = new List<string>();
            options.Add("Recarregar o feed");
        }

        private void lstOptions_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            App.Current.MainPage = new AdicionarFeed();
            lstText.ItemsSource = app.RssFeed;
        }
    }
}
