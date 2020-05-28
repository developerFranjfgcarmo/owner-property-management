using System;
using System.Threading.Tasks;
using OwnerPropertyManagement.Data.Context;

namespace OwnerPropertyManagement.Domain
{
    public class ServiceBase : IDisposable
    {
        public ServiceBase(IOwnerPropertyDbContext ownerPropertyDbContext)
        {
            OwnerPropertyDbContext = ownerPropertyDbContext;
        }
        public IOwnerPropertyDbContext OwnerPropertyDbContext { get; set; }

        protected bool SaveChanges()
        {
            return OwnerPropertyDbContext.SaveChanges() > 0;
        }

        protected async Task<bool> SaveChangesAsync()
        {
            return await OwnerPropertyDbContext.SaveChangesAsync() > 0;
        }

        #region [Disposable]
        ~ServiceBase()
        {
            Dispose(false);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
                OwnerPropertyDbContext.Dispose();
        }

        public void Dispose()
        {
            Dispose(false);
        }
        #endregion
       
    }
}
