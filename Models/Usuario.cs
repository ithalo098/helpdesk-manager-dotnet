namespace atividadde.Models
{
    public abstract class Usuario
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }

        protected Usuario(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public virtual string GetDescricao()
        {
            return Nome;
        }
    }
}
