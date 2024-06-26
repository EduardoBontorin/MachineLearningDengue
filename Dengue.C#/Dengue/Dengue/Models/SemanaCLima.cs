using System.ComponentModel.DataAnnotations;

namespace Dengue.Models
{
    public class SemanaCLima
    {

        public int Id { get; set; }
        public string Ano { get; set; }
        public int WeekNumber { get; set; }
        public double TemperaturaMaxima { get; set; }
        public double TemperaturaMinima { get; set; }
        public double TotalPrecipitacao { get; set; }
    }
}
