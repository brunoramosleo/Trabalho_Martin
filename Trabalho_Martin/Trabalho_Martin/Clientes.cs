using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Martin
{
    class Clientes
    {
        public string Nome;
        public string Sabor;
        public string Cobertura;

        public Clientes(string Nome, string Sabor, string Cobertura)
        {
            this.Nome = Nome;
            this.Sabor = Sabor;
            this.Cobertura = Cobertura;
        }

        public void Editar(string Nome, string Sabor, string Cobertura)
        {
            this.Nome = Nome;
            this.Sabor = Sabor;
            this.Cobertura = Cobertura;
        }
    }
}
