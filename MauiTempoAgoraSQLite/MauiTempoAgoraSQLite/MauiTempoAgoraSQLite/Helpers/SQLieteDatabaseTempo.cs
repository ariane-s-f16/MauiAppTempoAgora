using compras.Models; //
using SQLite;

namespace compras.Helpers //
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();


        }

        public Task<int> Insert(tempo t)
        {
            return _conn.InsertAsync(t);

        }
        public Task<int> Delete(int id)
        {
            return _conn.Table<Tempo>().DeleteAsync(i => i.Id == id);
        }
        public Task<List<tempo>> Update(Tempo t)
        {
            string sql = "Update tempo description=?, temp_min=?, temp_min=?,  Where id=?";
            return _conn.QueryAsync<Produto>(sql, t.description, t.tempo_min, t.tempo_min, t.Id);

        }

        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Tempo>().ToListAsync();
        }

        public Task<List<Tempo>> Search(string t)
        {

            string sql = "SELECT * FROM tempo WHERE description LIKE '%" + t + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }
    }