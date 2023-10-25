using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic; 

namespace SystemPag.Models
{
    // Atributo [Table] especifica o nome da tabela no banco de dados.
    [Table("Cargos")]
    public class Cargo
    {
        // Atributo [Key] indica que a propriedade é a chave primária da tabela.
        public int CargoId { get; set; }

        // Atributo [Required] indica que a propriedade é obrigatória.
        [Required]
        // Atributo [StringLength] especifica o tamanho máximo da string.
        [StringLength(40)]
        public string Descricao { get; set; }

        // Atributo [Column] permite especificar detalhes da coluna no banco de dados.
        [Required]
        [Column(TypeName = "decimal (10,2)")]
        public decimal SalarioBase { get; set; }

        // Esta propriedade de navegação representa a relação entre Cargo e Funcionario.
        // Um cargo pode ter vários funcionários.
        public virtual List<Funcionario> Funcionarios { get; set; }
    }
}
