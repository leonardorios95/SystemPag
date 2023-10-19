using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SystemPag.Models
{
    [Table("Holerites")]

    public class Holerite
    {
        [Key]
        public int HoleriteId { get; set; }

        [Required]
        public int MesReferencia { get; set; }

        [Required]
        [StringLength(4)]
        public string AnoReferencia { get; set; }

        [Required]
        public int TotalFaltas { get; set; }

        [Required]
        public int HorasExtras { get; set; }

        [Required]
        [Column(TypeName ="decimal (10,2)")]
        public decimal SalarioBruto { get; set; }

        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal DescontoIRRF { get; set; }

        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal DescontoINSS { get; set; }

        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal DescontoConvenio { get; set; }

        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal DescontoVR { get; set; }

        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal DescontoVT { get; set; }

        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal SalarioLiquido { get; set; }

        public int FuncionarioId { get; set; } // Chave estrangeira para a classe Funcionario

        public virtual Funcionario Funcionario { get; set; } // Relacionamento com funcionario
    }
}
