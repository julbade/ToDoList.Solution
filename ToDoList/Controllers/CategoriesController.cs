using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    [HttpGet("/categories")]
    public ActionResult Index()
    {
        List<Category> allCategories = Category.GetAll();
        return View("Categories", allCategories);
    }

    [HttpGet("/categories/new")]
    public ActionResult CreateForm()
    {
        return View();
    }

    [HttpPost("/categories")]
    public ActionResult Create(string categoryName)
    {
        Category newCategory = new Category(categoryName);
        newCategory.Save();
        //List<Category> allCategories = Category.GetAll();
        return RedirectToAction("Index");
    }

    [HttpGet("/categories/{id}/items")]
    public ActionResult Details(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(id);
      List<Item> categoryItems = selectedCategory.GetItems();
      model.Add("category",selectedCategory);
      model.Add("items",categoryItems);
      return View(model);
    }
    [HttpGet("/delete")]
    public ActionResult DeleteAll()
    {
      Category.DeleteAll();
      return View();
    }
  }
}
