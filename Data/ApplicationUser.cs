using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hubnob.Data
{
    public class ApplicationUser : IdentityUser
    {
        // Custom properties
        public string DisplayName { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string WebsiteUrl { get; set; } = string.Empty;


        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public string ProfileImageUrl { get; set; } // プロフィール画像
        public string HeaderImageUrl { get; set; } // ヘッダー画像

        // Navigation properties
        public virtual ICollection<GuildMember> GuildMemberships { get; set; }

        // GuildMaster navigation property if needed
        //public virtual ICollection<Guild> OwnedGuilds { get; set; }

        public virtual ICollection<UserFollower> Followers { get; set; }
        public virtual ICollection<UserFollower> Following { get; set; }
    }
}
