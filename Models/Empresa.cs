using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SystemPag.Models
{
    // Atributo [Table] especifica o nome da tabela no banco de dados.
    [Table("Empresas")]
    public class Empresa
    {
        // Atributo [Key] indica que a propriedade é a chave primária da tabela.
        public int EmpresaId { get; set; }

        // Atributo [Required] indica que a propriedade é obrigatória.
        [Required]
        // Atributo [StringLength] especifica o tamanho máximo da string.
        [StringLength(100)]
        public string RazaoSocial { get; set; }

        // Atributo [Required] indica que a propriedade é obrigatória.
        [Required]
        // Atributo [StringLength] especifica o tamanho máximo da string.
        [StringLength(14)]
        public string CNPJ { get; set; }

        // Esta propriedade de navegação representa a relação entre Empresa e Funcionario.
        // Uma empresa pode ter vários funcionários.
        public virtual List<Funcionario> Funcionarios { get; set; }
    }
}
