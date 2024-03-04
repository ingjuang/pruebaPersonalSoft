namespace Prueba.Domain.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int Model { get; set; }
        public bool State { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public int LocationId { get; set; }

        public Car(int id, string brand, int model, bool state, string type, string color, int locationId)
        {
            Id = id;
            Brand = brand;
            Model = model;
            State = state;
            Type = type;
            Color = color;
            LocationId = locationId;
        }

        public Car() { }  
    }
}
