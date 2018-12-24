using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISET2018_WPFBD.Model
{
 public class C_Personne
 {
  private int _ID;
  private string _Nom, _Pre;
  private DateTime _Nai;
  public C_Personne()
  { }
  public C_Personne(string Nom_, string Pre_, DateTime Nai_)
  {
   Nom = Nom_;
   Pre = Pre_;
   Nai = Nai_;
  }
  public C_Personne(int ID_, string Nom_, string Pre_, DateTime Nai_)
    : this(Nom_, Pre_, Nai_)
   { ID = ID_; }
  public int ID
  {
   get { return _ID; }
   set { _ID = value; }
  }
  public string Nom
  {
   get { return _Nom; }
   set { _Nom = value; }
  }
  public string Pre
  {
   get { return _Pre; }
   set { _Pre = value; }
  }
  public DateTime Nai
  {
   get { return _Nai; }
   set { _Nai = value; }
  }
 }
}