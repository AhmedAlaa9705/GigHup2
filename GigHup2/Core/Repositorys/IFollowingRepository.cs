using GigHup2.Core.Models;


namespace GigHup2.Core.Repositorys
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string followid, string followingid);
    }
}