﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekiroApp.Controllers
{
    public class AppController: Controller
    {
        public IActionResult Index()
        {
            //throw new InvalidProgramException("Shit happens!");            
            return View();
        }
    }
}
