using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeuxDontOnEstLeHero.Core.Data;
using JeuxDontOnEstLeHero.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace JeuxDontOnEstLeHero.BackOffice.Web.UI.Controllers
{
    public class QuestController : Controller
    {

        #region Consttructeur
        public QuestController(DefaultContext context )
        {
            this._defaultContext = context;
        }

        #endregion

        #region Props Private

        private readonly DefaultContext _defaultContext = null;
        private Quest _questToDelete = null;
        #endregion

        #region Méthodes public

        #region Create
        /// <summary>
        /// GET - Méthode appelée pour aller à la saisie du formulaire
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST - Méthode appelée à la suite de la validation du formulaire
        /// </summary>
        /// <param name="quest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Quest quest)
        {
            this._defaultContext.Quest.Add(quest);
            this._defaultContext.SaveChanges();

            return View("List", this._defaultContext.Quest);
        }

        #endregion

        #region Update
        /// <summary>
        /// GET - Méthode appelée pour aller à la saisie du formulaire
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int id)
        {

            Quest questUpdate = null;

            questUpdate = this._defaultContext.Quest.First(x => x.Id == id);
   

            return View(questUpdate);
        }

        /// <summary>
        /// POST - Méthode appelée à la suite de la validation du formulaire
        /// </summary>
        /// <param name="quest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Quest quest)
        {
            // Modification d'un seul champ
            //this._defaultContext.Attach<Quest>(quest);
            //this._defaultContext.Entry(quest).Property(item => item.Title).IsModified = true;

            // Modification de tous les champs
            this._defaultContext.Quest.Update(quest);
            this._defaultContext.SaveChanges();

            return View("List", this._defaultContext.Quest);
        }
        #endregion

        #region Delete
        /// <summary>
        /// GET - Méthode appelée pour aller à la saisie du formulaire
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            
            Quest quest = null;

            quest = this._defaultContext.Quest.First(x => x.Id == id);
            this._questToDelete = quest;

            return View(quest);
        }

        /// <summary>
        /// POST - Méthode appelée à la suite de la validation du formulaire
        /// </summary>
        /// <param name="quest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete()
        {
            // Suppression de l'enregistrement
            this._defaultContext.Quest.Remove(this._questToDelete);
            this._defaultContext.SaveChanges();
            
            return View("List", this._defaultContext.Quest);
        }
        #endregion


        public IActionResult List()
        {
            return View(this._defaultContext.Quest);
        }

        #endregion


    }
}