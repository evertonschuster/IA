using CortadorDeGrama.agente;
using CortadorDeGrama.ambiente;
using System;
using System.Threading;

namespace CortadorDeGrama
{
    class Program
    {

        static void Main(string[] args)
        {
            var laberinto = new Labirinto(3);

            laberinto.exibirLabirinto();

            AgenteLaberinto agente = new AgenteLaberinto(laberinto);

            while (agente.isAindaLimpeza())
            {
                agente.movimentar();
                laberinto.exibirLabirinto();

                Thread.Sleep(1500);
            }
            return;

            Console.ReadKey();
        }
    }
}
