



namespace Common.Entities
{
    public class SanPhammodel
    {
        
        public int? Id { get; set; }
        public string? TenSanPham { get; set; }
        public double? DonGia { get; set; }
     

        public float? KhuyenMai { get; set; }
        public double? GiaBan { get; set; }
        public string? Anh { get; set; }
        public int? TrangThai { get; set; }
        public string GetTrangThai { get
            {
                if (TrangThai == 0)
                {
                    return "Đang được tiêu thụ";
                }
                else
                {
                    return "Đã dừng bán";
                }

            }}
        public string? MoTa { get; set; }
        public string? LoaiSp { get; set; }
        public string? Hang { get; set; }
        public int? SoLuong { get; set; }
        public string? Kho { get; set; } 
        public int? IdKho { get; set; }

    }
}
