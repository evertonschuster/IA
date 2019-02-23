using CortadorDeGrama.agente;
using CortadorDeGrama.geral;
using System;
using System.Collections.Generic;
using System.Text;

namespace CortadorDeGrama.ambiente
{
    public class Labirinto
    {
        private int tamanho = 3;

        public AgenteLaberinto Agente { get; internal set; }

        private String[][] labirinto = null;

        public int Tamanho
        {
            get
            {
                return tamanho;
            }

        }

        public Labirinto(int tamanho)
        {
            this.tamanho = tamanho;
            construirLabirinto();
        }


        private void construirLabirinto()
        {
            //Valores
            //--------------
            // S - Sujo
            // L - Limpo
            // A - Agente

            this.labirinto = new String[this.tamanho][];
            //Construtor do labirinto
            for (int j = 0; j < this.labirinto.Length; j++)
            {
                var item = this.labirinto[j] = new string[tamanho];
                for (int i = 0; i < item.Length; i++)
                {
                    item[i] = "S";
                }
            }

        }

        internal void Limpar()
        {
            PosisaoXY posicao = this.Agente.posXY;
            labirinto[posicao.posX][posicao.posY] = "L";

        }

        public void exibirLabirinto()
        {
            this.atualizarPosicaoAgente();
            foreach (var item in this.labirinto)
            {
                foreach (var campo in item)
                {
                    Console.Write(campo + " ");
                }
                Console.Write("\n");
            }

        }

        private void atualizarPosicaoAgente()
        {

            if (this.Agente != null)
            {
                PosisaoXY posisaoAgente = this.Agente.posXY;

                labirinto[posisaoAgente.posX][posisaoAgente.posY] = "*A*";
            }
        }

        public string retornarValorPosicaoLaberinto(PosisaoXY posisaoXY)
        {
            return this.labirinto[posisaoXY.posX][posisaoXY.posY];
        }
    }
}
