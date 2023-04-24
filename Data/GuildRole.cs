namespace Hubnob.Data
{
    public class GuildRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GuildId { get; set; }
        public Guild Guild { get; set; }

        public virtual ICollection<GuildMember> GuildMembers { get; set; }
    }
}
