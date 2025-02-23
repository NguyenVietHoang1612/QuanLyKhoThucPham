namespace QuanLyKhoThucPham.Models.View_Model
{
    public class ViewModelPhieuNhap
    {
        public List<NhanVien> DSNhanVien { get; set; } = new List<NhanVien>();
        public NhanVien NhanVien { get; set; }
        public List<KhoNhap> DSKhoNhap { get; set; } = new List<KhoNhap>();
        public KhoNhap KhoNhap { get; set; }
        public List<NhaCungCap> DSNhaCungCap { get; set; } = new List<NhaCungCap>();
        public NhaCungCap NhaCungCap { get; set; }
        public PhieuNhap PhieuNhap { get; set; } = new PhieuNhap();
        public List<PhieuNhapChiTiet> DSChiTietPhieuNhap { get; set; } = new List<PhieuNhapChiTiet>();
        public List<SanPham> DSSanPham { get; set; } = new List<SanPham>();
        public SanPham SanPham { get; set; }
    }
}
