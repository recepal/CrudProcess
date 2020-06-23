using System;
using System.Collections.Generic;
using System.Text;

namespace CrudProcess.Model
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
