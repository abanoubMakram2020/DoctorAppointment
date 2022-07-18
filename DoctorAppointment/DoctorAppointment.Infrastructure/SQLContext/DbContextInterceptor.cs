using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Infrastructure.SQLContext
{
    public class DbContextInterceptor : SaveChangesInterceptor
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {

            //Send email to client 

            return base.SavedChanges(eventData, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            //Send email to client 
            return base.SavingChanges(eventData, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = new CancellationToken())
        {
            //Send email to client 
            Console.WriteLine(eventData.Context.ChangeTracker.DebugView.LongView);
            base.SavingChangesAsync(eventData, result);
            return new ValueTask<InterceptionResult<int>>(result);
        }
    }
}
