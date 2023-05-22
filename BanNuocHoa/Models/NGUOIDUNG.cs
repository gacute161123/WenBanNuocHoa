namespace BanNuocHoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOIDUNG()
        {
            DONHANGs = new HashSet<DONHANG>();
            PHANQUYENs = new HashSet<PHANQUYEN>();
        }

        [Key]
        public int Nguoidung_ID { get; set; }

        [StringLength(250)]
        public string Nguoidung_user { get; set; }

        [StringLength(250)]
        public string Nguoidung_pass { get; set; }

        [StringLength(250)]
        public string Nguoidung_hoten { get; set; }

        [StringLength(250)]
        public string Nguoidung_dienthoai { get; set; }

        [StringLength(250)]
        public string Nguoidung_email { get; set; }

        public bool? Nguoidung_trangthai { get; set; }

        [StringLength(250)]
        public string Nguoidung_ghichu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANQUYEN> PHANQUYENs { get; set; }
    }
}
