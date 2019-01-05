using System.ComponentModel.DataAnnotations;

namespace ODataExpandAndSelect.Models
{
    public class Supplier
    {
        [Key]
        public string Key { get; set; }
        public string Name { get; set; }
    }
}