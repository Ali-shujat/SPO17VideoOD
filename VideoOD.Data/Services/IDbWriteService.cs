﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoOD.Data.Services
{
    public interface IDbWriteService
    {
        Task<bool> Add<TEntity>(TEntity item) where TEntity : class;

        Task<bool> Delete<TEntity>(TEntity item) where TEntity : class;

        Task<bool> Update<TEntity>(TEntity item) where TEntity : class;

        Task<bool> Update<TEntity>(TEntity originalItem, TEntity updatedItem) where TEntity : class;
    }
}
