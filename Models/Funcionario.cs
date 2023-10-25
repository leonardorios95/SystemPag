using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; 

namespace SystemPag.Models
{
    [Table("Funcionarios")]

    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; } // Identificador único do funcionário

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } // Nome do funcionário

        public int CargoId { get; set; } // Chave estrangeira que se relaciona com o Cargo
        public int DepartamentoId { get; set; } // Chave estrangeira que se relaciona com o Departamento
        public int EmpresaId { get; set; } // Chave estrangeira que se relaciona com a Empresa

        public virtual Cargo Cargo { get; set; } // Representa o cargo do funcionário
        public virtual Departamento Departamento { get; set; } // Representa o departamento ao qual o funcionário pertence
        public virtual Empresa Empresa { get; set; } // Representa a empresa onde o funcionário trabalha

        public virtual List<Holerite> Holerites { get; set; } // Uma lista de holerites associados a este funcionário
    }
}
