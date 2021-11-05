﻿using Obligatorio.Domain.Model;
using System.Collections.Generic;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IPostsRepository : IRepository<Publicacion>
    {
        ICollection<Publicacion> ListForFeed(int ciActiveUser);
        ICollection<Publicacion> FilterByName(string name, int ciActiveUser);
        ICollection<Publicacion> ListActivePosts(int ciActiveUser);
    }
}
