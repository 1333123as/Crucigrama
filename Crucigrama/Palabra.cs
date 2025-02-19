﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crucigrama
{
    public class Palabra
    {
        public string texto;
        public List<TextBox> cajas;
        public Boolean llena;
        public Palabra(string c, List<TextBox> arr)
        {
            this.texto = c;
            this.cajas = new List<TextBox>();
            this.cajas = arr;
            this.llena = false;
        }

        public Boolean estaLlenaCorrectamente()
        {
            string linea = "";
            foreach (TextBox txt in cajas) { 
                linea += txt.Text;
            }
            return linea == this.texto;
        }
    }
}
