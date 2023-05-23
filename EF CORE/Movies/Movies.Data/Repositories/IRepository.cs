﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Repositories
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);

    }
}
