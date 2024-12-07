namespace DoAnLapTrinhWindows.Modifile
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOOK")]
    public partial class BOOK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOOK()
        {
            INVOICE_DETAILS = new HashSet<INVOICE_DETAILS>();
        }

        [Key]
        public int ID_BOOK { get; set; }

        [Required]
        [StringLength(100)]
        public string NAME_BOOK { get; set; }

        [StringLength(50)]
        public string CATEGORY { get; set; }

        [StringLength(100)]
        public string AUTHOR { get; set; }

        public int? QUANTITY { get; set; }

        [StringLength(200)]
        public string LINK_IMG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICE_DETAILS> INVOICE_DETAILS { get; set; }
    }
}
