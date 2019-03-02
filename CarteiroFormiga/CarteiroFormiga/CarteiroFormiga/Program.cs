using CarteiroFormiga.Entidades;
using System;

namespace CarteiroFormiga
{
    class Program
    { 
        static void Main(string[] args)
        {
            var p = new Program();
        }

        private void Inicializa()
        {
            Cidade cidadeA = new Cidade("A");
            Cidade cidadeB = new Cidade("B");
            Cidade cidadeC = new Cidade("C");
            Cidade cidadeD = new Cidade("D");
            Cidade cidadeE = new Cidade("E");


            //Cidade A
            cidadeA.AddRota(new Rota(cidadeB, 22));
            cidadeA.AddRota(new Rota(cidadeC, 50));
            cidadeA.AddRota(new Rota(cidadeD, 48));
            cidadeA.AddRota(new Rota(cidadeE, 29));

            //Cidade B
            cidadeB.AddRota(new Rota(cidadeA, 22));
            cidadeB.AddRota(new Rota(cidadeC, 30));
            cidadeB.AddRota(new Rota(cidadeD, 34));
            cidadeB.AddRota(new Rota(cidadeE, 32));

            //Cidade C
            cidadeC.AddRota(new Rota(cidadeA, 50));
            cidadeC.AddRota(new Rota(cidadeB, 30));
            cidadeC.AddRota(new Rota(cidadeD, 22));
            cidadeC.AddRota(new Rota(cidadeE, 23));

            //Cidade D
            cidadeD.AddRota(new Rota(cidadeA, 48));
            cidadeD.AddRota(new Rota(cidadeB, 34));
            cidadeD.AddRota(new Rota(cidadeC, 22));
            cidadeD.AddRota(new Rota(cidadeE, 35));

            //Cidade E
            cidadeE.AddRota(new Rota(cidadeA, 29));
            cidadeE.AddRota(new Rota(cidadeB, 32));
            cidadeE.AddRota(new Rota(cidadeC, 23));
            cidadeE.AddRota(new Rota(cidadeD, 35));
        }

    }
}
