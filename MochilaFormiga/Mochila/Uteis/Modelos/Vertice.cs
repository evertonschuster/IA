using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace UFRJ.EngSoft23.Modelos
{
    public class Vertice
    {
        public string Id;
        public string Nome;
        public Point XY;
        public bool EhTerminal;
        public Vertice(string id, string nome, Point xy, bool ehTerminal = false)
        {
            Id = id;
            Nome = nome;
            XY = xy;
            EhTerminal = ehTerminal;
        }
        public override bool Equals(object obj)
        {
            return this.Id == ((Vertice)obj).Id;
        }
    }
}
