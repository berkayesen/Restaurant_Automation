using System;
using System.Data.SqlClient;
using System.Data;

namespace Restoran
{
    class cPersonelHareketleri
    {
        cGenel gnl = new cGenel();

        #region FIELD
        private int _ID;
        private int _Personel_ID;
        private string _Islem;
        private DateTime _Tarih;
        private bool _Durum;
        #endregion

        #region PROPERTIES
        public int ID { get => _ID; set => _ID = value; }
        public int Personel_ID { get => _Personel_ID; set => _Personel_ID = value; }
        public string Islem { get => _Islem; set => _Islem = value; }
        public DateTime Tarih { get => _Tarih; set => _Tarih = value; }
        public bool Durum { get => _Durum; set => _Durum = value; } 
        #endregion

        public bool personelActionSave(cPersonelHareketleri ph)

        { 
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert into Personel_Hareketleri(PERSONEL_ID,ISLEM,TARIH)Values(@personelID,@islem,@tarih)",con);

            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@personelID", SqlDbType.Int).Value = ph.Personel_ID;
                cmd.Parameters.Add("@islem", SqlDbType.VarChar).Value = ph._Islem;
                cmd.Parameters.Add("@tarih", SqlDbType.DateTime).Value = ph._Tarih;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }

            catch(SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            return result;
        }
    }
}
