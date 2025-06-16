using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoApp.BLL
{
    public static class BingoManager
    {
        public static string AtualizaBolaSorteada(string labelBolaSorteadaText, string bolaSorteada)
        {
            return $"{labelBolaSorteadaText}, {PegaBolaSorteada(bolaSorteada)}";
        }
        public static string PegaBolaSorteada(string bolaSorteada)
        {
            return $"{PegaLetraDaBolaSorteada(bolaSorteada)}";
        }
        private static string PegaLetraDaBolaSorteada(string bolaSorteada)
        {
            int bolaSorteadaDouble = Convert.ToInt32(bolaSorteada);
            if (bolaSorteadaDouble <= 9) return $"B0{bolaSorteadaDouble}";
            else if (bolaSorteadaDouble <= 15) return $"B{bolaSorteadaDouble}";
            else if (bolaSorteadaDouble <= 30) return $"I{bolaSorteadaDouble}";
            else if (bolaSorteadaDouble <= 45) return $"N{bolaSorteadaDouble}";
            else if (bolaSorteadaDouble <= 60) return $"G{bolaSorteadaDouble}";
            else return $"O{bolaSorteadaDouble}";
        }
    }
}
