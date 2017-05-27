using SpecialApp.Entity.CommonContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialApp.Entity.Composer
{
    public class ActiveOnlyEntity<T> where T : IActiveOnlyEntity
    {

        private IEnumerable<T> Entities { get; }

        public ActiveOnlyEntity(IEnumerable<T> entity)
        {
            this.Entities = entity;
        }

        public IEnumerable<T> GetActive()
        {
            return Entities.Where(x => !x.IsDeleted.Value);
        }
    }
}
