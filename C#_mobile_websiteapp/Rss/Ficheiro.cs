using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using Recurso;

namespace Rss
{
    public class Ficheiro
    {
        public delegate void voidNoArgs();
        public event voidNoArgs ReadEnded;
        public event voidNoArgs WriteEnded;
        App app = App.Current as App;

        public void ReadFromXML(string file)
        {
            XDocument doc = XDocument.Load(file);
            var regists = from feed in doc.Element("Item_Feed").Descendants("Item_Feed") select feed;
            foreach (var fields in regists)
            {
                Rss_Feed item = new Rss_Feed();
                item.Titulo = fields.Element("Titulo").Value;
                item.Url = fields.Element("Url").Value;
                item.Link_Imagem = fields.Element("Link_Imagem").Value;
                item.Descricao = fields.Element("Descricao").Value;
                item.Data = DateTime.Parse(fields.Element("Data").Value);
                item.Autor = fields.Element("Autor").Value;
                item.Nome_Ficheiro = fields.Element("Nome_Ficheiro").Value;
            }

            if (ReadEnded != null)
                ReadEnded();
        }

        public void WriteToXML(string file)
        {
            
            XDocument xdoc = new XDocument(new XDeclaration("1.0", Encoding.UTF8.ToString(), "yes"),
                                           new XComment("Listagem de Feed"),
                                           new XElement("Item_Feed"));
            foreach (Rss_Feed x in app.RssFeed)
            {
                XElement xFeed = new XElement("Item_Feed", new XElement("Titulo", x.Titulo),
                                                              new XElement("Url", x.Url),
                                                              new XElement("Link_Imagem", x.Link_Imagem),
                                                              new XElement("Descricao", x.Descricao),
                                                              new XElement("Data", x.Data),
                                                              new XElement("items", x.items),
                                                              new XElement("Autor", x.Autor), 
                                                              new XElement("Palavra_Chave", x.Palavra_Chave),
                                                              new XElement("Nome_Ficheiro", x.Nome_Ficheiro));
            }
            xdoc.Save(file);
            if (WriteEnded != null)
                WriteEnded();
        }
    }
}
