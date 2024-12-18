namespace DoAnLapTrinhWindows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER_ACCOUNT()
        {
            INVOICE_DETAILS = new HashSet<INVOICE_DETAILS>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_USER { get; set; }

        [StringLength(20)]
        public string USERNAME { get; set; }

        [StringLength(20)]
        public string PASSWORD1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICE_DETAILS> INVOICE_DETAILS { get; set; }
    }
}
