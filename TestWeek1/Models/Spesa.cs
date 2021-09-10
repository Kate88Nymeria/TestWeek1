using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek1.Models
{
    public class Spesa
    {
        public DateTime DataSpesa { get; set; }
        public Categoria TipoCategoria { get; set; }
        public string Descrizione { get; set; }
        public double Importo { get; set; }

        public enum Categoria
        {
            Viaggio,
            Alloggio,
            Vitto,
            Altro
        }

        public static Categoria SceltaCategoria(string nomeCategoria)
        {
            if(nomeCategoria == "Viaggio")
            {
                return Categoria.Viaggio;
            }
            else if(nomeCategoria == "Alloggio")
            {
                return Categoria.Alloggio;
            }
            else if(nomeCategoria == "Vitto")
            {
                return Categoria.Vitto;
            }
            
            return Categoria.Altro;
        }

        public override string ToString()
        {
            return $"{DataSpesa.ToShortDateString()} - {TipoCategoria}: {Descrizione} - {Importo} euro";
        }
    }
}
