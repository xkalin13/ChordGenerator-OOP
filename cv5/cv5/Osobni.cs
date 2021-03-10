using System;
using System.Collections.Generic;
using System.Text;

namespace cv5
{
    class Osobni : Auto
    {
        public int MaxOsob { get; private set; }
        private int PrepravovaneOsoby { get; set; }
 

        public Osobni( TypPaliva palivo, double stavNadrze, int prepravovaneOsoby = 0) : base(palivo,stavNadrze)
        {
            //vola base ->Auto

            this.MaxOsob = 5; // na pevno nastavene od vyroby
            this.VelikostNadrze = 50; // kolem 50 litru by auto mit mohlo

            if (MaxOsob >= prepravovaneOsoby)//osetreni kdyby si chtel prisednout i soused bez rousky
            {
                this.PrepravovaneOsoby = prepravovaneOsoby;
            }
            else {
                throw new Exception("Do auta se vleze "+this.MaxOsob+" osob, ne"+prepravovaneOsoby);
            }
            

        }
        public override string ToString()
        {
            return "MaxOsob: "+MaxOsob+" a prepravovane: "+PrepravovaneOsoby;
        }

    }
}
