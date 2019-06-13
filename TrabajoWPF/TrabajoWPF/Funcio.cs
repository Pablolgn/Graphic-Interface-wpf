using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoWPF
{
    public class Funcio
    {
        public String tipus { get; set; }
        public String colr { get; set; }
        public String nom { get; set; }
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public int n { get; set; }
        public int ejex_Max { get; set; }
        public int ejex_Min { get; set; }
        public int ejey_Max { get; set; }
        public int ejey_Min { get; set; }
        public Boolean estado { get; set; }

        public Funcio(string t, string no, string color, int va, int vb, int vc, int vn, int x_max, int x_min, int y_max, int y_min)
        {
            this.a = va;
            this.b = vb;
            this.c = vc;
            this.n = vn;
            this.tipus = t;
            this.colr = color;
            this.nom = no;
            this.ejex_Max = x_max;
            this.ejex_Min = x_min;
            this.ejey_Max = y_max;
            this.ejey_Min = y_min;

        }


    }
}
