using FotKlubb.Data;
using FotKlubb.Models.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace FotKlubb.Repository
{
    public class UsersPostRepository : IUsersPostRepository
    {
        private readonly AppDbContext _context;
        public UsersPostRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<UsersPostModel>> GetAllUserPost()
        {
            return await _context.UserPost.ToListAsync();
        }

        public async Task<UsersPostModel> GetPostById(int? id)
        {
            return await _context.UserPost.Where(p => p.PostId == id).FirstOrDefaultAsync();
        }

        public async Task<UsersPostModel> AddUsersPost(UsersPostModel postModel)
        {
            await _context.UserPost.AddAsync(postModel);
            await _context.SaveChangesAsync();
            return postModel;
        }

        public async Task<UsersPostModel> UpdateUsersPost(UsersPostModel postModel)
        {
            _context.UserPost.Update(postModel);
            await _context.SaveChangesAsync();
            return postModel;
        }

        public async Task<UsersPostModel> DeleteUsersPost(int? id)
        {
            var itemId = await _context.UserPost.FindAsync(id); //remember, Product_detail is the object created in the AppDBContext
            if (itemId != null)
            {
                _context.UserPost.Remove(itemId);
                await _context.SaveChangesAsync();
            }

            return null;
        }
    }
}
