using AutoMapper;
using CrudProcess.Model;
using CrudProcess.Storage;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrudProcess.Service.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private CrudRepository<Student> repo;
        private IMapper _mapper;
        public CrudController(IMapper mapper)
        {
            repo = new CrudRepository<Student>();
            _mapper = mapper;
        }

        [HttpGet("createDatabase")]
        public ActionResult CreateDatabase()
        {
            bool result = repo.CreateDb();

            string message = result ? "Aferin oluşturuldu db..." : "Malesef.Tekrar deneyiniz...";
            return Ok(message);
        }

        [HttpPost("insert")]
        public async Task<ActionResult> Insert(StudentDto studentDto)
        {
            Student student = _mapper.Map<Student>(studentDto);
            bool result = await repo.Insert(student);
            string message = result ? "Kayıt tamamlandı" : "Kayıt tamamlanmadı..";
            return Ok(message);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(StudentDto studentDto)
        {
            Student student = await repo.GetById(studentDto.Id);
            _mapper.Map(studentDto, student);

            bool result = await repo.Update(student);
            string message = result ? "Kayıt tamamlandı" : "Kayıt tamamlanmadı..";
            return Ok(message);
        }
    }
}
