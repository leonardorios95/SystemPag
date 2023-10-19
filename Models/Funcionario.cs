using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SystemPag.Models
{
    [Table("Funcionarios")]

    public class Funcionario
    {
       
            [Key]
            public int FuncionarioId { get; set; }

            [Required]
            [StringLength(100)]
            public string Nome { get; set; }

            public int CargoId { get; set; }
            public int DepartamentoId { get; set; }
            public int EmpresaId { get; set; }

            public virtual Cargo Cargo { get; set; }
            public virtual Departamento Departamento { get; set; }
            public virtual Empresa Empresa { get; set; }
            public virtual List<Holerite> Holerites { get; set; }
        }

    }

