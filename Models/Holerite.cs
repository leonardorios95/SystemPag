using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SystemPag.Models
{
    [Table("Holerites")]

    public class Holerite
    {
        [Key]
        public int HoleriteId { get; set; } // Identificador único do holerite

        [Required]
        public int MesReferencia { get; set; } // Mês de referência do holerite

        [Required]
        [StringLength(4)]
        public string AnoReferencia { get; set; } // Ano de referência do holerite

        [Required]
        public int TotalFaltas { get; set; } // Total de faltas do funcionário no mês

        [Required]
        public int HorasExtras { get; set; } // Total de horas extras trabalhadas

        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal SalarioBruto { get; set; } // Salário bruto do funcionário

        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal DescontoIRRF { get; set; } // Valor do desconto do IRRF (Imposto de Renda)

        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal DescontoINSS { get; set; } // Valor do desconto do INSS (Previdência Social)

        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal DescontoConvenio { get; set; } // Valor de desconto do convênio médico

        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal DescontoVR { get; set; } // Valor de desconto do vale refeição

        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal DescontoVT { get; set; } // Valor de desconto do vale transporte

        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal SalarioLiquido { get; set; } // Salário líquido do funcionário após os descontos

        public int FuncionarioId { get; set; } // Chave estrangeira para a classe Funcionario

        public virtual Funcionario Funcionario { get; set; } // Representa o funcionário a quem pertence este holerite
    }
}
