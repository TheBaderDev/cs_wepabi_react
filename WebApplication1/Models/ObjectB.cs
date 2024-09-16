using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class ObjectB
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }

        public string description { get; set; }

        public int? ObjectAId { get; set; }

        [JsonIgnore]
        public ObjectA? ObjectA { get; set; }
    }
}
