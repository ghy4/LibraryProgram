﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace Database.Services.Interfaces
{
    public interface IService<T>
    {
        public Task<ICollection<T>> GetAll();
        public Task<T?> GetById(int id);
        public Task<bool> RemoveById(int id);
        public Task<bool> Create(T entity);
        public Task<bool> Update(T entity);
    }
}
