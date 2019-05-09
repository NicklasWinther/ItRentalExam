using ItRental.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ItRental.Dal
{
    public class RentalRepository : BaseRepository
    {
        public List<Rental> GetAllRentals()
        {
            string sql = $"SELECT * FROM Rentals";
            return HandleData(ExecuteQuery(sql));
        }

        public List<Rental> GetRentalsFor(int id)
        {
            string sql = $"SELECT * FROM Rentals WHERE RenterId = {id}";
            return HandleData(ExecuteQuery(sql));
        }

        private List<Rental> HandleData(DataTable dataTable)
        {
            EquipmentRepository equipmentRepository = new EquipmentRepository();
            RenterRepository renterRepository = new RenterRepository();
            List<Rental> rentals = new List<Rental>();
            if (dataTable is null)
                return rentals;
            
            foreach (DataRow row in dataTable.Rows)
            {
                Rental rental = new Rental()
                {
                    Id = (int)row["RentalId"],
                    RentalTime = (DateTime)row["RentalTime"],
                    ReturnTime = (DateTime)row["ReturnTime"],
                    Units = (int)row["Units"],
                    Equipment = equipmentRepository.GetEquipment((int)row["EquipmentId"]),
                    Renter = renterRepository.GetRenter((int)row["RenterId"])
            };
                rentals.Add(rental);
            }
            return rentals;
        }

        public void CreateRental(Rental rental)
        {
            string sql = $"INSERT INTO Rentals VALUES('{rental.RentalTime.ToString("yyyy-MM-dd")}', '{rental.ReturnTime.ToString("yyyy-MM-dd")}', '{rental.Equipment.Id}', '{rental.Units}', '{rental.Renter.Id}')";
            ExecuteNonQuery(sql);
        }
    }
}
