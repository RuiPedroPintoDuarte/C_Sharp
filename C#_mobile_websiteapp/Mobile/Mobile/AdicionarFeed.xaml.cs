using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RecursoM;

namespace Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdicionarFeed : ContentPage
    {
        public Rss_FeedM feed { get; private set; }
        public AdicionarFeed()
        {
            InitializeComponent();
        }

       
        private void Guardado(object sender, EventArgs e)
        {
            feed = new Rss_FeedM();
            feed.TituloM = this.FindByName<Entry>("Etitulo").ToString();
            feed.UrlM = this.FindByName<Entry>("Etitulo").ToString();
            feed.DescricaoM = this.FindByName<Entry>("Etitulo").ToString();
            feed.AutorM = this.FindByName<Entry>("Etitulo").ToString();
            foreach (var word in this.FindByName<Entry>("Etitulo").Text.Split(' '))
                feed.Palavra_ChaveM.Add(this.FindByName<Entry>("Etitulo").ToString());
            App.Current.MainPage = new MainPage();
        }

        private void Button_Back(object sender, EventArgs e)
        {
           
        }

        private void Button_opt(object sender, EventArgs e)
        {
          
        }
    }
}