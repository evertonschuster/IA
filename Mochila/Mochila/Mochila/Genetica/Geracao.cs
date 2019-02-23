using AlgoritmoMochila.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmoMochila.Genetica
{
    class Geracao
    {
        private List<Mochila> Populacao = new List<Mochila>();
        public Mochila MelhorMochila { get; private set; }
        public int GeracaoMelhorMochila{ get; private set; }
        private int QuantidadeMaximaPopulacao = 0;
        private int QuantidadeMaximaGeracoes = 0;
        private int QuantidadeMaximaFiliacao = 0;
        Crossover Crossover = new Crossover();
        Random r = new Random();

        public Geracao(int quantidadeMaximaPopulacao, int quantidadeMaximaGeracoes, int quantidadeMaximaFiliacao)
        {
            this.QuantidadeMaximaPopulacao = quantidadeMaximaPopulacao;
            this.QuantidadeMaximaGeracoes = quantidadeMaximaGeracoes;
            this.QuantidadeMaximaFiliacao = quantidadeMaximaFiliacao;
        }

        public void AdicionarMochila(Mochila mochila)
        {
            this.Populacao.Add(mochila);
        }
        public void AdicionarMochila(List<Mochila> ListMochila)
        {
            foreach (var item in ListMochila)
            {
                this.AdicionarMochila(item);
            }
        }

        public void EvoluirPopulacao()
        {

            for (int i = 0; i < this.QuantidadeMaximaGeracoes; i++)
            {
                this.GerarGeracao();
                this.ProcurarMelhorIndividuo(i);

                this.MelhorMochila.MostrarMochila();

                if (this.Populacao.Count >= this.QuantidadeMaximaPopulacao)
                {
                    this.EliminarIndividuos(this.Populacao.Count - this.QuantidadeMaximaPopulacao);
                }
            }

            this.MelhorMochila.MostrarMochila();
        }

        private void GerarGeracao()
        {
            int quantidadeFiliacao = r.Next(3, this.QuantidadeMaximaFiliacao);
            List<Mochila> novaGeracao = new List<Mochila>();

            for (int i = 0; i < quantidadeFiliacao; i++)
            {
                foreach (var item in GerarIndividuos())
                {
                    novaGeracao.Add(item);
                }
            }

            this.AdicionarMochila(novaGeracao);
        }

        private List<Mochila> GerarIndividuos()
        {
            Mochila mochilaPai;
            Mochila mochilaMae;

            int indexPai = r.Next(this.Populacao.Count);
            int indexMae = r.Next(this.Populacao.Count);

            while (indexMae == indexPai)
            {
                indexMae = r.Next(this.Populacao.Count);
            }

            mochilaPai = this.Populacao[indexPai];
            mochilaMae = this.Populacao[indexMae];

            return this.Crossover.GerarFilhos(mochilaPai, mochilaMae);
            //this.AdicionarMochila(filhos);
        }

        private void EliminarIndividuos(int quantidade)
        {
            for (int i = 0; i < quantidade; i++)
            {
                int index = r.Next(this.Populacao.Count);

                //Mantenho o melhor individuo
                while (this.MelhorMochila.Id == this.Populacao[index].Id)
                {
                    index = r.Next(this.Populacao.Count);
                }

                this.Populacao.RemoveAt(index);
            }
        }

        private void ProcurarMelhorIndividuo(int geracao)
        {
            Mochila tempMelhor = this.Populacao.OrderByDescending(m => m.FuncaoObjetiva).FirstOrDefault();
            if(tempMelhor.FuncaoObjetiva > this.MelhorMochila?.FuncaoObjetiva || MelhorMochila == null)
            {
                this.MelhorMochila = tempMelhor;
                this.GeracaoMelhorMochila = geracao;
            }
            
        }
    }
}
