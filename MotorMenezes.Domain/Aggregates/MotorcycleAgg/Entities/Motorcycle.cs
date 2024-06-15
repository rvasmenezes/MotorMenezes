using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorMenezes.Domain.Aggregates.MotorcycleAgg.Entities
{
    public class Motorcycle
    {
        [Key]
        [StringLength(255)]
        public string Id { get; set; }

        public int Year { get; set; }

        [StringLength(100)]
        public string Model { get; set; }

        [StringLength(100)]
        public string Plate { get; set; }

        public Motorcycle(int year, string model, string plate)
        {
            Id = Guid.NewGuid().ToString();
            Year = year;
            Model = model;
            Plate = plate;
        }

        public void SetPlate(string plate) => Plate = plate;
    }
}
