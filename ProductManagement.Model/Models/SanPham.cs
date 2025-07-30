using System;
using System.Collections.Generic;

namespace ProductManagement.Model.Models
{
    public partial class SanPham
    {
        public int Id { get; set; }
        public string TenSanPham { get; set; } = null!;
        public string? MoTa { get; set; }
        public decimal Gia { get; set; }
        public int? SoLuong { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
    }
}
