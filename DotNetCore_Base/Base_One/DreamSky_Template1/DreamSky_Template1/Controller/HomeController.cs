using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamSky_Template1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DreamSky_Template1.Controller
{
    public class HomeController 
    {
        private readonly IStudentInterface _studentInterface;
        //使用构造函数的方法注入IStudentInterface
        public HomeController(IStudentInterface studentInterface) {
            _studentInterface = studentInterface;
        }
        // GET: /<controller>/
        public string Index()
        {
            return _studentInterface.GetStudent(1).Name;
        }
    }
}
