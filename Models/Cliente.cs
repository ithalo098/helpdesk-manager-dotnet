namespace atividadde.Models
{
    public class Cliente : Usuario
    {
        public Cliente(int id, string nome, string email)
            : base(id, nome, email) { }

        public override string GetDescricao()
        {
            return $"Cliente: {Nome}";
        }
    }
}
