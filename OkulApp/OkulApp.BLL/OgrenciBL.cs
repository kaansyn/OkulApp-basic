using System;
using System.Data.SqlClient;
using DAL;
using OkulApp.MODEL;

namespace OkulApp.BLL
{
    public class OgrenciBL
    {
        public bool OgrenciEkle(Ogrenci ogr)
        {
            SqlParameter[] p = {
                             new SqlParameter("@Ad",ogr.Ad),
                             new SqlParameter("@Soyad",ogr.Soyad),
                             new SqlParameter("@Numara",ogr.Numara)
                         };

            Helper hlp = new Helper();
            return hlp.ExecuteNonQuery("Insert into tblOgrenciler values(@Ad, @Soyad, @Numara)", p) > 0;

        }

        public class OgretmenBL
        {
            public bool OgretmenEkle(Ogretmen ogretmen)
            {
                SqlParameter[] p = {
                            new SqlParameter("@TC", ogretmen.TC),
                            new SqlParameter("@Ad", ogretmen.Ad),
                            new SqlParameter("@Soyad", ogretmen.Soyad),                          
                };

                Helper hlp = new Helper();
                return hlp.ExecuteNonQuery("Insert into tblOgretmenler values(@TC, @Ad, @Soyad)", p) > 0;
            }
        }
    }
}
