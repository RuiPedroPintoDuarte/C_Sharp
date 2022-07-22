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
using System.ComponentModel;

namespace Rss
{
    /// <summary>
    /// Interaction logic for Horas.xaml
    /// </summary>
    public partial class Horas : Window
    {
        public Horas()
        {
            InitializeComponent();
            
            for (int i = 0; i <= 23; i++)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = i;
                hora.Items.Add(itm);
            }

            for (int j = 0; j <= 59; j++)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = j;
                minuto.Items.Add(itm);
            }

        }

        public string Hora { get; set; }
        public string Minuto { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_Click_G(object sender, RoutedEventArgs e)
        {
            
            if((hora.SelectedItem as ListBoxItem).Content.ToString() == "Horas" || (minuto.SelectedItem as ListBoxItem).Content.ToString() == "Minutos")
            {
                MessageBox.Show("Tem de selecionar o horário pretendido!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                this.DialogResult = true;
                Hora = (hora.SelectedItem as ListBoxItem).Content.ToString();
                Minuto = (minuto.SelectedItem as ListBoxItem).Content.ToString();
            }
            
        }
    }
}
