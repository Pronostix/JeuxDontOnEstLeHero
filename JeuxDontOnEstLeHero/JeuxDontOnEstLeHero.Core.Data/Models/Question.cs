using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JeuxDontOnEstLeHero.Core.Data.Models
{
    [Table("Question")]
    public class Question
    {
        #region Props

        /// <summary>
        /// Id de la question
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Référence à la classe Quest
        /// </summary>
        public int QuestId { get; set; }

        /// <summary>
        /// Titre de la question
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Liste de réponses
        /// </summary>
        public List<Answer> Answers { get; set; }
        #endregion

    }
}
