using DocSystem.Models;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class VisitTable
    {
        public static List<Visit> GetData()
        {
            return Properties.dbContext.GetVisitDb(@"SELECT *
                                                     FROM Visit");
        }
    }
}
