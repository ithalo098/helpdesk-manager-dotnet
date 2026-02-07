using System;

namespace atividadde.Models
{
    public class HistoricoChamado
    {
        public DateTime Data { get; private set; }
        public string Descricao { get; private set; }

        public HistoricoChamado(string descricao)
        {
            Data = DateTime.Now;
            Descricao = descricao;
        }
    }
}
