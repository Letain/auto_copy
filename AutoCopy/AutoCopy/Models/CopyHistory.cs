using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCopy.Models
{
    /// <summary>
    /// COPY履历表
    /// </summary>
    [Table("copy_history")]
    public class CopyHistory
    {
        [Key]
        [Column("history_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryId { get; set; }
        
        [Required]
        [StringLength(256)]
        [Column("file_address")]
        public string FileAddress { get; set; }

        [Column("record_datetime")]
        public DateTime RecordDateTime { get; set; }
    }
}
