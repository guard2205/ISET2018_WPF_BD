using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ISET2018_WPFBD.Model
{
 public class A_Personne : A_Base
 {
  public A_Personne()
  { }
  public A_Personne(string chConn)
   : base(chConn)
  { }
  public int AjouterPersonne(string Nom_, string Pre_, DateTime Nai_)
  {
   _Commande.CommandText = "AjouterPersonne";
   int res = -1;
   _Commande.Parameters.Add("@ID", SqlDbType.Int);
   _Commande.Parameters["@ID"].Direction = ParameterDirection.Output;
   _Commande.Parameters.AddWithValue("@NOM", Nom_);
   _Commande.Parameters.AddWithValue("@PRE", Pre_);
   _Commande.Parameters.AddWithValue("@NAI", Nai_);
   _Commande.Connection.Open();
   _Commande.ExecuteNonQuery();
   res = (int)_Commande.Parameters["@ID"].Value;
   _Commande.Connection.Close();
   return res;
  }
  public int ModifierPersonne(int ID_, string Nom_, string Pre_, DateTime Nai_)
  {
   _Commande.CommandText = "ModifierPersonne";
   int res = -1;
   _Commande.Parameters.AddWithValue("@ID", ID_);
   _Commande.Parameters.AddWithValue("@NOM", Nom_);
   _Commande.Parameters.AddWithValue("@PRE", Pre_);
   _Commande.Parameters.AddWithValue("@NAI", Nai_);
   _Commande.Connection.Open();
   res = _Commande.ExecuteNonQuery();
   _Commande.Connection.Close();
   return res;
  }
  public int SupprimerPersonne(int ID_)
  {
   _Commande.CommandText = "SupprimerPersonne";
   int res = -1;
   _Commande.Parameters.AddWithValue("@ID", ID_);
   _Commande.Connection.Open();
   res = _Commande.ExecuteNonQuery();
   _Commande.Connection.Close();
   return res;
  }
  public List<C_Personne> LirePersonne()
  {
   List<C_Personne> res = new List<C_Personne>();
   _Commande.CommandText = "SelectionnerPersonne";
   _Commande.Parameters.AddWithValue("@Index", "ID");
   _Commande.Connection.Open();
   SqlDataReader dr = _Commande.ExecuteReader();
   while (dr.Read())
    res.Add(new C_Personne(int.Parse(dr["ID"].ToString())
     , dr["NOM"].ToString(), dr["PRE"].ToString()
     , DateTime.Parse(dr["NAI"].ToString())));
   dr.Close();
   _Commande.Connection.Close();
   return res;
  }
  public C_Personne LirePersonne_ID(int ID_)
  {
   _Commande.CommandText = "SelectionnerPersonne_ID";
   _Commande.Parameters.AddWithValue("@ID", ID_);
   _Commande.Connection.Open();
   SqlDataReader dr = _Commande.ExecuteReader();
   dr.Read();
   C_Personne res = new C_Personne(int.Parse(dr["ID"].ToString())
     , dr["NOM"].ToString(), dr["PRE"].ToString()
     , DateTime.Parse(dr["NAI"].ToString()));
   dr.Close();
   _Commande.Connection.Close();
   return res;
  }
 }
}
