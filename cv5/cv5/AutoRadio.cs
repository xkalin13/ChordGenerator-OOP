using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cv5
{
    class AutoRadio
    {
        private double NaladenyKmitocet;
        private bool RadioZapnuto = false;//kdyz sedam do auta,taky je vypnute
        private Dictionary<int, double> Predvolby = new Dictionary<int, double> { { 0, 2.5 } };

        public void NastavPredvolbu(int cislo, double kmitocet) {
            if (this.RadioZapnuto)
            {
                if (!Predvolby.ContainsKey(cislo))
                {
                    Predvolby.Add(cislo, kmitocet);
                }
                else {
                    throw new Exception("Zaplnena pamet na cisle"+cislo+"zkuste jine");
                }
            }
            else {
                throw new Exception("No tak nejdriv si to radio musime zapnout");
            }
                

        }
        public void ZapnoutRadio(bool radioZapnuto)
        {
            this.RadioZapnuto=radioZapnuto;
        }
        public void PreladNaPredvolbu(int cislo)
        {
            if (this.RadioZapnuto)
            {
                if (Predvolby.ContainsKey(cislo))
                {
                    this.NaladenyKmitocet = Predvolby[cislo];
                }
                else
                {
                    throw new Exception("Zadna stanice");
                }
            }
            else
            {
                throw new Exception("No tak nejdriv si to radio musime zapnout");
            }

               
        }
        public override string ToString()
        {
            string str;

            if (RadioZapnuto) {
                str = "Radio je zapnuto a na stanici: "+NaladenyKmitocet+" coz je stanice "+ Predvolby.FirstOrDefault(x => x.Value == NaladenyKmitocet).Key; ;
            }
            else {
                str = "Radio je vypnuto";
            }

            return str;
        }

    }
}
