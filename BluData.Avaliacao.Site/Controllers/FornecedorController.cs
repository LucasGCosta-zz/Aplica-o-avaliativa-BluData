﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BluData.Avaliacao.Site.Controllers
{
    public class FornecedorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}