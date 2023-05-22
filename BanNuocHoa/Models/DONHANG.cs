namespace BanNuocHoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
        }

        [Key]
        public int Donhang_ID { get; set; }

        public int? Nguoidung_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Donhang_ngaydat { get; set; }

        [StringLength(250)]
        public string Donhang_ten { get; set; }

        [StringLength(250)]
        public string Donhang_diachi { get; set; }

        [StringLength(250)]
        public string Donhang_sdt { get; set; }

        [StringLength(250)]
        public string Donhang_ghichu { get; set; }

        public decimal? Donhang_giatien { get; set; }

        public int? Sanpham_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
