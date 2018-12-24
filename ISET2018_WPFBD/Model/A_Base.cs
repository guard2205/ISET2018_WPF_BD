﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ISET2018_WPFBD.Model
{
 public class A_Base
 {
  protected SqlCommand _Commande;
  public A_Base()
  { }
  public A_Base(string chConn)
  {
   _Commande = new SqlCommand();
   _Commande.Connection = new SqlConnection(chConn);
   _Commande.CommandType = CommandType.StoredProcedure;
  }
  public A_Base(string chConn, string sComm)
   : this(chConn)
  {
   _Commande.CommandText = sComm;
  }
 }
}
