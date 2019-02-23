using AlgoritmoMochila.Entidade;
using AlgoritmoMochila.Uteis.exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmoMochila.Genetica
{
    internal class Crossover
    {
        private Mochila MochilaPai { get; set; }
        private Mochila MochilaMae { get; set; }

        private Random r = new Random();

        private int PROBABILIDADE_MUTANTE = 05;

        public Crossover(Mochila mochilaPai, Mochila mochilaMae)
        {
            MochilaPai = mochilaPai;
            MochilaMae = mochilaMae;
        }

        public Crossover()
        {
        }

        public List<Mochila> GerarFilhos(Mochila mochilaPai = null, Mochila mochilaMae = null)
        {
            this.MochilaPai = mochilaPai ?? this.MochilaPai;
            this.MochilaMae = mochilaMae ?? this.MochilaMae;

            if (this.MochilaMae.Capacidade != this.MochilaPai.Capacidade)
            {
                throw new CapacidadeMochilaDiferenteException();
            }

            int pontoCorteA = this.GetPontoCorte(0);
            int pontoCorteB = this.GetPontoCorte(pontoCorteA);
            if (pontoCorteA > pontoCorteB)
            {
                int aux = pontoCorteA;
                pontoCorteA = pontoCorteB;
                pontoCorteB = aux;
            }

            Mochila mochilaFilhaPai = GerarUmFilho(pontoCorteA, pontoCorteB);
            Mochila mochilaFilhaMae = GerarUmFilho(pontoCorteA, pontoCorteB, false);

            List<Mochila> filhos = new List<Mochila>();
            filhos.Add(mochilaFilhaPai);
            filhos.Add(mochilaFilhaMae);

            return filhos;
        }

        private Mochila VereficaMutante(Mochila mochila)
        {
            if (IsMutante())
            {
                //se for mutante, procura 1 item, para mudar a quantidade
                while (true)
                {
                    int index = r.Next(mochila.Objetos.Count);
                    Objeto objeto = mochila.Objetos[index];
                    mochila.Objetos.RemoveAt(index);

                    int quantidade = objeto.Quantidade == 0 ? 1 : 0;
                    var NovoObjeto = new Objeto(objeto, quantidade);
                    try
                    {
                        mochila.AdicionarItemMochila(NovoObjeto);
                        break;
                    }
                    catch (CapacidadeMochilaException ex)
                    {
                        mochila.AdicionarItemMochila(objeto);
                    }

                }
            }
            return mochila;
        }

        private Boolean IsMutante()
        {
            int chance = r.Next(101);
            return chance <= this.PROBABILIDADE_MUTANTE;
        }

        private Mochila GerarUmFilho(int pontoCorteA, int pontoCorteB, Boolean isPrimeiro = true)
        {
            Mochila mochilaMae = isPrimeiro ? this.MochilaMae : this.MochilaPai;
            Mochila mochilaPai = isPrimeiro ? this.MochilaPai : this.MochilaMae;
            Mochila mochilaFilha = new Mochila(this.MochilaMae.Capacidade);

            //se nao isPrimeiro, eu inverto os pais
            try
            {
                for (int i = 0; i < this.MochilaPai.Objetos.Count; i++)
                {
                    //entre o ponto de corte, faz a troca de genes
                    if (i >= pontoCorteA && i <= pontoCorteB)
                    {
                        mochilaFilha.AdicionarItemMochila(mochilaMae.Objetos[i].Clone());
                    }
                    else
                    {
                        mochilaFilha.AdicionarItemMochila(mochilaPai.Objetos[i].Clone());
                    }

                }
            }
            catch (CapacidadeMochilaException ex)
            {
                var gerador = new GerarMochila(mochilaPai.Objetos, mochilaPai);
                return gerador.GerarPopulacaoInicial();
            }

            return this.VereficaMutante(mochilaFilha);
        }

        private int GetPontoCorte(int pontoAnterior = 0)
        {
            int tamanho = this.MochilaPai.Objetos.Count;
            int ponto = r.Next(tamanho);

            while (Math.Abs(pontoAnterior - ponto) < 3)
            {
                ponto = r.Next(tamanho);
            }

            return ponto;
        }
    }
}
