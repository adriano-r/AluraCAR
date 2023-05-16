using System;
using System.Collections.Generic;
using System.Text;

namespace AluraCAR.Models
{
    public class ListagemVeiculos
    {
        public ListagemVeiculos() 
        {
           this.Veiculos = new List<Veiculo>
            {
                new Veiculo { Nome = "Azire", Preco = 60000 },
                new Veiculo { Nome = "Gol", Preco = 40000 },
                new Veiculo { Nome = "Corsa", Preco = 30000 }
            };
        }

        public static implicit operator List<object>(ListagemVeiculos v)
        {
            throw new NotImplementedException();
        }
    }
}
