using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using QuanLyKhoThucPham.Models;

namespace QuanLyKhoThucPham.Services
{
    public class InPDF
    {
        public PdfDocument GeneratePhieuNhapPdf(PhieuNhapModel phieuNhap, List<PhieuNhapChiTietModel> chiTietPhieuNhap)
        {
            var document = new Document();
            var section = document.AddSection();

            // Tiêu đề
            var title = section.AddParagraph("PHIẾU NHẬP KHO");
            title.Format.Font.Size = 16;
            title.Format.Font.Bold = true;
            title.Format.SpaceAfter = 10;

            // Thông tin phiếu nhập
            section.AddParagraph($"Mã phiếu nhập: {phieuNhap.MaPhieuNhap}");
            section.AddParagraph($"Ngày nhập: {phieuNhap.NgayNhap:dd/MM/yyyy}");
            section.AddParagraph($"Nhân viên nhập: {phieuNhap.NhanVien?.HoTen}");
            section.AddParagraph($"Nhà cung cấp: {phieuNhap.NhaCungCap?.TenNhaCungCap}");
            section.AddParagraph($"Kho hàng: {phieuNhap.KhoHang?.TenKho}");
            section.AddParagraph($"Tổng tiền: {phieuNhap.TongTien:C}");
            section.AddParagraph().Format.SpaceAfter = 20;

            // Bảng danh sách sản phẩm nhập
            var table = section.AddTable();
            table.Borders.Width = 0.5;
            table.AddColumn("5cm");
            table.AddColumn("3cm");
            table.AddColumn("3cm");
            table.AddColumn("3cm");

            var row = table.AddRow();
            row.Cells[0].AddParagraph("Sản phẩm");
            row.Cells[1].AddParagraph("Số lượng");
            row.Cells[2].AddParagraph("Đơn giá");
            row.Cells[3].AddParagraph("Thành tiền");

            foreach (var item in chiTietPhieuNhap)
            {
                row = table.AddRow();
                row.Cells[0].AddParagraph(item.SanPham?.TenSP);
                row.Cells[1].AddParagraph(item.SoLuong.ToString());
                row.Cells[2].AddParagraph($"{item.DonGia:C}");
                row.Cells[3].AddParagraph($"{item.TongTIen:C}");
            }

            var pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();

            return pdfRenderer.PdfDocument;
        }

    }
}
