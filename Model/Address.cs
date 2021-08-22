using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NistagramSQLConnection.Model
{
    [Table("address")]
    public class Address
    {
        [Key]
        public long id { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string streetNumber { get; set; }
        public int postCode { get; set; }
    }
}
