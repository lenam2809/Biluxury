using System;

namespace BILUXURY.Models
{
    [Serializable]
    public class CartItem
    {
        public SANPHAM SanPham { get; set; }
        public int SoLuong { get; set; }
    }
}