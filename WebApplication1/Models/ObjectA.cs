using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ObjectA
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public List<ObjectB> ObjectBs { get; set; } = new List<ObjectB>();
    }
}
