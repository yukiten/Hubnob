using System;
using System.ComponentModel.DataAnnotations;

namespace Hubnob.Data
{
    public class Guild
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Guild name should be between 3 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500, ErrorMessage = "Description should not exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        public string IconUrl { get; set; } = string.Empty;

        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Required]
        [Display(Name = "Guild Master")]
        public string GuildMasterId { get; set; } = string.Empty;

        // Navigation properties
        public virtual ApplicationUser GuildMaster { get; set; }
        public virtual ICollection<GuildMember> GuildMembers { get; set; }

        public virtual ICollection<GuildRole> GuildRoles { get; set; }
    }
}
