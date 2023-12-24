using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OkulApp.BLL;
using OkulApp.MODEL;
using static OkulApp.BLL.OgrenciBL;

namespace OkulAppSube1BIL
{
    public partial class frmOgrKayit : Form
    {
        public frmOgrKayit()
        {
            InitializeComponent();
        }
        private bool sayisalMi(string input)
        {
            return long.TryParse(input, out _);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            try
            {
                var obl = new OgrenciBL();

                if (!sayisalMi(txtNumara.Text))
                {
                    MessageBox.Show("Öğrenci numarasıalanına lütfen nümerik bir ifade giriniz!");
                    return; // TC geçerli bir sayı değilse işlemi sonlandır
                }
                bool sonuc = obl.OgrenciEkle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim() });
                MessageBox.Show(sonuc ? "Ekleme Başarılı!" : "Ekleme Başarısız!!");
            }
            catch (SqlException ex)
            {


                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numaralı öğrenci daha önce kayıtlı");
                        break;
                    default:
                      MessageBox.Show("Veritabanı hatası" + ex.Number + " *****************" + "\n\n" + ex.Message + " *****************" + "\n\n" + ex.StackTrace);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası" + " *****************" + "\n\n" + ex.Message + " *****************" + "\n\n" + ex.StackTrace);
            }
        }


        private void btnKaydetOgt_Click(object sender, EventArgs e)
        {
            try
            {
                var ogretmenBL = new OgretmenBL();

                
                if (!sayisalMi(txtTC.Text))
                {
                    MessageBox.Show("TC alanına lütfen nümerik bir ifade giriniz!");
                    return; 
                }

                bool sonuc = ogretmenBL.OgretmenEkle(new Ogretmen { Ad = txtAdOgt.Text.Trim(), Soyad = txtSoyadOgt.Text.Trim(), TC = long.Parse(txtTC.Text.Trim()) });
                MessageBox.Show(sonuc ? "Ekleme Başarılı!" : "Ekleme Başarısız!!");

            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numaralı öğretmen daha önce kayıtlı");
                        break;
                    default:
                        MessageBox.Show("Veritabanı hatası" + "\n\n" + ex.Number + " *****************" + "\n\n" +  ex.Message + " *****************" + "\n\n" + ex.StackTrace);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası" + " *****************" + "\n\n" + ex.Message + " *****************" + "\n\n" + ex.StackTrace);
            }
        }
    }

    //interface ITransfer
    //{
    //    int Eft(string gondericiiban, string aliciiban, double tutar);
    //    int Havale(string gondericiiban, string aliciiban, double tutar);

    //}

    //class Transfer : ITransfer
    //{
    //    public int Eft(string gondericiiban, string aliciiban, double tutar)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int Havale(string gondericiiban, string aliciiban, double tutar)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    //
    //}
}
