using CortadorDeGrama.ambiente;
using CortadorDeGrama.geral;
using System;
using System.Collections.Generic;
using System.Text;

namespace CortadorDeGrama.agente
{

    public class AgenteLaberinto
    {
        public Labirinto laberinto { get; set; }

        private MovimentoAgenteLaberinto movimento;
        public PosisaoXY posXY { get; set; }
        private int pilhaMovimento;

        internal bool isAindaLimpeza()
        {
            return pilhaMovimento < 4;
        }

        public AgenteLaberinto(Labirinto laberinto)
        {
            this.laberinto = laberinto;
            laberinto.Agente = this;
            this.posXY = new PosisaoXY();

            this.movimento = MovimentoAgenteLaberinto.CIMA;
        }

        public void movimentar()
        {
            PosisaoXY proximoMovimento = retornarMovimento();

            String valor = this.laberinto.retornarValorPosicaoLaberinto(proximoMovimento);
            if (valor.Equals("L") || valor.Equals("*A*"))
            {
                this.pilhaMovimento++;
                this.proximoMovimento();
                if (this.pilhaMovimento < 4)
                {
                    movimentar();
                }
            }
            else
            {
                this.pilhaMovimento = 0;
                this.laberinto.Limpar();
                this.posXY = proximoMovimento;
            }

        }

        private void proximoMovimento()
        {
            switch (this.movimento)
            {
                case MovimentoAgenteLaberinto.CIMA:
                    this.movimento = MovimentoAgenteLaberinto.BAIXO;
                    break;
                case MovimentoAgenteLaberinto.BAIXO:
                    this.movimento = MovimentoAgenteLaberinto.ESQUERDA;
                    break;
                case MovimentoAgenteLaberinto.ESQUERDA:
                    this.movimento = MovimentoAgenteLaberinto.DIEREITA;
                    break;
                case MovimentoAgenteLaberinto.DIEREITA:
                    this.movimento = MovimentoAgenteLaberinto.CIMA;
                    break;
            }
        }

        public PosisaoXY retornarMovimento()
        {
            int retornaPosX = this.posXY.posX;
            int retornaPosY = this.posXY.posY;

            switch (this.movimento)
            {
                case MovimentoAgenteLaberinto.CIMA:
                    if (retornaPosX > 0)
                    {
                        retornaPosX -= 1;
                    }
                    break;
                case MovimentoAgenteLaberinto.BAIXO:
                    if (retornaPosX < this.laberinto.Tamanho - 1)
                    {
                        retornaPosX += 1;
                    }
                    break;
                case MovimentoAgenteLaberinto.ESQUERDA:
                    if (retornaPosY > 0)
                    {
                        retornaPosY -= 1;
                    }
                    break;
                case MovimentoAgenteLaberinto.DIEREITA:
                    if (retornaPosY < this.laberinto.Tamanho - 1)
                    {
                        retornaPosY += 1;
                    }
                    break;
            }

            return new PosisaoXY(retornaPosX, retornaPosY);

        }
    }
}
