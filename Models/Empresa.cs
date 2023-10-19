using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SystemPag.Models
{
    [Table("Empresas")]

    public class Empresa
    {
        
            [Key]
            public int EmpresaId { get; set; }

            [Required]
            [StringLength(100)]
            public string RazaoSocial { get; set; }

            [Required]
            [StringLength(14)]
            public string CNPJ { get; set; }
        
            public virtual List<Funcionario> Funcionarios { get; set; }
        }
    }

