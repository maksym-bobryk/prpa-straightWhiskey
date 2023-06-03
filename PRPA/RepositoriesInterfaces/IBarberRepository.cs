﻿using PRPA.Models;

namespace PRPA.RepositoriesInterfaces
{
    public interface IBarberRepository : IRepository<Barber>
    {
        Barber Get(string email);
    }
}
