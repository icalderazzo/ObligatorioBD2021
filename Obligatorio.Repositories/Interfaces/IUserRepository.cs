﻿using Obligatorio.Domain.Model;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<Usuario>
    {
        Usuario GetForLogin(string username, string password);
        bool ExistsUserWithUsername(string username, int ci);
        bool ExistsUserWithPhoneNumber(int phoneNumber, int ci);
        bool ExistsUserWithCi(int ci);
        bool ExistsUserWithEmail(string email, int ci);
    }
}
