using GigHup2.Persistences.Repository;

namespace GigHup2.Core.Repositorys
{
    public interface IUnitOfWork
    {
         IGigRepository gigRepository { get;  }
         IAttenddanceRepository attenddanceRepository { get;  }
         IFollowingRepository followingRepository { get; }
         IGenreRepository genreRepository { get; }
        void Complete();
    }
}