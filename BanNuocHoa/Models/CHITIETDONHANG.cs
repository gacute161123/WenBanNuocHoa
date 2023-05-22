namespace BanNuocHoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDONHANG")]
    public partial class CHITIETDONHANG
    {
        [Key]
        public int CT_ID { get; set; }

        public int? Donhang_ID { get; set; }

        public int? Sanpham_ID { get; set; }

        public int? CT_soluong { get; set; }

        public decimal? CT_giaban { get; set; }

        public decimal? CT_giamgia { get; set; }

        public decimal? CT_thanhtien { get; set; }

        public virtual DONHANG DONHANG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
