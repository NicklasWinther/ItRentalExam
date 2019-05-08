using ItRental.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ItRental.Dal
{
    public class RenterRepository : BaseRepository
    {
        public List<Renter> GetRenters()
        {
            string sql = $"SELECT * FROM Renters";
            return HandleData(ExecuteQuery(sql));
        }

        private List<Renter> HandleData(DataTable dataTable)
        {
            List<Renter> renters = new List<Renter>();
            if (dataTable is null)
                return renters;

            foreach (DataRow row in dataTable.Rows)
            {
                Renter renter = new Renter()
                {
                    Id = (int)row["RenterId"],
                    Name = (string)row["Name"],
                    RenterLevel = (RenterLevel)row["RenterLevel"]
                };
                renters.Add(renter);
            }
            return renters;
        }

        public void AddRenter(Renter newRenter)
        {
            string sql = $"INSERT INTO Renters VALUES('{newRenter.Name}', '{(int)newRenter.RenterLevel}')";
            ExecuteNonQuery(sql);
        }

        internal Renter GetRenter(int id)
        {
            string sql = $"SELECT * FROM Renters WHERE RenterId = {id}";
            return HandleData(ExecuteQuery(sql))[0];
        }

        public List<Renter> SearchRenters(string nameSearch)
        {
            string sql = $"SELECT * FROM Renters WHERE Name LIKE '%{nameSearch}%'";
            return HandleData(ExecuteQuery(sql));
        }
    }
}
