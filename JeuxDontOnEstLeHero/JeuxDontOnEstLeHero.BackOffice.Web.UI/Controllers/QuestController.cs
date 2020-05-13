using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeuxDontOnEstLeHero.Core.Data;
using JeuxDontOnEstLeHero.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        #endregion

        #region Méthodes public

        #region Create
        /// <summary>
        /// GET - Méthode appelée pour aller à la saisie du formulaire
        /// </summary>
        /// <returns></returns>
        public  IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST - Méthode appelée à la suite de la validation du formulaire
        /// </summary>
        /// <param name="quest"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Quest quest)
        {
            if(ModelState.IsValid)
            {
                this._defaultContext.Quest.Add(quest);
                await this._defaultContext.SaveChangesAsync();

                return RedirectToAction(nameof(List));
            }

            return View(quest);
        }

        #endregion

        #region Update
        /// <summary>
        /// GET - Méthode appelée pour aller à la saisie du formulaire
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Update(int id)
        {
            Quest questUpdate = await this._defaultContext.Quest.FindAsync(id);

            if (questUpdate == null)
            {
                return NotFound();
            }

            return View(questUpdate);
        }

        /// <summary>
        /// POST - Méthode appelée à la suite de la validation du formulaire
        /// </summary>
        /// <param name="quest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(Quest questUpdate)
        {
            // Modification d'un seul champ
            //this._defaultContext.Attach<Quest>(quest);
            //this._defaultContext.Entry(quest).Property(item => item.Title).IsModified = true;

            // Modification de tous les champs
            if (ModelState.IsValid)
            {
                this._defaultContext.Quest.Update(questUpdate);
                await this._defaultContext.SaveChangesAsync();

                return RedirectToAction(nameof(List));

            }

            return View(questUpdate);
        }
        #endregion

        #region Delete
        /// <summary>
        /// GET - Méthode appelée pour aller à la saisie du formulaire
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {

            Quest quest = await this._defaultContext.Quest.FirstOrDefaultAsync(x => x.Id == id);

            if (quest == null)
            {
                return NotFound();
            }

            return View(quest);
        }

        /// <summary>
        /// POST - Méthode appelée à la suite de la validation du formulaire
        /// </summary>
        /// <param name="quest"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Quest quest = await this._defaultContext.Quest.FindAsync(id);
            // Suppression de l'enregistrement

            this._defaultContext.Quest.Remove(quest);
            await this._defaultContext.SaveChangesAsync();
            
            return RedirectToAction(nameof(List));
        }
        #endregion


        public async Task<IActionResult> List()
        {
            return View(await this._defaultContext.Quest.ToListAsync());
        }

        #endregion


    }
}