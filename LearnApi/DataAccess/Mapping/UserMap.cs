using DataAccess.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User").HasKey(x => x.Id);
        }
    }
}
