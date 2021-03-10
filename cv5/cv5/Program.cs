using System;

namespace cv5
{
    class Program
    {
        static void Main(string[] args)
        {
            
                                                //TypPaliva /double stavNadrze/[int prepravovanyNaklad=0]
            Nakladni nakladniAuto = new Nakladni(Auto.TypPaliva.BENZIN,4,1);
                                            //TypPaliva /double stavNadrze/[int prepravovaneOsoby=0]
            Osobni osobniAuto = new Osobni(Auto.TypPaliva.BENZIN,5,2);
            
            //chybne tankovani
                                //typ, double mnozstvi
            osobniAuto.Natankuj(Auto.TypPaliva.NAFTA,40.5);
            //ted uz spravne
            osobniAuto.Natankuj(Auto.TypPaliva.BENZIN, 40.5);

            //radio
                //chybne
            osobniAuto.ZapnoutRadio(false);
            osobniAuto.NastavPredvolbu(1,95.8);
                //spravne
            osobniAuto.ZapnoutRadio(true);
            osobniAuto.NastavPredvolbu(1,89.5);//country radio FM Praha 89,5 MHz
            osobniAuto.PreladNaPredvolbu(1);
            osobniAuto.RadioToString();          

            // vypisy
            Console.WriteLine(nakladniAuto);
            Console.WriteLine(osobniAuto);
            
        }
    }
}
