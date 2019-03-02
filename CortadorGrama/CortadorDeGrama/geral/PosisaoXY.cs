using System;
using System.Collections.Generic;
using System.Text;

namespace CortadorDeGrama.geral
{
    public class PosisaoXY
    {
        public PosisaoXY()
        {
            this.posX = 0;
            this.posY = 0;
        }

        public PosisaoXY(int retornaPosX, int retornaPosY)
        {
            this.posX = retornaPosX;
            this.posY = retornaPosY;
        }

        public int posX { get; set; }
        public int posY { get; set; }
    }
}
