namespace DoAnLapTrinhWindows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INVOICE_DETAILS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_BOOK { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_USER { get; set; }

        public DateTime? BUY_DATE { get; set; }

        public int? BUY_QUANTITY { get; set; }

        public int? TOTAL { get; set; }

        public virtual BOOK BOOK { get; set; }

        public virtual USER_ACCOUNT USER_ACCOUNT { get; set; }
    }
}
