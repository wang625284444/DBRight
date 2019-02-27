using DB.Entity.Assistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.UnitOfWork
{
    public interface IWorkServices
    {
        void GetEntityUpdate<TEntity>(Guid guid) where TEntity : WorkflowEntity, new();

    }
}
