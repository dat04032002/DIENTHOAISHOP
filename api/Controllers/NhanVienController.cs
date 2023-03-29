using Common.Entities;
using api.Soure_Data;
using Microsoft.AspNetCore.Mvc;
using api.RepositoryInterface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienRepository _repository;
        public NhanVienController(INhanVienRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<NhanVienController>
        [HttpGet]
        public ActionResult< IEnumerable<NhanVienmodel>> Get()
        {
            List<NhanVienmodel> nhanVienmodels = new List<NhanVienmodel>();
            nhanVienmodels=_repository.GetNhanViens();
          
                if (nhanVienmodels.Count == 0) 
                {
                    return NotFound();
                }
            
            return Ok(nhanVienmodels);
        }

        // GET api/<NhanVienController>/5
        [HttpGet("{id}")]
        public ActionResult<NhanVienmodel> Get(int id)
        {

            NhanVienmodel nhanVienmodels = new NhanVienmodel();
            nhanVienmodels=_repository.GetNhanVien(id);
           
                if (nhanVienmodels == null)
                {
                    return NotFound();
                }
           
            return Ok(nhanVienmodels);
        }

        // POST api/<NhanVienController>
   
        [HttpPost]

        public ActionResult Insert(NhanVienmodel nhanVienmodel)
        {
            bool them=_repository.InsertNhanVIen(nhanVienmodel);
            if (them)
            {
                return Ok("Thêm thành công");
            }
            return BadRequest();
        }

        [HttpGet("Loc/{nhanvien}")]

        public ActionResult<IEnumerable<NhanVienmodel>> loc([FromQuery] NhanVienmodel nhanVienmodel)
        {
            List<NhanVienmodel> a= new List<NhanVienmodel>();   
             a = _repository.Fill(nhanVienmodel);
            if (a .Count==0)
            {
                return NotFound();
            }
                
            
            return Ok(a);
        }
        // PUT api/<NhanVienController>/5
        [HttpPut]
        public ActionResult Put(int id,  NhanVienmodel nhanVienmodel)
        {

            bool them = _repository.UpdateNhanVien(nhanVienmodel);
            if (them)
            {
                return Ok("Sửa thành công");
            }
            return BadRequest();
        }

        // DELETE api/<NhanVienController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
