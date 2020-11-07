using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }

        // This line is important otherwise AppUserId in this table will be NULL in migration. No Cascade without this.
        // AppUserId = table.Column<string>(type: "TEXT", nullable: false),   onDelete: ReferentialAction.Cascade

        [Key, ForeignKey("AppUser")]  
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }  
    }
}