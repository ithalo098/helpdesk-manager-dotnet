using System.Collections.Generic;
using atividadde.Interfaces;

namespace atividadde.Models
{
    public class Chamado : IAtribuivel, IEncerravel
    {
        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public Tecnico Tecnico { get; private set; }
        public Categoria Categoria { get; private set; }
        public string Status { get; private set; }

        public List<HistoricoChamado> Historico { get; private set; }

        public Chamado(int id, Cliente cliente, Categoria categoria)
        {
            Id = id;
            Cliente = cliente;
            Categoria = categoria;
            Status = "Aberto";
            Historico = new();
        }

        public void AtribuirTecnico(Tecnico tecnico)
        {
            Tecnico = tecnico;
            Status = "Em andamento";
        }

        public void Encerrar()
        {
            Status = "Encerrado";
        }
    }
}
