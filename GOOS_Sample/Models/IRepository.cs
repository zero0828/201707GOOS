using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOOS_Sample.DataModels;

namespace GOOS_Sample.Models
{
    public interface IRepository<T>
    {
        void Save(T entity);
    }
}
