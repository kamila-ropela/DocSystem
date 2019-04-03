using DocSystem.Models;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class PrescriptionTable
    {
        public static List<Prescription> GetData()
        {
            return Properties.dbContext.GetPrescriptionDb(@"SELECT *
                                                            FROM Prescription");
        }
    }
}
