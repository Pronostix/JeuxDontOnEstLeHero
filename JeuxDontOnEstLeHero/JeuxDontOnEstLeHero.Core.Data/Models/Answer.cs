using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JeuxDontOnEstLeHero.Core.Data.Models
{
    [Table("Answer")]
    public class Answer
    {
        #region Props

        /// <summary>
        /// Id de la question
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Description de la réponse
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int QuestionId { get; set; }
        #endregion

    }
}
