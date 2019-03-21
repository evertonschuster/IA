using CarteiroFormiga.Entidades;
using CarteiroFormiga.Iteracaoes;
using System;

namespace CarteiroFormiga
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.Inicializa();
        }

        private void Inicializa()
        {
            Cidade cidadeA = new Cidade("A");
            Cidade cidadeB = new Cidade("B");
            Cidade cidadeC = new Cidade("C");
            Cidade cidadeD = new Cidade("D");
            Cidade cidadeE = new Cidade("E");
            

            //Cidade A
            new Rota(cidadeA, cidadeB, 22);
            new Rota(cidadeA, cidadeC, 50);
            new Rota(cidadeA, cidadeD, 48);
            new Rota(cidadeA, cidadeE, 29);

            //Cidade B
            new Rota(cidadeB, cidadeA, 50);
            new Rota(cidadeB, cidadeC, 30);
            new Rota(cidadeB, cidadeD, 22);
            new Rota(cidadeB, cidadeE, 23);

            //Cidade C
            new Rota(cidadeC, cidadeA, 22);
            new Rota(cidadeC, cidadeB, 30);
            new Rota(cidadeC, cidadeD, 34);
            new Rota(cidadeC, cidadeE, 32);


            //Cidade D
            new Rota(cidadeD, cidadeA, 48);
            new Rota(cidadeD, cidadeB, 34);
            new Rota(cidadeD, cidadeC, 22);
            new Rota(cidadeD, cidadeE, 35);

            //Cidade E
            new Rota(cidadeE,cidadeA, 29);
            new Rota(cidadeE,cidadeB, 32);
            new Rota(cidadeE,cidadeC, 23);
            new Rota(cidadeE,cidadeD, 35);

            var formiga = new Caminhar(10);
            formiga.GerarIteracao();

            Console.ReadKey();

        }
    }
}
