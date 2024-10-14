namespace FrankyFinance.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<MiembroGrupo> Miembros { get; set; }
        public ICollection<Gasto> Gastos { get; set; }
    }
}
