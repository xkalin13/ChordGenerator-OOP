using System;
using System.Collections.Generic;
using System.Text;

namespace cv5
{
    class Auto
    {
        public enum TypPaliva
        {
            BENZIN,
            NAFTA
        }

        //protected kvuli odvozenym tridam
        public double VelikostNadrze { get; protected set; }
        public double StavNadrze { get; protected set; }
        public TypPaliva Palivo { get; protected set; }

        private AutoRadio Radio = new AutoRadio();

        public Auto(TypPaliva palivo, double stavNadrze) {//nemuze mit velikost nadrze-je specificka
            this.Palivo = palivo;
            this.StavNadrze = stavNadrze;        
        }
        public void Natankuj(TypPaliva tankovanePalivo, double mnozstvi) {

            if (tankovanePalivo != this.Palivo ) {//enum
                throw new Exception("spatne palivo");
            }
            else {
                if (StavNadrze + mnozstvi < VelikostNadrze)
                {
                    StavNadrze += mnozstvi;
                }
                else {
                    throw new Exception("jejda nadrz pretekla, to bude penez");
                }
                
            }
            
        }
        public void ZapnoutRadio(bool radioZapnuto)
        {
            Radio.ZapnoutRadio(radioZapnuto);
        }
        public void NastavPredvolbu(int cislo, double kmitocet)
        {
            Radio.NastavPredvolbu(cislo, kmitocet);
        }
        public void PreladNaPredvolbu(int cislo)
        {
            Radio.PreladNaPredvolbu(cislo);
        }
        public void RadioToString()
        {
            Console.WriteLine(Radio);
        }

    }
}
