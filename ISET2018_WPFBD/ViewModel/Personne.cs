using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISET2018_WPFBD.Model;
using System.Collections.ObjectModel;

namespace ISET2018_WPFBD.ViewModel
{
 public class VM_Personne : BasePropriete
 {
  #region Données Écran
  private string chConnexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + System.Windows.Forms.Application.StartupPath + @"\BD_Exemple.mdf';Integrated Security=True;Connect Timeout=30";
  private int nAjout;
  private bool _ActiverUneFiche;
  public bool ActiverUneFiche
  {
   get { return _ActiverUneFiche; }
   set
   {
    AssignerChamp<bool>(ref _ActiverUneFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
    ActiverBcpFiche = !ActiverUneFiche;
   }
  }
  private bool _ActiverBcpFiche;
  public bool ActiverBcpFiche
  {
   get { return _ActiverBcpFiche; }
   set { AssignerChamp<bool>(ref _ActiverBcpFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
  }
  private C_Personne _PersonneSelectionnee;
  public C_Personne PersonneSelectionnee
  {
   get { return _PersonneSelectionnee; }
   set { AssignerChamp<C_Personne>(ref _PersonneSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
  }
  #endregion
  #region Données extérieures
  private VM_UnePersonne _UnePersonne;
  public VM_UnePersonne UnePersonne
  {
   get { return _UnePersonne; }
   set { AssignerChamp<VM_UnePersonne>(ref _UnePersonne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
  }
  private ObservableCollection<C_Personne> _BcpPersonnes = new ObservableCollection<C_Personne>();
  public ObservableCollection<C_Personne> BcpPersonnes
  {
   get { return _BcpPersonnes; }
   set { _BcpPersonnes = value; }
  }
  #endregion
  #region Commandes
  public BaseCommande cConfirmer { get; set; }
  public BaseCommande cAnnuler { get; set; }
  public BaseCommande cAjouter { get; set; }
  public BaseCommande cModifier { get; set; }
  public BaseCommande cSupprimer { get; set; }
  #endregion
  public VM_Personne()
  {
   UnePersonne = new VM_UnePersonne();
   UnePersonne.ID = 24;
   UnePersonne.Pre = "Largo";
   UnePersonne.Nom = "Winch";
   UnePersonne.Nai = DateTime.Today;
   BcpPersonnes = ChargerPersonnes(chConnexion);
   ActiverUneFiche = false;
   cConfirmer = new BaseCommande(Confirmer);
   cAnnuler = new BaseCommande(Annuler);
   cAjouter = new BaseCommande(Ajouter);
   cModifier = new BaseCommande(Modifier);
   cSupprimer = new BaseCommande(Supprimer);
  }
  private ObservableCollection<C_Personne> ChargerPersonnes(string chConn)
  {
   ObservableCollection<C_Personne> rep = new ObservableCollection<C_Personne>();
   List<C_Personne> lTmp = new Model.G_Personne(chConn).LirePersonne();
   foreach (C_Personne Tmp in lTmp)
    rep.Add(Tmp);
   return rep;
  }
  public void Confirmer()
  {
   if (nAjout == -1)
   {
    UnePersonne.ID = new Model.G_Personne(chConnexion).AjouterPersonne(UnePersonne.Nom, UnePersonne.Pre, UnePersonne.Nai);
    BcpPersonnes.Add(new C_Personne(UnePersonne.ID, UnePersonne.Nom, UnePersonne.Pre, UnePersonne.Nai));
   }
   else
   {
    new Model.G_Personne(chConnexion).ModifierPersonne(UnePersonne.ID, UnePersonne.Nom, UnePersonne.Pre, UnePersonne.Nai);
    BcpPersonnes[nAjout] = new C_Personne(UnePersonne.ID, UnePersonne.Nom, UnePersonne.Pre, UnePersonne.Nai);
   }
   ActiverUneFiche = false;
  }
  public void Annuler()
  { ActiverUneFiche = false; }
  public void Ajouter()
  {
   UnePersonne = new VM_UnePersonne();
   nAjout = -1;
   ActiverUneFiche = true;
  }
  public void Modifier()
  {
   if (PersonneSelectionnee != null)
   {
    C_Personne Tmp = new Model.G_Personne(chConnexion).LirePersonne_ID(PersonneSelectionnee.ID);
    UnePersonne = new VM_UnePersonne();
    UnePersonne.ID = Tmp.ID;
    UnePersonne.Pre = Tmp.Pre;
    UnePersonne.Nom = Tmp.Nom;
    UnePersonne.Nai = Tmp.Nai;
    nAjout = BcpPersonnes.IndexOf(PersonneSelectionnee);
    ActiverUneFiche = true;
   }
  }
  public void Supprimer()
  {
   if (PersonneSelectionnee != null)
   {
    new Model.G_Personne(chConnexion).SupprimerPersonne(PersonneSelectionnee.ID);
    BcpPersonnes.Remove(PersonneSelectionnee);
   }
  }
  public void PersonneSelectionnee2UnePersonne()
  {
   UnePersonne.ID = PersonneSelectionnee.ID;
   UnePersonne.Nom = PersonneSelectionnee.Nom;
   UnePersonne.Pre = PersonneSelectionnee.Pre;
   UnePersonne.Nai = PersonneSelectionnee.Nai;
  }
 }
 public class VM_UnePersonne : BasePropriete
 {
  private int _ID;
  private string _Nom, _Pre;
  private DateTime _Nai;
  public int ID
  {
   get { return _ID; }
   set { AssignerChamp<int>(ref _ID, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
  }
  public string Pre
  {
   get { return _Pre; }
   set { AssignerChamp<string>(ref _Pre, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
  }
  public string Nom
  {
   get { return _Nom; }
   set { AssignerChamp<string>(ref _Nom, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
  }
  public DateTime Nai
  {
   get { return _Nai; }
   set { AssignerChamp<DateTime>(ref _Nai, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
  }
 }
}
