
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL;
using OkulApp.MODEL;

namespace OkulApp.BLL
{
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
