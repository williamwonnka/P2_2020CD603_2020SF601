using System.ComponentModel.DataAnnotations;

namespace P2_2020CD603_2020SF601.Models
{
    public class Departamentos
    {
        [Key]
        public int idDepartamento { get; set; }
        public string? departamento { get; set; }
    }
}
