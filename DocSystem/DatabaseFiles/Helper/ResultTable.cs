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
        public static List<Result> AddResults(Result result)
        {
            return Properties.dbContext.GetResultDb($@"INSERT INTO Result (TestId, Name, Unit, Value) 
                                                     VALUES (" + result.TestId + ",'" + result.Name + "','" +
                                                     result.Unit + "'," + result.Value + ");");
        }
        public static void InsertData(Result result)
        {
            Properties.dbContext.ExecuteQuery($@"INSERT INTO Result (TestId, Name, Unit, Value) 
                                                     VALUES (" + result.TestId + ",'" + result.Name + "','" +
                                                     result.Unit + "'," + result.Value + ");");
        }
    }
}
