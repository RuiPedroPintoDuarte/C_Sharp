using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;

//using Rss;

namespace Recurso
{
    public class ClassRecurso
    {
      
    }
    public class Notificacao
    {
        private NotifyIcon m_notifyIcon;
        public Notificacao()
        {
            m_notifyIcon = new System.Windows.Forms.NotifyIcon();
            m_notifyIcon.BalloonTipText = "A aplicação foi minimizada. Clique no icon no Tray para abrir.";
            m_notifyIcon.BalloonTipTitle = "Rss";
            m_notifyIcon.Text = "Rss";
            m_notifyIcon.Icon = new Icon("TheAppIcon.ico");
            m_notifyIcon.Click += new EventHandler(m_notifyIcon_Click);
          
    }
        public void OnClose()
        {
            m_notifyIcon.Dispose();
            m_notifyIcon = null;
        }

        private WindowState m_storedWindowState = WindowState.Normal;
        void m_notifyIcon_Click(object sender, EventArgs e)
        {
            Window main = new Window(); //Falta abrir janela Rss
            main.Show();
            main.WindowState = m_storedWindowState;
        }

        public void OnStateChanged()
        {
            
                if (m_notifyIcon != null)
                    m_notifyIcon.ShowBalloonTip(2000);
            
        }
        

        public void ShowTrayIcon(bool show)
        {
            if (m_notifyIcon != null)
                m_notifyIcon.Visible = show;
        }
    }

        public class Rss_Feed
        {
        public string Titulo { get; set; }
        public string Url { get; set; }
        public string Link_Imagem { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public List<Rss_Item> items { get; set; }
        public string Autor { get; set; }
        public List<string> Palavra_Chave { get; set; }
        public string Nome_Ficheiro { get; set; }

        public Rss_Feed()
        {
            Rss_Item RsItem = new Rss_Item();
            items = new List<Rss_Item>();
            Palavra_Chave = new List<string>();
           
            RsItem.Titulo = "Titulo do artigo!";
            RsItem.Descricao = "Descrição media do artigo e tal mais coisa";
            RsItem.Link_Imagem = "https://assets3.thrillist.com/v1/image/1299820/size/tmg-article_default_mobile;jpeg_quality=20.jpg";
            RsItem.Link = "https://side.utad.pt/cursos/einformatica/principal";
            items.Add(RsItem);
            RsItem = new Rss_Item();
            RsItem.Titulo = "FREE TVs!!!!";
            RsItem.Descricao = "As he crossed toward the pharmacy at the corner he involuntarily turned his head because of a burst of light that had ricocheted from his temple, and saw, with that quick smile with which we greet a rainbow or a rose, a blindingly white parallelogram of sky being unloaded from the van—a dresser with mirrors across which, as across a cinema screen, passed a flawlessly clear reflection of boughs sliding and swaying not arboreally, but with a human vacillation, produced by the nature of those who were carrying this sky, these boughs, this gliding façade.";
            RsItem.Link_Imagem = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.setaswall.com%2Fwp-content%2Fuploads%2F2017%2F03%2FSky-Phone-Wallpaper-1080x2340-099.jpg&f=1&nofb=1";
            RsItem.Link = "https://side.utad.pt/cursos/einformatica/principal";
            items.Add(RsItem);
        }

    }

    public class Rss_Item
    {
        public string Titulo { get; set; }
        public string Link { get; set; }
        public DateTime Data_Lancamento { get; set; }
        public bool Visualizado { get; set; }
        public string Descricao { get; set; }
        public bool Arquivado { get; set; }
        public string Link_Imagem { get; set; }

        public bool alt_Notificar_Utilizado { get; set; }
        public bool alt_Notificacao_Lida { get; set; }
        public bool alt_Notificacao_Arquivada { get; set; }
        public int Criar_Notificacao() { return 1; }
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
