using Microsoft.EntityFrameworkCore;
using SpecialApp.Entity;

namespace SpecialApp.Repository.Helpers
{
    public static class DbContextExtension
    {
        /// <summary>
        /// Manages DbContext entities state
        /// </summary>
        /// <param name="dbContext">The specified dbcontext</param>
        public static void ApplyStateChange(this DbContext dbContext)
        {
            foreach (var entry in dbContext.ChangeTracker.Entries<IObjectWithState>())
            {
                var stateInfo = entry.Entity;
                entry.State = StateHelpers.ConvertsState(stateInfo.State);
            }
        }
    }

    public class StateHelpers
    {
        public static EntityState ConvertsState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;

                case State.Modified:
                    return EntityState.Modified;

                case State.Deleted:
                    return EntityState.Deleted;

                default:
                    return EntityState.Unchanged;
            }
        }
    }
}