using System;
using System.ComponentModel.DataAnnotations;

namespace CrudProcess.Model
{
    public class CrudBase
    {
        [Key]
        public Guid Id { get; set; }
        public long Counter { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
