using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudProcess.Model
{
    [Table("Students", Schema ="scl")]
    public class Student : CrudBase
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Surname { get; set; }
    }
}
