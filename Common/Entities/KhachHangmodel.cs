

namespace Common.Entities
{
  
    public class KhachHangmodel
    {
       
        public string SDT { get; set; }
        public string TenKH { get; set;}
        public string DiaChi { get; set;}
        public ICollection<DonHangmodel> donHangs { get; set; }
    }
}
