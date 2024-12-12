using FotKlubb.Models.DomainModel;

namespace FotKlubb.Repository
{
    public interface IUsersPostRepository
    {
        Task<IEnumerable<UsersPostModel>> GetAllUserPost();
        Task<UsersPostModel> GetPostById(int? id);
        Task<UsersPostModel> AddUsersPost(UsersPostModel postModel);
        Task<UsersPostModel> UpdateUsersPost(UsersPostModel postModel);
        Task<UsersPostModel> DeleteUsersPost(int? id);

    }
}
