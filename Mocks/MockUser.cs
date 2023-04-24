namespace labrob1.Mocks;

using System;
using System.Linq;
using System.Collections.Generic;
using labrob1.Interfaces;
using labrob1.Models;

public class MockUser : IUsers
{
    public List<User> Users {
        get {
            return new List<User> {
                new User { id = 1, name = "Mykola", surname = "Yehorov", skillage = 6 },
                new User { id = 2, name = "Ivan", surname = "Ivanov", skillage = 2 }
            };
        }

        set {
            
        }
    }
}