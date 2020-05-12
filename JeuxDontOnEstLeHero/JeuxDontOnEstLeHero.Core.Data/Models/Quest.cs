using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JeuxDontOnEstLeHero.Core.Data.Models
{
    [Table("Quest")]
    public class Quest
    {
        #region Props

        /// <summary>
        /// Id de la quête
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Numéro de la quête
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Titre
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Question de la quête
        /// </summary>
        public Question Question { get; set; }

        #endregion

    }
}
