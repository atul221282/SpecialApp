using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialApp.Entity.Composer
{
    public class ActiveEntity<T> where T : IBaseEntity
    {

        private IEnumerable<T> Entities { get; }

        public ActiveEntity(IEnumerable<T> entity)
        {
            this.Entities = entity;
        }

        public IEnumerable<T> GetActive()
        {
            return Entities.Where(x => !x.IsDeleted.Value);
        }
    }
}
