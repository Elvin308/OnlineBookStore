using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Rakas_BookStore.Models
{
    public class Category
    {
        [Key] //Primary Key
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }

    }
}
