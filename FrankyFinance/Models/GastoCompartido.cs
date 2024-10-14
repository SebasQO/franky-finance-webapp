namespace FrankyFinance.Models
{
    public class GastoCompartido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int GastoId { get; set; }
        public Gasto Gasto { get; set; }

        public decimal MontoAPagar { get; set; }
        public bool Pagado { get; set; }
    }
}
