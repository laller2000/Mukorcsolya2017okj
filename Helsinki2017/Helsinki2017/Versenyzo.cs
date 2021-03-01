using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helsinki2017
{
    class Versenyzo
    {
        //Név;Ország;Technikai;Komponens;Levonás
        string nev;
        string orszag;
        double rovid_technikai;
        double rovid_komponens;
        int rovid_levonas;
        double donto_technikai=0;
        double donto_komponens=0;
        int donto_levonas=0;

        public Versenyzo(string[] sor)
        {
            this.Nev = sor[0];
            this.Orszag = sor[1];
            this.Rovid_technikai = double.Parse(sor[2].Replace('.',','));
            this.Rovid_komponens = double.Parse(sor[3].Replace('.',','));
            this.Rovid_levonas = int.Parse(sor[4]);
        }

        public string Nev { get => nev; set => nev = value; }
        public string Orszag { get => orszag; set => orszag = value; }
        public double Rovid_technikai { get => rovid_technikai; set => rovid_technikai = value; }
        public double Rovid_komponens { get => rovid_komponens; set => rovid_komponens = value; }
        public int Rovid_levonas { get => rovid_levonas; set => rovid_levonas = value; }
        public double Donto_technikai { get => donto_technikai; set => donto_technikai = value; }
        public double Donto_komponens { get => donto_komponens; set => donto_komponens = value; }
        public int Donto_levonas { get => donto_levonas; set => donto_levonas = value; }
    }
}
