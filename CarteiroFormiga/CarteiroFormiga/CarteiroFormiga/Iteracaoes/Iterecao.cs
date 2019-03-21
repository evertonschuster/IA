using CarteiroFormiga.Entidades;
using CarteiroFormiga.Uteis.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarteiroFormiga.Iteracaoes
{
    class Iterecao
    {
        public Cidade CidadeX { get; set; }
        public Cidade CidadeY { get; set; }

        private Double Distancia
        {
            get
            {
                return Rota.GetRota(CidadeX, CidadeY).Distancia;
            }
        }

        private Double TalXY => 1 / this.Distancia;

        private Double GetFeromonio => Rota.GetRota(this.CidadeX, this.CidadeY).Feromonio;

        private Double TalXYEtaXY => this.TalXY * this.GetFeromonio;

        public Double Probabilidade
        {
            get
            {
                var i = new Iterecao();
                Double somaTalXYEtaXY = 0;
                foreach (var item in Rota.GetRota(this.CidadeX))
                {
                    //item.CidadeA.Id != cidadeOrigem.Id && item.CidadeB.Id != cidadeOrigem.Id
                    if (!item.CidadeA.IsVisitado && !item.CidadeB.IsVisitado)
                    {
                        Cidade destino;
                        if (this.CidadeX.Id == item.CidadeA.Id)
                        {
                            destino = item.CidadeB;
                        }
                        else
                        {
                            destino = item.CidadeA;
                        }
                        i.CidadeX = this.CidadeX;
                        i.CidadeY = destino;
                        somaTalXYEtaXY += i.TalXYEtaXY;
                    }
                }

                return TalXYEtaXY / somaTalXYEtaXY;
            }
        }

        public Double Porcentagem(Cidade cidadeOrigem, Cidade cidadeDestino)
        {
            if (cidadeDestino.IsVisitado) return -1;
            if (cidadeDestino.Id == cidadeOrigem.Id) return -1;
            this.CidadeX = cidadeOrigem;
            this.CidadeY = cidadeDestino;
            return Probabilidade * 100;
        }
    }
}
