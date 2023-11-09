using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using GuardarImagen.Models;

namespace GuardarImagen.Controllers
{
    public class Database
    {
        readonly  SQLiteAsyncConnection _connection;

        public Database()
        {

        }
        public Database(string path)
        {
            try
            {
                _connection = new SQLiteAsyncConnection(path);
                _connection.CreateTableAsync<Images>().Wait();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public Task<List<Images>> getImages()
        {
            return _connection.Table<Images>().ToListAsync();
        }

        public Task<int> addImage(Images image) { 
            if(image.id == 0)
            {
                return _connection.InsertAsync(image);
            }
            else
            {
                return _connection.UpdateAsync(image);
            }
        }
    }
}
