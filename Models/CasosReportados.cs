using System.ComponentModel.DataAnnotations;

namespace P2_2020CD603_2020SF601.Models
{
    public class CasosReportados
    {
        [Key]
        public int idCaso { get; set; }
        public int departamento { get; set; }
        public int genero { get; set; }
        public int casosConfirmados { get; set; }
        public int numeroRecuperados { get; set; }
        public int numeroFallecidos { get; set; }

    }
}
