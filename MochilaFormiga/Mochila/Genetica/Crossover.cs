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
        public int FilhosAlejado { get; private set; }

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
            if (mochilaFilhaPai != null)
            {
                filhos.Add(mochilaFilhaPai);
            }
            if (mochilaFilhaMae != null)
            {
                filhos.Add(mochilaFilhaMae);
            }

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

            Objeto objeto;

            for (int count = 0; count < this.MochilaPai.Objetos.Count; count++)
            {
                int i = r.Next(this.MochilaPai.Objetos.Count);

                while(mochilaFilha.Objetos.Exists(o => o.Id == i + 1))
                {
                    i = r.Next(this.MochilaPai.Objetos.Count);
                }

                //entre o ponto de corte, faz a troca de genes
                if (i >= pontoCorteA && i <= pontoCorteB)
                {
                    objeto = mochilaMae.Objetos[i].Clone();
                }
                else
                {
                    objeto = mochilaPai.Objetos[i].Clone();
                }

                try
                {
                    mochilaFilha.AdicionarItemMochila(objeto);
                }
                catch (CapacidadeMochilaException ex)
                {
                    this.FilhosAlejado++;
                    objeto = new Objeto(objeto, 0);
                    mochilaFilha.AdicionarItemMochila(objeto);
                }
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
