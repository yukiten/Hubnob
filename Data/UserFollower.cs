namespace Hubnob.Data
{
    public class UserFollower
    {
        public string FollowerId { get; set; }
        public ApplicationUser Follower { get; set; }

        public string FollowingId { get; set; }
        public ApplicationUser Following { get; set; }
    }
}
