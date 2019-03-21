using CarteiroFormiga.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarteiroFormiga.Entidades
{
    class Rota
    {
        private const Double QUANTIDADE_FEROMONIO_ADICIODAR = 0.32;
        private const Double QUANTIDADE_FEROMONIO_EVAPORA = 5.89;

        private static List<Rota> Rotas = new List<Rota>();

        private static void AddRota(Rota rota)
        {
            if (Rota.Rotas.Exists(r => (r.CidadeA.Id == rota.CidadeA.Id && r.CidadeB.Id == rota.CidadeB.Id)
            || (r.CidadeB.Id == rota.CidadeA.Id && r.CidadeA.Id == rota.CidadeB.Id)))
            {
                return;
            }
            Rota.Rotas.Add(rota);

        }

        public static void AddFeromonio(Cidade cidadeA, Cidade cidadeB)
        {
            var cidade = Rota.Ordenar(cidadeA, cidadeB);
            cidadeA = cidade[0];
            cidadeB = cidade[1];

            Rota rota = Rota.Rotas.Find(r => r.CidadeA.Id == cidadeA.Id && r.CidadeB.Id == cidadeB.Id);
            rota.Feromonio += QUANTIDADE_FEROMONIO_ADICIODAR;
        }

        public static void EvaporarFeromonio()
        {
            foreach (var item in Rota.Rotas)
            {
                item.Feromonio -= QUANTIDADE_FEROMONIO_EVAPORA;
                if (item.Feromonio < 0.01)
                {
                    item.Feromonio = 0.01;
                }
            }
        }

        public static void AddFeromonio(Rota rota)
        {
            Rota.AddFeromonio(rota.CidadeA, rota.CidadeB);
        }

        public static List<Rota > GetRota(Cidade cidade)
        {
            List<Rota> ro = Rota.Rotas.FindAll(r => r.CidadeA.Id == cidade.Id || r.CidadeB.Id == cidade.Id);
            return ro;
        }

        public static List<Rota> GetRota()
        {
            return Rota.Rotas;

        }

        public static Rota GetRota(Cidade cidadeA, Cidade cidadeB)
        {
            var cidade = Rota.Ordenar(cidadeA, cidadeB);
            cidadeA = cidade[0];
            cidadeB = cidade[1];
            Rota ro = Rota.Rotas.Find(r => r.CidadeA.Id == cidadeA.Id && r.CidadeB.Id == cidadeB.Id);
            return ro;
        }

        private static List<Cidade> Ordenar(Cidade cidadeA, Cidade cidadeB)
        {
            var cidade = new List<Cidade>(2);
            cidade.Add(cidadeA);
            cidade.Add(cidadeB);
            return cidade.OrderBy(c => c.Id).ToList();
        }


        public Cidade CidadeA { get; set; }
        public Cidade CidadeB { get; set; }
        public int Distancia { get; set; }

        public Double Feromonio  { get; private set; }


        public Rota(Cidade cidadeA, Cidade cidadeB, int distancia)
        {
            this.Distancia = distancia;


            var cidade = Rota.Ordenar(cidadeA, cidadeB);

            this.CidadeA = cidade[0];
            this.CidadeB = cidade[1];

            this.Feromonio = 0.1;

            Rota.AddRota(this);
        }

        public Boolean Equal(Object obj)
        {
            Rota rota = obj as Rota;
            if (obj == null) return false;

            var cidade = Rota.Ordenar(rota.CidadeA, rota.CidadeB);
            var objCidadeA = cidade[0];
            var objCidadeB = cidade[1];

            cidade = Rota.Ordenar(this.CidadeA, this.CidadeB);
            var thisCidadeA = cidade[0];
            var thisCidadeB = cidade[1];

            return objCidadeA.Id == thisCidadeA.Id && objCidadeB.Id == thisCidadeB.Id;
        }
        internal Rota Clone()
        {
            return this.CloneTheObject();
        }
    }
}
