
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
        public Task<List<Tempo>> Update(Tempo t)
        {
            string sql = "Update tempo description=?, temp_min=?, temp_min=?,  Where id=?";
            return _conn.QueryAsync<Tempo>(sql, t.description, t.tempo_max, t.tempo_min, t.Id);

        }

        public Task<List<Tempo>> GetAll()
        {
            return _conn.Table<Tempo>().ToListAsync();
        }

        public Task<List<Tempo>> Search(string t)
        {

            string sql = "SELECT * FROM tempo WHERE description LIKE '%" + t + "%'";

            return _conn.QueryAsync<Tempo>(sql);
        }
    }