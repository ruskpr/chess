using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ChessLibrary
{
    public class LocalDataSaver
    {
        const string SAVE_PATH = "saves/local_save_data.bin";
        public LocalDataSaver()
        {

        }
        public void SavePlayerData(User p1, User p2)
        {
            List<User> localUsers = new() { p1, p2 };

            var options = new JsonSerializerOptions { WriteIndented = true };

            string json = System.Text.Json.JsonSerializer.Serialize(localUsers, options);

            File.WriteAllText(SAVE_PATH, json);
        }

        public List<User> LoadPlayerData()
        {
            if (File.Exists(SAVE_PATH)) // if file exists use that data
            {
                string json = File.ReadAllText(SAVE_PATH);

                List<User> localUsers = JsonSerializer.Deserialize<List<User>>(json);

                return localUsers;
            }
            else // use default if no file exists
            {
                return new List<User> { new User("White"), new User("Black") };
            }
            
        }

        internal void DeleteSave()
        {
            if (File.Exists(SAVE_PATH))
            {
                File.Delete(SAVE_PATH);
                MessageBox.Show("Local save data has been deleted.");
            }
            else
                MessageBox.Show("There are no local save file to delete.");
        }
    }
}
