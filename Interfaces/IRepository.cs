﻿using BackendOncologia.Entities;

namespace BackendOncologia.Interfaces
{
    public interface IRepository<T> where T : Entidade
    {
        IList<T> GetAll();
        T GetById(int id);
        void Add(T entidade);
        void Update(T entidade);
        void Delete(int id);
    }
}
