using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repository;
using System.Configuration;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            var context = new ApiDbContext(ConnectionString);
            IRpository<User> _userRepo = new EfRepository<User>(context);

            _userRepo.Add(new User { FirstName = "Madhav", LastName = "Shenoy", EmailId = "mshenoy83@gmail.com", Password = "123test" });

            var list = _userRepo.Table;
        }
    }
}
