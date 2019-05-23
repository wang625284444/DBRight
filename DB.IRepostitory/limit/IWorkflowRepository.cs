using DB.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.IRepository.limit
{
    public interface IWorkflowRepository<T>: IBaseRepository<T>where T : class
    {
    }
}
