using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using SQLite;
using Texas_Ranger_App.Models;

namespace Texas_Ranger_App.Data
{
    public class ReservationDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ReservationDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Reservation>().Wait();
        }

        public Task<List<Reservation>> GetReservationsAsync()
        {
            return _database.Table<Reservation>().ToListAsync();
        }

        public Task<Reservation> GetReservationAsync(int id)
        {
            return _database.Table<Reservation>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveReservationAsync(Reservation reservation)
        {
            if (reservation.ID != 0)
            {
                return _database.UpdateAsync(reservation);
            }
            else
            {
                return _database.InsertAsync(reservation);
            }
        }

        public Task<int> DeleteReservationAsync(Reservation reservation)
        {
            return _database.DeleteAsync(reservation);
        }

    }
}
