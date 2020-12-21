using _01.Framework.Domain;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.UM.Domain
{
    public interface IUsersRepository : IRepository<long, User>
    {
        Dictionary<long, List<UsersViewModel>> Search(UsersViewModel command = null);
        void Save();
        UsersViewModel GetDetails(long id);
        User GetByUsername(string username);
    }
}
