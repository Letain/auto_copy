using AutoCopy.Models;
using AutoCopy.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCopy.Repositories
{
    public class DataRepository : IDataRepository
    {
        public async Task InsertCopyHistory(CopyHistory history)
        {
            using (var context = new MyWinformDemoDbContext(CommonUtil.DbConnectionString))
            {
                context.CopyHistory.Add(history);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 100条以内的履历查找
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public List<CopyHistory> GetCopyHistories(int lines = 10)
        {
            using (var context = new MyWinformDemoDbContext(CommonUtil.DbConnectionString))
            {
                return context.CopyHistory.OrderByDescending(c => c.HistoryId).Take(lines > 0 ? (lines < 100 ? lines : 10) : 10).ToList();
            }
        }

    }
}
