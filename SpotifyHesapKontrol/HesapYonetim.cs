using System.Collections.Generic;
using System.IO;

namespace SpotifyHesapKontrol
{
    internal class HesapYonetim
    {
        public static List<Hesap> Hesaplar { get; private set; } = new List<Hesap>();

        public static bool HesapYukle(string Path)
        {
            if (Hesaplar.Count > 0) Hesaplar.Clear();

            foreach (string Line in File.ReadLines(Path))
            {
                try
                {
                    string[] GetAccountInfo = Line.Split(':');
                    Hesaplar.Add(new Hesap { KulAdi = GetAccountInfo[0], Sifre = GetAccountInfo[1] });
                }
                catch { continue; }
            }

            return (Hesaplar.Count > 0);
        }
    }
}