namespace labrob1.Mocks;

using System;
using System.Linq;
using System.Collections.Generic;
using labrob1.Interfaces;
using labrob1.Models;
using System.Text.Json;
using System.Text;

public class MockUser : IUsers
{
    private string _path;
    private string _file;
    
    public MockUser(IWebHostEnvironment env)
    {
        _path = env.ContentRootPath + "/db_files/";
        _file = "users.txt";
    }

    private string FullFilePath()
    {
        return _path + _file;
    }

    private void save(string data)
    {
        bool pathExists = System.IO.Directory.Exists(_path);
        if(! pathExists) {
            System.IO.Directory.CreateDirectory(_path);
        }

        string file = this.FullFilePath();
        using (FileStream fs = File.Create(file))
        {
            byte[] bytes = new UTF8Encoding(true).GetBytes(data);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
        }
    }

    public List<User> Users
    {
        get {
            if(! File.Exists(this.FullFilePath())) {
                List<User> users = new List<User> {};
                this.save(JsonSerializer.Serialize(users));
            }

            StreamReader reader = File.OpenText(this.FullFilePath());

            string read = reader.ReadLine();
            if(read != null) {
                reader.Close();
                return JsonSerializer.Deserialize<List<User>>(read);
            } else Console.Write("Error");

            reader.Close();
            return new List<User>{};
        }

        set {
            List<User> users = value;
            
            int lastId = 1;
            foreach(User user in users) {
                if(user.id == 0) user.id = lastId;
                lastId++;
            }

            this.save(JsonSerializer.Serialize(users));
        }
    }
}