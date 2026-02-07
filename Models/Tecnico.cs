namespace atividadde.Models
{
    public class Tecnico : Usuario
    {
        public string Especialidade { get; private set; }

        public Tecnico(int id, string nome, string email, string especialidade)
            : base(id, nome, email)
        {
            Especialidade = especialidade;
        }
    }
}
