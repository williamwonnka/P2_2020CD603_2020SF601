using System.ComponentModel.DataAnnotations;

namespace P2_2020CD603_2020SF601.Models
{
    public class Generos
    {
        [Key]
        public int idGenero { get; set; }

        public string? genero { get; set; }
    }
}
