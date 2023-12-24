using System;

namespace OkulApp.MODEL
{
    public class Ogrenci
    {
        public int Ogrenciid { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Numara { get; set; }
    }

    public class Ogretmen
    {
        public long TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
      
    }
}
