namespace labrob1.Interfaces;

using System;
using System.Linq;
using labrob1.Models;
using System.Collections.Generic;
 
public interface IUsers {
    List<User> Users { get; set; }
}