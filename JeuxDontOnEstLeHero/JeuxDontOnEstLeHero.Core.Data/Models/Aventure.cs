using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JeuxDontOnEstLeHero.Core.data
{
    [Table("Aventure")]
    public class Aventure
    {

        #region Props
        /// <summary>
        /// Id de l'aventure
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nom de l'aventure
        /// </summary>
        public string Title { get; set; }

        #endregion

    }
}
