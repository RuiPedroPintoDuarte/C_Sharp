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
using System.Windows.Shapes;
using Recurso;

namespace Rss
{
    /// <summary>
    /// Interaction logic for AdicionarFeed.xaml
    /// </summary>
    public partial class AdicionarFeed : Window
    {
        public Rss_Feed feed { get; private set; }
        public AdicionarFeed()
        {
            InitializeComponent();
            feed = new Rss_Feed();
            txtTitulo.Text = "Título";
            txtUrl.Text = "Url";
            txtDescricao.Text = "Descrição";
            txtAutor.Text = "Autor";
            txtPalavraChave.Text = "Palavra-Chave";

        }
        public AdicionarFeed(Rss_Feed RssFeed)
        {
            InitializeComponent();
            feed = new Rss_Feed();
            txtTitulo.Text = RssFeed.Titulo;
            txtUrl.Text = RssFeed.Url;
            txtDescricao.Text = RssFeed.Descricao;
            txtAutor.Text = RssFeed.Autor;
            foreach (var palavra in RssFeed.Palavra_Chave)
                txtPalavraChave.Text += palavra + ' ';
            btnAdd.Content = "Guardar";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(txtTitulo.Text=="" || txtUrl.Text == "" || txtDescricao.Text == "" || txtAutor.Text == "" || txtPalavraChave.Text == "")
            {
                MessageBox.Show("Tem que preencher todos os campos!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                this.DialogResult = true;
                feed.Titulo = txtTitulo.Text;
                feed.Url = txtUrl.Text;
                feed.Descricao = txtDescricao.Text;
                feed.Autor = txtAutor.Text;
                feed.Data = DateTime.Now;
                foreach (var word in txtPalavraChave.Text.Split(' '))
                    feed.Palavra_Chave.Add(word);
            }
            

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

    }
}
