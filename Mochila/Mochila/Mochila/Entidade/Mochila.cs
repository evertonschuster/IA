using AlgoritmoMochila.Uteis.exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AlgoritmoMochila.Entidade
{
    internal class Mochila
    {
        #region Geracao de ID
        int _field1;
        private static int geradorId = 0;
        private int getId()
        {
            int id = 0;
            Monitor.Enter(this);
            try
            {
                geradorId++;
                id = geradorId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Monitor.Exit(this);
            }
            return id;
        }


        #endregion

        public int Id { get; }
        public int Capacidade { get; }

        public Boolean IsCheia => this.PesoMochila >= this.Capacidade;
        public int PesoMochila => this.Objetos.Sum(o => o.Quantidade * o.Peso);

        public List<Objeto> Objetos { get; protected set; }

        public Mochila(int capacidade)
        {
            this.Id = getId();
            this.Objetos = new List<Objeto>();
            this.Capacidade = capacidade;
        }

        public void MostrarMochila()
        {
            Console.WriteLine($"Capacidade da Mochila: {this.PesoMochila}/{this.Capacidade}");
            Console.WriteLine($"Custo Beneficio. {this.CustoBeneficio() }");
            Console.WriteLine("----------------------------------------------------------");
            foreach (var item in this.Objetos.OrderBy(o => o.Id))
            {
                Console.WriteLine($"Item: {item.Id} Quantidade: {item.Quantidade} Peso: {item.Peso} Total: {item.Quantidade * item.Peso} Funca: {item.FuncaoObjetiva }");
            }
        }

        /// <summary>
        /// Tenta adicionar um Objeto na mochila
        /// </summary>
        /// <exception cref="CapacidadeMochilaException">Quando adicionado item alem da Sapacidade</exception>
        /// <param name="obj"></param>
        public void AdicionarItemMochila(Objeto obj)
        {
            int contadorPeso = this.Objetos.Sum(o => o.Peso * o.Quantidade);

            //verefica se ainda possui lugar
            if (contadorPeso > this.Capacidade)
            {
                int espacoLivre = this.Capacidade - contadorPeso;
                int quantidadeLivre = (espacoLivre / obj.Peso) < 0 ? 0 : (espacoLivre / obj.Peso);
                throw new CapacidadeMochilaException(espacoLivre <= 0, quantidadeLivre);
            }


            //Verefica se pode add
            contadorPeso += obj.Peso * obj.Quantidade;
            if (contadorPeso > this.Capacidade)
            {
                int espacoLivre = this.Capacidade - (contadorPeso - obj.Peso * obj.Quantidade);
                int quantidadeLivre = (espacoLivre / obj.Peso) < 0 ? 0 : (espacoLivre / obj.Peso);
                throw new CapacidadeMochilaException(espacoLivre <= 0, quantidadeLivre);
            }

            this.Objetos.Add(obj);
        }

        public double  CustoBeneficio()
        {
            return this.Objetos.Sum(o => o.FuncaoObjetiva ) * this.Objetos.Select(o => o.Quantidade > 0).Count();
        }

        /// <summary>
        /// Clona a Mochila Atuall
        /// </summary>
        /// <returns><see cref="Mochila"/></returns>
        internal Mochila Clone()
        {
            return new Mochila(this.Capacidade);
        }
    }
}
