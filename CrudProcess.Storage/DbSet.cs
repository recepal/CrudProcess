using CrudProcess.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudProcess.Storage
{
    partial class CrudContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
