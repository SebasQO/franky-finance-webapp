using System.ComponentModel.DataAnnotations.Schema;

namespace FrankyFinance.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }

        public ICollection<GastoCompartido> Participantes { get; set; }
    }
}
