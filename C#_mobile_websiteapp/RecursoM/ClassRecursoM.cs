using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;

//using Rss;

namespace RecursoM
{
    public class ClassRecursoM
    {
      
    }
    
        public class Rss_FeedM
        {
        public string TituloM { get; set; }
        public string UrlM { get; set; }
        public string Link_ImagemM { get; set; }
        public string DescricaoM { get; set; }
        public DateTime DataM { get; set; }
        public List<Rss_ItemM> itemsM { get; set; }
        public string AutorM { get; set; }
        public List<string> Palavra_ChaveM { get; set; }
        public string Nome_FicheiroM { get; set; }

        public Rss_FeedM()
        {
            Rss_ItemM RsItemM = new Rss_ItemM();
            itemsM = new List<Rss_ItemM>();
            Palavra_ChaveM = new List<string>();
           
            RsItemM.TituloM = "Titulo do artigo!";
            RsItemM.DescricaoM = "Descrição media do artigo e tal mais coisa";
            RsItemM.Link_ImagemM = "https://assets3.thrillist.com/v1/image/1299820/size/tmg-article_default_mobile;jpeg_quality=20.jpg";
            RsItemM.LinkM = "https://side.utad.pt/cursos/einformatica/principal";
            itemsM.Add(RsItemM);
            RsItemM = new Rss_ItemM();
            RsItemM.TituloM = "FREE TVs!!!!";
            RsItemM.DescricaoM = "As he crossed toward the pharmacy at the corner he involuntarily turned his head because of a burst of light that had ricocheted from his temple, and saw, with that quick smile with which we greet a rainbow or a rose, a blindingly white parallelogram of sky being unloaded from the van—a dresser with mirrors across which, as across a cinema screen, passed a flawlessly clear reflection of boughs sliding and swaying not arboreally, but with a human vacillation, produced by the nature of those who were carrying this sky, these boughs, this gliding façade.";
            RsItemM.Link_ImagemM = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.setaswall.com%2Fwp-content%2Fuploads%2F2017%2F03%2FSky-Phone-Wallpaper-1080x2340-099.jpg&f=1&nofb=1";
            RsItemM.LinkM = "https://side.utad.pt/cursos/einformatica/principal";
            itemsM.Add(RsItemM);
        }

    }

    public class Rss_ItemM
    {
        public string TituloM { get; set; }
        public string LinkM { get; set; }
        public DateTime Data_LancamentoM { get; set; }
        public bool VisualizadoM { get; set; }
        public string DescricaoM { get; set; }
        public bool ArquivadoM { get; set; }
        public string Link_ImagemM { get; set; }

        public bool alt_Notificar_UtilizadoM { get; set; }
        public bool alt_Notificacao_LidaM { get; set; }
        public bool alt_Notificacao_ArquivadaM { get; set; }
        public int Criar_NotificacaoM() { return 1; }
    }


    /*
    public class Notificacao
    {
        public Rss_Item item { get; set; }
        public bool Notificar_Utilizado { get; set; }
        public bool Notificacao_Lida { get; set; }
        public bool Notificacao_Arquivada { get; set; }

        Notificacao()
        {
            item = new Rss_Item();
        }

        public int Notificar_Utilizador() { return 1; }
    }
    */
}
