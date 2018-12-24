using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISET2018_WPFBD.Model
{
 public class G_Base
 {
  private string _ChaineConnexion;
  public G_Base()
  { ChaineConnexion = ""; }
  public G_Base(string ChaineConnexion_)
  { ChaineConnexion = ChaineConnexion_; }
  public string ChaineConnexion
  {
   get { return _ChaineConnexion; }
   set { _ChaineConnexion = value; }
  }
 }
}
