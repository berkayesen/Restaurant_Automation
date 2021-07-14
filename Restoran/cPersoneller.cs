using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Restoran
{
    class cPersoneller
    {
        cGenel gnl = new cGenel();

        #region Field
        private int _Personel_ID;
        private int _Personel_Gorev_ID;
        private string _Personel_Ad;
        private string _Personel_Soyad;
        private string _Personel_Parola;
        private string _Personel_Kullanici_Adi;
        private bool _Personel_Durum;
        #endregion

        #region Properties

        public int Personel_ID { get => _Personel_ID; set => _Personel_ID = value; }
        public int Personel_Gorev_ID { get => _Personel_Gorev_ID; set => _Personel_Gorev_ID = value; }
        public string Personel_Ad { get => _Personel_Ad; set => _Personel_Ad = value; }
        public string Personel_Soyad { get => _Personel_Soyad; set => _Personel_Soyad = value; }
        public string Personel_Parola { get => _Personel_Parola; set => _Personel_Parola = value; }
        public string Personel_Kullanici_Adi { get => _Personel_Kullanici_Adi; set => _Personel_Kullanici_Adi = value; }
        public bool Personel_Durum { get => _Personel_Durum; set => _Personel_Durum = value; } 
        #endregion 

        public bool personelEntryControl(string password,int Userid)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Personeller where ID=@ID and PAROLA=@password", con);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Userid;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            
            return result;
        }
        public void personelGetByInformation(ComboBox cb)
        {
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Personeller", con);
           
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) 
            {
                cPersoneller p = new cPersoneller();
                p._Personel_ID = Convert.ToInt32(dr["ID"]);
                p._Personel_Gorev_ID = Convert.ToInt32(dr["GOREV_ID"]);
                p._Personel_Ad = Convert.ToString(dr["AD"]);
                p._Personel_Soyad = Convert.ToString(dr["SOYAD"]);
                p._Personel_Parola = Convert.ToString(dr["PAROLA"]);
                p._Personel_Kullanici_Adi = Convert.ToString(dr["KULLANICI_ADI"]);
                p._Personel_Durum = Convert.ToBoolean(dr["DURUM"]);
                cb.Items.Add(p);
            }
            dr.Close();
            con.Close();
            

        }

        public override string ToString()
        {
            return Personel_Ad+" "+Personel_Soyad;
        }
    }
}
