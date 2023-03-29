
namespace Common.Entities
{
    
    public class Khomodel
    {
       
        public int Id { get; set; }
        public string TenKho { get; set; }
        public NhanVienmodel NhanVien { get; set; }
        public ICollection<SanPhammodel> SanPhams { get; set; }
    }
}
