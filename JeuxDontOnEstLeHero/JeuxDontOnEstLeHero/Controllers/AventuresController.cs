using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using JeuxDontOnEstLeHero.Core.data;
using JeuxDontOnEstLeHero.Core.Data;
using Microsoft.AspNetCore.Mvc;

namespace JeuxDontOnEstLeHero.Controllers
{
    public class AventuresController : Controller
    {
        #region Props
        
        private readonly DefaultContext _defaultContext = null;

        #endregion

        #region Constructeur
        public AventuresController(DefaultContext context)
        {
            this._defaultContext = context;
        }
        #endregion


        public IActionResult Index()
        {
            this.ViewBag.MonTitre = "Aventures";

            var query = from item in this._defaultContext.Aventure select item;

            return View(query.ToList());
        }
                
    }
}