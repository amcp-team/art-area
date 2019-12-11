using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtArea.Web.Data.Interface
{
    public interface IFiltrableRepository
    {
        IQueryable<T> Filter<T>(Func<T,bool> predicate);
    }
}
