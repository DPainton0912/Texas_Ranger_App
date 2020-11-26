using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using SQLite;
using Texas_Ranger_App.Models;

namespace Texas_Ranger_App.Databases
{
    public class ReservationDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ReservationDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Reservations>().Wait();
        }

        public Task<List<Reservations>> GetReservationsAsync()
        {
            return _database.Table<Reservations>().ToListAsync();
        }

        public Task<Reservations> GetReservationAsync(int id)
        {
            return _database.Table<Reservations>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveReservationAsync(Reservations reservation)
        {
            if (reservation.ID != 0)
            {
                reservation.Date = Convert.ToDateTime(reservation.Date);
                return _database.UpdateAsync(reservation);
            }
            else
            {
                reservation.Date = Convert.ToDateTime(reservation.Date);
                return _database.InsertAsync(reservation);
            }
        }

        public Task<int> DeleteReservationAsync(Reservations reservation)
        {
            return _database.DeleteAsync(reservation);
        }
    }
}
