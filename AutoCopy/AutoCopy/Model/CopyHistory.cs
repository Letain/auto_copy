using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCopy.Model
{
    [Table("copy_history")]
    public class CopyHistory
    {
        [Key]
        [Column("history_id")]
        public int HistoryId { get; set; }
        
        [Required]
        [StringLength(256)]
        [Column("file_address")]
        public string FileAddress { get; set; }

        [Column("record_datetime")]
        public DateTime RecordDateTime { get; set; }
    }
}
