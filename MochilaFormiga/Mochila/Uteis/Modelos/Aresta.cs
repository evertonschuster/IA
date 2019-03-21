using AlgoritmoMochila.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UFRJ.EngSoft23.Modelos
{
    public class Aresta
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

        public int Id { get; set; }
        public Objeto  Origem { get; set; }
        public Objeto Destino { get; set; }
        public double Feromonio { get; set; }
        public double PesoPorcentagem { get; set; }
        /// <summary>
        /// Calculo de distância entre Vértice A e Vértice B.
        /// </summary>
        public double Peso
        {
            get
            {
                return Destino.Beneficio + Feromonio;
            }
        }

        public Aresta( Objeto origem, Objeto destino)
        {
            Id = Aresta.geradorId;
            Origem = origem;
            Destino = destino;
        }
        public override string ToString()
        {
            return string.Concat(Origem.Id , " > ", Destino.Id);
        }

        internal void MostrarAresta()
        {
            Console.Write(this.ToString() + $"({this.Feromonio})  " );
        }
    }
}
