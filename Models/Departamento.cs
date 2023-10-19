using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemPag.Models
{
    [Table("Departamentos")]

    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }

        [Required]
        [StringLength(40)]
        public string Descricao { get; set; }

        public virtual List<Funcionario> Funcionarios { get; set; }
    }
}
