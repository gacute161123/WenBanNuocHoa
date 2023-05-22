namespace BanNuocHoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
            DONHANGs = new HashSet<DONHANG>();
        }

        [Key]
        public int Sanpham_ID { get; set; }

        [StringLength(250)]
        public string Sanpham_ten { get; set; }

        [Column(TypeName = "ntext")]
        public string Sanpham_mota { get; set; }

        public decimal? Sanpham_gia { get; set; }

        public int? Sanpham_soluong { get; set; }

        [StringLength(2000)]
        public string Sanpham_anh { get; set; }

        [StringLength(2000)]
        public string Sanpham_giohang { get; set; }

        public int Theloai_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }

        public virtual THELOAI THELOAI { get; set; }
    }
}
