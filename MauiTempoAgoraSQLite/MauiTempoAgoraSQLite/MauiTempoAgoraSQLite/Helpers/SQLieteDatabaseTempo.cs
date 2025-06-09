
using SQLite;
using MauiTempoAgoraSQLite.Models;



namespace MauiTempoAgoraSQLite.Helpers //
{
    public class SQLiteDatabasetempo
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseTempo(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Tempo>().Wait();


        }

        public Task<int> Insert(Tempo t)
        {
            return _conn.InsertAsync(t);

        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Tempo>().DeleteAsync(i => i.Id == id);
        }
        public Task<int> DeleleteAll()
        {
            return _conn.DeleteAllAsync<Tempo>();
        }

        public Task<List<Tempo>> GetAll()
        {
            return _conn.Table<Tempo>().ToListAsync();
        }

        public Task<List<Tempo>> Search(string q)
        {
            string sql = "SELECT * FROM Tempo " +
                         "WHERE description LIKE '%" + q + "%'";

            return _conn.QueryAsync<Tempo>(sql);
        }
    }
}