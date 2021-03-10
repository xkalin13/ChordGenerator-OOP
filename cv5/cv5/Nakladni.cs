using System;
using System.Collections.Generic;
using System.Text;

namespace cv5
{
    class Nakladni : Auto
    {
        public int MaxNaklad { get; private set; }
        private int PrepravovanyNaklad{ get; set; }

        public Nakladni(TypPaliva palivo, double stavNadrze, int prepravovanyNaklad = 0) : base(palivo, stavNadrze){
            //base vychozi-neco jako super v jave

           
            this.MaxNaklad = 200; //to by se nemelo menit, nastavim jej zde
            this.VelikostNadrze = 400; //to by se taky nemelo menit

            if (this.MaxNaklad >= prepravovanyNaklad)//osetreni vyssiho zadani
            {
                this.PrepravovanyNaklad = prepravovanyNaklad;
            }
            else {
                throw new Exception("Do nakladaku se naklad " + MaxNaklad + "  nikoliv " + PrepravovanyNaklad);
            }
            

        }
        public override string ToString()
        {
            return "MaxNaklad: " + MaxNaklad + " a prepravovany: " + PrepravovanyNaklad;
        }
    }
}
