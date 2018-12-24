using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISET2018_WPFBD.Model
{
 public class G_Personne : G_Base
 {
  public G_Personne()
   : base()
  { }
  public G_Personne(string chConn)
   : base(chConn)
  { }
  public int AjouterPersonne(string Nom_, string Pre_, DateTime Nai_)
  { return new A_Personne(ChaineConnexion).AjouterPersonne(Nom_, Pre_, Nai_); }
  public int ModifierPersonne(int NumCli_, string Nom_, string Pre_, DateTime Nai_)
  { return new A_Personne(ChaineConnexion).ModifierPersonne(NumCli_, Nom_, Pre_, Nai_); }
  public int SupprimerPersonne(int NumCli_)
  { return new A_Personne(ChaineConnexion).SupprimerPersonne(NumCli_); }
  public List<C_Personne> LirePersonne()
  { return new A_Personne(ChaineConnexion).LirePersonne(); }
  public C_Personne LirePersonne_ID(int NumCli_)
  { return new A_Personne(ChaineConnexion).LirePersonne_ID(NumCli_); }
 }
}
