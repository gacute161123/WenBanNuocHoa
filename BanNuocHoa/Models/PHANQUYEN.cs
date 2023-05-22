namespace BanNuocHoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHANQUYEN")]
    public partial class PHANQUYEN
    {
        [Key]
        public int Phanquyen_ID { get; set; }

        public int? Nguoidung_ID { get; set; }

        [StringLength(150)]
        public string Phanquyen_quyensudung { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
    }
}
