using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingSystem.DAL.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetAllUserId(int userid);
        List<T> GetAllProjectId(int projectid);
    }
}
