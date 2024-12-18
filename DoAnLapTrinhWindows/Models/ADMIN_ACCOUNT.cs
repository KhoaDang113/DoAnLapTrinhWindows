namespace DoAnLapTrinhWindows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ADMIN_ACCOUNT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_ADMIN { get; set; }

        [StringLength(20)]
        public string ADMINNAME { get; set; }

        [StringLength(200)]
        public string PASSWORD1 { get; set; }

        public bool? EDIT { get; set; }
    }
}
