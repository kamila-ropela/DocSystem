using DocSystem.Models;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class ResultTable
    {
        public static List<Result> GetDataByTestIdAndName(int testId, string name)
        {
            return Properties.dbContext.GetResultDb($@"SELECT *
                                                        FROM Result
                                                        WHERE Name = '{name}' 
                                                        AND TestId = {testId}");
        }
    }
}
