using Common.Entities;
using api.Soure_Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SanPhamController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<IComparable<SanPhammodel>> GetSanPhams() {
            List<SanPhammodel> sanPhammodels = new List<SanPhammodel>();
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);
            if (con != null)
            {
                if (con._OpenConnection())
                {
                    sanPhammodels = con.GetAll_SanPham();
                }
            }

            return Ok(sanPhammodels);
        }
        [HttpGet("LocSanpham")]
        public ActionResult<IComparable<SanPhammodel>> Loc([FromQuery] SanPhammodel sanPhammodel)
        {
            List<SanPhammodel> sanPhammodels = new List<SanPhammodel>();
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);
            if (con != null)
            {
                if (con._OpenConnection())
                {
                    sanPhammodels = con.Fill_SanPham(sanPhammodel);
                }
            }

            return Ok(sanPhammodels);
        }

        [HttpGet("tatcasanpham")]
        public ActionResult<IComparable<SanPhammodel>> GetSanPham()
        {
            List<SanPhammodel> sanPhammodels = new List<SanPhammodel>();
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);
            if (con != null)
            {
                if (con._OpenConnection())
                {
                    sanPhammodels = con.GetAll_SanPhams();
                }
            }

            return Ok(sanPhammodels);
        }

        /*        [HttpGet("hang")]
                public ActionResult<IComparable<SanPhammodel>> GetSanPhams(string hang)
                {
                    List<SanPhammodel> sanPhammodels = new List<SanPhammodel>();
                    string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
                    Connext con = new Connext(connstr);
                    if (con != null)
                    {
                        if (con._OpenConnection())
                        {
                            sanPhammodels = con.GetAll_SanPham_ByHang(hang);
                        }
                    }

                    return Ok(sanPhammodels);
                }*/
        [HttpGet("{id}")]
        public ActionResult GetSanPham(int id)
        {
            SanPhammodel sanPhammodel = new SanPhammodel();
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);

            if (con != null)
            {
                if (con._OpenConnection())
                {
                    sanPhammodel = con.GetAll_SanPham_ByID(id);
                    if (sanPhammodel.Id != id)
                    {
                        return BadRequest();
                    }
                }
            }
            return Ok(sanPhammodel);
        }
        [HttpPost]

        public ActionResult Insert( SanPhammodel sanPhammodel)
        {

            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);

            if (con != null)
            {
                if (con._OpenConnection())
                {
                    var a = con.Them_SanPham(sanPhammodel);
                    if (a == false)
                    {
                        return Ok("Thêm thất bại");
                    }
                }
            }
            return Ok("Thêm thành công");
        }
        [HttpPut]

        public ActionResult Put(SanPhammodel sanPhammodel)
        {
          
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);

            if (con != null)
            {
                if (con._OpenConnection())
                {
                    var a = con.Sua_SanPham(sanPhammodel);
                    if (a == false)
                    {
                        return BadRequest();
                    }
                }
            }
            return Ok(sanPhammodel);
        }
        [HttpPut("Xoa/{id}")]
        public ActionResult Delete(int id)
        {
            int tt = 1;
        
           
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);


           
                if (con != null)
                {
                    if (con._OpenConnection())
                    {
                        var a = con.Xoa_SanPham(id, tt);
                        if (a == false)
                        {
                            return  NotFound();
                        }
                    }
                }
            
          
            return Ok("Sửa thành công");
        }
        [HttpPost("anh")]
        public async Task< IActionResult> Postanh([FromForm] IFormFile fileMode)
        {

            string pathanh;
            string fname = DateTime.Now.ToString("yyyyMMddssffff") + "." + fileMode.FileName.Split('.')[fileMode.FileName.Split('.').Length - 1];
            try {

               if(fileMode.Length>0) {
                    string path1 = Path.Combine(@"D:\Apidienthoai\webuser\src\USER\image\" + fname);
                    string path2 = Path.Combine(@"D:\Apidienthoai\Amin\Amin\image\" + fname);
               
                    using (var stream = System.IO.File.Create(path1))
                    {
                        
                        await fileMode.CopyToAsync(stream);
                        pathanh = fname;
                      
                    }
                    using (var stream2 = System.IO.File.Create(path2))
                    {
                        await fileMode.CopyToAsync(stream2);
                    }
                    return Ok(pathanh);
                }
            } catch {
                return StatusCode(101);
            }

            return StatusCode(101);
        }
    }
}
