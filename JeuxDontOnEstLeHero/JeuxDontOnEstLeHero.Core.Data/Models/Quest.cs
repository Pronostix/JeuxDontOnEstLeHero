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
        [Required(ErrorMessage ="Le numéro de la quête est obligatoire.")]
        [Range(1,100, ErrorMessage = "Le numéro de la quête doit être compris entre 1 et 100.")]
        public int Number { get; set; }

        /// <summary>
        /// Titre
        /// </summary> 
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le nom de la quête est obligatoire.")]
        public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required(ErrorMessage = "La description de la quête est obligatoire.")]
        [MaxLength(50,ErrorMessage = "La description ne doit pas dépasser 50 caractères.")]
        public string Description { get; set; }

        /// <summary>
        /// Question de la quête
        /// </summary>
        public Question Question { get; set; }

        #endregion

    }
}
