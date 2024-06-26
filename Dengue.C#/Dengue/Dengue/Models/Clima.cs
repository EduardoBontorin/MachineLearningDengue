using System.ComponentModel.DataAnnotations;

namespace Dengue.Models
{
    public class Clima
    {
        
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Ano { get; set; }
        public string? Data { get; set; }
        public string? Hora { get; set; }
        public string? Precipitacao { get; set; }
        public string? TempMax { get; set; }
        public string? TempMin { get; set; }
        public string? Umidade { get; set; }
    }
}
