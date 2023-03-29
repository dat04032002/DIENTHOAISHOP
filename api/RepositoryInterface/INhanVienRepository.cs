using Common.Entities;

namespace api.RepositoryInterface
{
    public interface INhanVienRepository
    {
        List<NhanVienmodel> GetNhanViens();
        NhanVienmodel GetNhanVien(int id);
        bool UpdateNhanVien(NhanVienmodel nhanVien);
        bool InsertNhanVIen(NhanVienmodel nhanVien);
        List<NhanVienmodel> Fill(NhanVienmodel nhanVienmodel);
    }
}
