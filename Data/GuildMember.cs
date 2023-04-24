using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hubnob.Data
{
    public class GuildMember
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Guild")]
        public int GuildId { get; set; }

        [Required]
        [Display(Name = "User")]
        public string UserId { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        [Display(Name = "Join Date")]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        // Navigation properties
        [ForeignKey("GuildId")]
        public virtual Guild Guild { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public int GuildRoleId { get; set; }
        public GuildRole GuildRole { get; set; }
    }
}
