using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Мой_домашний_бомж
{
    public class DatabaseServiceUser
    {
        private SQLiteConnection _connection;

        public DatabaseServiceUser(string databasePath)
        {
            _connection = new SQLiteConnection(databasePath);
            _connection.CreateTable<User>();
        }
        public void CreateTables()
        {
            _connection.CreateTable<User>();
        }

        public void InsertUser(User user)
        {
            _connection.Insert(user);
        }

        public void CloseConnection()
        {
            _connection?.Close();
        }

        public User GetUserByEmail(string email)
        {
            return _connection.Table<User>().FirstOrDefault(u => u.Email == email);
        }

      

        public void UpdateUser(User user)
        {
            _connection.Update(user);
        }
        public void DeleteUserByEmail(string email)
        {
            var user = GetUserByEmail(email);
            if (user != null)
            {
                _connection.Delete<User>(user.Email);
            }
        }
    }

    public class User
    {
        [PrimaryKey]
        public string Email { get; set; }
        public string Password { get; set; }
        public string MailCode { get; set; }
        public string UserName { get; set; }

    }
}
