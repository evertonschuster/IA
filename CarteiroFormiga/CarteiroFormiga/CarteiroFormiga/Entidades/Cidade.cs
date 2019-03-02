using CarteiroFormiga.Uteis.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarteiroFormiga.Entidades
{
    class Cidade
    {

        public String Id { get; }
        private List<Rota> Rotas{ get;  set; }
        public Boolean IsVisitado { get; private set; }

        public Cidade(string id)
        {
            this.Id = id.ToUpper();
        }

        public void AddRota(Rota rota)
        {
            //nao pode adicionar a mesma cidada
            if( this.Rotas.Exists(r => r.Cidade.Id == rota.Cidade.Id))
            {
                throw new RotaRepetidaException(rota);
            }

            this.Rotas.Add(rota);
        }

        public List<Rota> GetRota => this.Rotas.ToList();
    }
}
