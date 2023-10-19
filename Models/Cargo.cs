using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemPag.Models
{
    [Table("Cargos")]

    public class Cargo
    {
        [Key]
        public int CargoId { get; set; }

        [Required]
        [StringLength(40)]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal SalarioBase { get; set; }

        public virtual List<Funcionario> Funcionarios { get; set; }
    }
}
