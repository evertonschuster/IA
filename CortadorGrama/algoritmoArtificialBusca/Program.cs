using algoritmoArtificialBusca.nos;
using System;
using System.Collections.Generic;

namespace algoritmoArtificialBusca
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.carregarFILO();
        }

        public void carregarFILO()
        {
            Stack<int> pilha = new Stack<int>();
            pilha.Push(1);
            pilha.Push(2);
            pilha.Push(3);
            pilha.Push(4);
            pilha.Push(5);

            int valor = pilha.Pop();


        }
        
        public void carregarFIFO()
        {
            Queue<int> fila = new Queue<int>();

            fila.Enqueue(1);
            fila.Enqueue(2);
            fila.Enqueue(3);
            fila.Enqueue(4);
            fila.Enqueue(5);
            fila.Enqueue(6);
            fila.Enqueue(7);

            int valor = fila.Dequeue();
            int valor2 = fila.Dequeue();

        }
            

        public void carregaArvore()
        {
            NO no0 = new NO(0);
            NO no1 = new NO(1);
            NO no2 = new NO(2);
            NO no3 = new NO(3);
            NO no4 = new NO(4);
            NO no5 = new NO(5);
            NO no6 = new NO(6);
            NO no7 = new NO(7);
            NO no8 = new NO(8);

            //no.noEsquerda = no;
            //no.noDireita = no;

            no0.noEsquerda = no1;
            no0.noDireita = no2;

            no1.noEsquerda = no3;
            no1.noDireita = no4;

            no2.noEsquerda = no5;
            no2.noDireita = no6;
        }
    }
}
