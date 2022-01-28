using Grid_Perfomace.Componentes.Entidade;
using Grid_Perfomace.Componentes.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Grid_Perfomace.Componentes.Service
{
    public class ColunaService
    {
        public ColunaService()
        {
            colunas = new List<Coluna>();
        }

        public int ID { get; set; }
        public object Descricao { get; set; }
        public string Localizacao { get; set; }
        public int Qtde { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public Brush Cores { get; set; }
        public bool Ok { get; set; }
        private List<Coluna> colunas { get; set; }
        
        public List<Coluna> GerarListaColuna(int min, int max, int quantidadeColunas)
        {
            for (int i = 0; i < quantidadeColunas; i++)
            {
                Random rnd = new Random();
                colunas.Add(new Coluna(i + 1,
                    rnd.GerarStringAleatoria(min, max, "JKJDKJjkd!@$@#FD3942893HB489S0sdhjddnki"),
                    rnd.GerarStringAleatoria(min, max, "DSKAJ9491,d0s09349$#xn,mvc.192841-03#@%"),
                    rnd.GerarInteiroAleatorio(1000),
                    rnd.GerarDoubleAleatorio(),
                    rnd.GerarDataAleatoria(),
                    rnd.GerarStringCorAleatoria(),
                    rnd.GerarBoolAleatorio()));
            }
            return colunas.Count > 0 ? colunas : new List<Coluna>();
        }
    }
}
