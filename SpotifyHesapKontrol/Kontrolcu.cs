using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyHesapKontrol
{
    internal class Kontrolcu
    {
        public List<Hesap> Hesaplar { get; private set; } = HesapYonetim.Hesaplar;

        public int MaxIs { get; private set; } = 1;

        public AnaForm Form { get; private set; }

        public Kontrolcu(int MaxIs, AnaForm Form)
        {
            this.MaxIs = MaxIs;
            this.Form = Form;
        }

        public void Start()
        {
            Parallel.ForEach(
                Hesaplar,
                new ParallelOptions() { MaxDegreeOfParallelism = MaxIs },
                _Hesap =>
                {
                    try
                    {
                        if (new HttpManager(_Hesap).CheckAccount())
                        {
                            Form.HesapGridGuncelle(_Hesap);
                        }
                    }
                    catch { }
                });
        }
    }
}