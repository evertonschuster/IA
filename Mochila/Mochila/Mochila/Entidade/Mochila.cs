using AlgoritmoMochila.Uteis.exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AlgoritmoMochila.Entidade
{
    internal class Mochila
    {
        #region Geracao de ID
        int _field1;
        private static int geradorId = 0;
        private List<Objeto> _objetos;

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
        public int PesoMochila => this.Objetos.FindAll(o => o.Quantidade > 0).Sum(o => o.Peso);
        public int BeneficioMochila => this.Objetos.FindAll(o => o.Quantidade > 0).Sum(o => o.Beneficio);
        public Double FuncaoObjetiva => this.Objetos.FindAll(o => o.Quantidade > 0).Sum(o => o.FuncaoObjetiva);

        public List<Objeto> Objetos
        {
            get
            {
                _objetos.Sort();
               
                return _objetos;
            }
            protected set => _objetos = value;
        }

        public Mochila(int capacidade)
        {
            this.Id = getId();
            this.Objetos = new List<Objeto>();
            this.Capacidade = capacidade;
        }

        public void MostrarMochila()
        {
            Console.WriteLine($"Capacidade da Mochila: {this.PesoMochila}/{this.Capacidade}");
            Console.WriteLine($"Funcao(Qualidade). {this.FuncaoObjetiva }");
            Console.WriteLine("----------------------------------------------------------");
            //foreach (var item in this.Objetos.OrderBy(o => o.Id))
            //{
            //    Console.WriteLine($"Item: {item.Id} Quantidade: {item.Quantidade} Beneficio: {item.Beneficio} Peso: {item.Peso} Funca(Qualidade): {item.FuncaoObjetiva.ToString() }");
            //}
        }

        /// <summary>
        /// Tenta adicionar um Objeto na mochila
        /// </summary>
        /// <exception cref="CapacidadeMochilaException">Quando adicionado item alem da Sapacidade</exception>
        /// <param name="obj"></param>
        public void AdicionarItemMochila(Objeto obj)
        {
            int contadorPeso = this.PesoMochila;

            //verefica se ainda possui lugar
            if (contadorPeso > this.Capacidade)
            {
                int espacoLivre = this.Capacidade - contadorPeso;
                int quantidadeLivre = (espacoLivre / obj.Peso) < 0 ? 0 : (espacoLivre / obj.Peso);
                throw new CapacidadeMochilaException(espacoLivre <= 0, quantidadeLivre);
            }


            //Verefica se pode add
            contadorPeso += obj.Peso;
            if (contadorPeso > this.Capacidade && obj.Quantidade > 0)
            {
                int espacoLivre = this.Capacidade - (contadorPeso - obj.Peso);
                int quantidadeLivre = (espacoLivre / obj.Peso) < 0 ? 0 : (espacoLivre / obj.Peso);
                throw new CapacidadeMochilaException(espacoLivre <= 0, quantidadeLivre);
            }

            this.Objetos.Add(obj);
        }

        public double Beneficio()
        {
            return this.Objetos.FindAll(o => o.Quantidade > 0).Sum(o => o.Beneficio);
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
