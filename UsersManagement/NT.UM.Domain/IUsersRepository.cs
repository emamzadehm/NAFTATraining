﻿using _01.Framework.Domain;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.UM.Domain
{
    public interface IUsersRepository : IRepository<long, Users>
    {
        List<UsersViewModel> Search(UsersViewModel command);
    }
}
