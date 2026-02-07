using System.Collections.Generic;
using System.Linq;
using atividadde.Models;

namespace atividadde.Services
{
    public class ChamadoService
    {
        private readonly List<Chamado> _chamados = new();

        public void AbrirChamado(Chamado chamado)
        {
            _chamados.Add(chamado);
        }

        public List<Chamado> ListarPorStatus(string status)
        {
            return _chamados.Where(c => c.Status == status).ToList();
        }

        public List<Chamado> ListarPorTecnico(Tecnico tecnico)
        {
            return _chamados.Where(c => c.Tecnico == tecnico).ToList();
        }
    }
}
