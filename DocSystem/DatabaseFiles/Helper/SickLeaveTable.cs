using DocSystem.Models;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class SickLeaveTable
    {
        public static List<SickLeave> GetData()
        {
            return Properties.dbContext.GetSickLeaveDb(@"SELECT *
                                                         FROM SickLeave");
        }
    }
}
