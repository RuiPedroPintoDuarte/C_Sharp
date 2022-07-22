using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RecursoM;
using System.Collections.Generic;

namespace Mobile
{
    public partial class App : Application
    {
        public List<Rss_FeedM> RssFeed;
        public Rss_FeedM Arquivo;
        public Rss_FeedM Notificacao;
        public App()
        {
            InitializeComponent();
            RssFeed = new List<Rss_FeedM>();
            Arquivo = new Rss_FeedM();
            Notificacao = new Rss_FeedM();
            Arquivo.TituloM = "Arquivo";
            Notificacao.TituloM = "Notificações";
            Rss_FeedM Feed = new Rss_FeedM()
            {
                TituloM = "Métodos",
                UrlM = "https://side.utad.pt/cursos/einformatica",
                DescricaoM = "As he crossed toward the pharmacy at the corner he involuntarily turned his head because of a burst of light that had ricocheted from his temple, and saw, with that quick smile with which we greet a rainbow or a rose, a blindingly white parallelogram of sky being unloaded from the van—a dresser with mirrors across which, as across a cinema screen, passed a flawlessly clear reflection of boughs sliding and swaying not arboreally, but with a human vacillation, produced by the nature of those who were carrying this sky, these boughs, this gliding façade.",
                DataM = DateTime.Now,
                AutorM = "Admin",
            };
            RssFeed.Add(Feed);
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
