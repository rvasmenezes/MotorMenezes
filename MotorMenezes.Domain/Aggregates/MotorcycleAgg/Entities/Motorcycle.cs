using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Domain.Aggregates.MotorcycleAgg.Entities
{
    public class Motorcycle
    {
        [Key]
        public int Id { get; set; }

        public int Year { get; set; }

        [StringLength(100)]
        public string Model { get; set; }

        [StringLength(100)]
        public string Plate { get; set; }

        public Motorcycle(int year, string model, string plate)
        {
            Year = year;
            Model = model;
            Plate = plate;
        }

        public void SetPlate(string plate) => Plate = plate;
    }
}
