using System;
using System.Collections.Generic;
using System.Text;
using TrackingSystem.BLL.Models;

namespace TrackingSystem.BLL.Interfaces
{
    public interface IServices<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T t);
        void Delete(T t);
        void Update(T t);
     
    }
}
