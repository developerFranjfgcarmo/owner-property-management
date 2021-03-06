﻿using System;
using System.Threading.Tasks;
using OwnerPropertyManagement.Data.Context;

namespace OwnerPropertyManagement.Domain
{
    public class DomainBase : IDisposable
    {
        public DomainBase(IOwnerPropertyDbContext ownerPropertyDbContext)
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
        ~DomainBase()
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
