using System;
using System.Collections.Generic;
using System.Linq;
using labrob1.Interfaces;
using labrob1.Models;
using Microsoft.AspNetCore.Mvc;

namespace labrob1.Controllers;

public class UsersController : Controller {
    private readonly IUsers _users;

    public UsersController(IUsers users) {
        _users = users;
    }

    [Route("users")]
    public ViewResult List() {
        var users = _users.Users;
        return View(users);
    }

    [HttpGet]
    [Route("/users/add")]
    public ViewResult Add() {
        return View();
    }

    [HttpPost]
    [Route("/users/add")]
    public RedirectToActionResult Add(User user) {
        List<User> users = _users.Users;
        users.Add(user);

        _users.Users = users;
        return RedirectToAction("List");
    }

    [HttpPost]
    [Route("/users/clear")]
    public RedirectToActionResult Clear() {
        List<User> users = _users.Users;
        users.Clear();

        _users.Users = users;
        return RedirectToAction("List");
    }
}