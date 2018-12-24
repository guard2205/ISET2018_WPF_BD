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

namespace ISET2018_WPFBD
{
 /// <summary>
 /// Logique d'interaction pour MainWindow.xaml
 /// </summary>
 public partial class MainWindow : Window
 {
  public MainWindow()
  {
   InitializeComponent();
  }
  private void btnPersonne_Click(object sender, RoutedEventArgs e)
  {
   View.EcranPersonne f = new View.EcranPersonne();
   f.ShowDialog();
  }
  private void btnQuitter_Click(object sender, RoutedEventArgs e)
  { Close(); }
 }
}
