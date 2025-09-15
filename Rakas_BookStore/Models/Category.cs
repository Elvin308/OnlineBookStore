using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Rakas_BookStore.Models
{
    public class Category
    {
        [Key] //Primary Key
        public int Id { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Category Description")]
        public string Description { get; set; }

        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

    }
}
