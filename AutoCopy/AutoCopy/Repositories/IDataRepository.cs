using AutoCopy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoCopy.Repositories
{
    public interface IDataRepository
    {
        /// <summary>
        /// 记录操作履历
        /// </summary>
        /// <param name="history"></param>
        Task InsertCopyHistory(CopyHistory history);

        /// <summary>
        /// 查找操作履历
        /// </summary>
        /// <param name="lines">查找条数</param>
        /// <returns></returns>
        List<CopyHistory> GetCopyHistories(int lines = 10);
    }
}
