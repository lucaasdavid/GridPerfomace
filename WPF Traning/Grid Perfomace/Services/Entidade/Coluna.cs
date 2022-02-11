using System;
using System.Windows.Media;

namespace Grid_Perfomace.Services.Entidade
{
    public class Coluna
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public int Qtde { get; set; } 
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public Brush Cores { get; set; }
        public bool Ok { get; set; }

        public Coluna(int ID, string Descricao, string Localizacao, int Qtde, double Valor, DateTime Data, Brush Cores, bool Ok)
        {
            this.ID = ID;
            this.Descricao = Descricao;
            this.Localizacao = Localizacao;
            this.Qtde = Qtde;
            this.Valor = Valor;
            this.Data = Data;
            this.Cores = Cores;
            this.Ok = Ok;
        }
    }
}
