using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic; 

namespace SystemPag.Models
{
    // Atributo [Table] especifica o nome da tabela no banco de dados.
    [Table("Departamentos")]
    public class Departamento
    {
        // Atributo [Key] indica que a propriedade é a chave primária da tabela.
        public int DepartamentoId { get; set; }

        // Atributo [Required] indica que a propriedade é obrigatória.
        [Required]
        // Atributo [StringLength] especifica o tamanho máximo da string.
        [StringLength(40)]
        public string Descricao { get; set; }

        // Esta propriedade de navegação representa a relação entre Departamento e Funcionario.
        // Um departamento pode ter vários funcionários.
        public virtual List<Funcionario> Funcionarios { get; set; }
    }
}
