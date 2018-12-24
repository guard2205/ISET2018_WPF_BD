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
using System.IO;
using System.Globalization;
using System.Windows.Forms;
using System.Text.RegularExpressions;
// using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace ISET2018_WPFBD.View
{
 /// <summary>
 /// Logique d'interaction pour Personne.xaml
 /// </summary>
 public partial class EcranPersonne : Window
 {

        //private static Excel.Workbook MyBook = null;
        //private static Excel.Application MyApp = null;
        //private static Excel.Worksheet MySheet = null;

        private ViewModel.VM_Personne LocalPersonne;
  public EcranPersonne()
  {
   InitializeComponent();
   LocalPersonne = new ViewModel.VM_Personne();
   DataContext = LocalPersonne;
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Titre du document")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Liste de personnes encodées"));
            fd.Blocks.Add(p);
            List l = new List();
            foreach(Model.C_Personne cp in LocalPersonne.BcpPersonnes)
            {
                Paragraph pl = new Paragraph(new Run(cp.Pre + " " + cp.Nom + " (" + cp.Nai.ToShortDateString() +")" ));
                l.ListItems.Add(new ListItem(pl));
            }
            fd.Blocks.Add(l);
            rtbDoc.Document = fd;
            FileStream fs = new FileStream(@"D:\essai.rtf", FileMode.Create);
            TextRange tr = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
            tr.Save(fs, System.Windows.DataFormats.Rtf);
  }
  private void dgPersonnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
  { if(dgPersonnes.SelectedIndex >= 0) LocalPersonne.PersonneSelectionnee2UnePersonne(); }

        

        private void bExcelClick(object sender, RoutedEventArgs e)
        {
            Excel.Application xl = null;
            Excel._Workbook wb = null;
            int i = 1;
            // Create a new instance of Excel from scratch
            xl = new Excel.Application();
            xl.Visible = true;
            wb = (Excel._Workbook)(xl.Workbooks.Add(Type.Missing));
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)wb.Worksheets.get_Item(1);

            foreach (Model.C_Personne cp in LocalPersonne.BcpPersonnes)
            {
                int Age = 0;
                //Récupère la date d'aujourd'hui
                DateTime Aujourdhui = DateTime.Now;

                //Calcule de l'age
                if (cp.Nai.Month <= Aujourdhui.Month && cp.Nai.Day <= Aujourdhui.Day)
                {
                    Age = Aujourdhui.Year - cp.Nai.Year;
                }
                else
                    Age = Aujourdhui.Year - cp.Nai.Year - 1;
                xlWorkSheet.Cells[i, 1] = Age ;
                i++;
            }
            int x = i - 1;
            xlWorkSheet.Cells[i, 1] = "MOYENNE Age";
            xlWorkSheet.Cells[i, 2] = "=MOYENNE(A1:A"+ x+ ")";

            if (File.Exists(@"C:\Users\guard\Documents\test.xls") == true)
            {
                File.Delete(@"C:\Users\guard\Documents\test.xls");
                wb.SaveAs(@"C:\Users\guard\Documents\test.xls", Excel.XlFileFormat.xlWorkbookNormal,
            null, null, false, false, Excel.XlSaveAsAccessMode.xlShared,
            false, false, null, null, null);
            }
            else
            {
                wb.SaveAs(@"C:\Users\guard\Documents\test.xls", Excel.XlFileFormat.xlWorkbookNormal,
                null, null, false, false, Excel.XlSaveAsAccessMode.xlShared,
                false, false, null, null, null);
            }

            wb.Close();
            xl.Quit();

            //MyApp = new Excel.Application();
            //MyApp.Visible = true;
            //MyBook = Excel.Workbook.
            //MyApp.Workbooks.Add(Type.Missing);


            //MyBook = MyApp.Workbooks.Add(System.Windows.Forms.Application.StartupPath + @"\Test.xls");
            //MyBook = MyApp.Workbooks.Open( System.Windows.Forms.Application.StartupPath + @"\Test.xls");
            //MySheet = (Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
            //// lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
            //System.Windows.MessageBox.Show("Création de l'Excell ");

        }
    }
    
}
