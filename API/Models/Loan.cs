using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        public int OriginAddress { get; set; }
        public int DestinationAddress { get; set; }
        public int CarId { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
