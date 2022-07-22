using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Recurso;


namespace Rss
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        public List<Rss_Feed> RssFeed;
        public Rss_Feed Arquivo;
        public Rss_Item Item;
        public Rss_Feed Notificacao;
        public Notificacao notif;
        public Ficheiro ficheiro { get; private set; }
        App()
        {
            InitializeComponent();
            RssFeed = new List<Rss_Feed>();
            Arquivo = new Rss_Feed();
            Item = new Rss_Item();
            Notificacao = new Rss_Feed();
            notif = new Notificacao();
            Arquivo.Titulo = "Arquivo";
            Notificacao.Titulo = "Notificações";
            ficheiro = new Ficheiro();
            Rss_Feed Feed = new Rss_Feed()
            {
                Titulo = "Métodos",
                Url = "https://side.utad.pt/cursos/einformatica",
                Descricao = "As he crossed toward the pharmacy at the corner he involuntarily turned his head because of a burst of light that had ricocheted from his temple, and saw, with that quick smile with which we greet a rainbow or a rose, a blindingly white parallelogram of sky being unloaded from the van—a dresser with mirrors across which, as across a cinema screen, passed a flawlessly clear reflection of boughs sliding and swaying not arboreally, but with a human vacillation, produced by the nature of those who were carrying this sky, these boughs, this gliding façade.",
                Data = DateTime.Now,
                Autor = "Admin",
            };
            RssFeed.Add(Feed);
        }
    }
}
