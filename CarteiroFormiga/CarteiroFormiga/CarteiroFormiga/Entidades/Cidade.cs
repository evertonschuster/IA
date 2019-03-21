using CarteiroFormiga.Uteis.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarteiroFormiga.Entidades
{
    class Cidade
    {

        #region Cidade

        private static List<Cidade> Cidades = new List<Cidade>();

        public static void ResetRotas()
        {
            foreach (var item in Cidade.Cidades)
            {
                item.IsVisitado = false;
            }
        }

        private static void AddCidade(Cidade cidade)
        {
            Cidade.Cidades.Add(cidade);
        }

        public static Cidade GetCidadeById(string key)
        {
            return Cidade.Cidades.Find(c => c.Id == key);
        }

        public static Boolean HasAllVisitadas()
        {
            return !Cidade.Cidades.Exists(c => c.IsVisitado == false);
        }

        public static List<Cidade> GetCidade()
        {
            return Cidade.Cidades;
        }

        #endregion

        public String Id { get; }
        public Boolean IsVisitado { get; set; }

        public Cidade(string id)
        {
            this.Id = id.ToUpper();
            Cidade.AddCidade(this);
        }

        public List<Rota> GetRota => Rota.GetRota(this);
    }
}
