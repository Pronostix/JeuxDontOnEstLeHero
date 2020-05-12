using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeuxDontOnEstLeHero.Core.Entity
{
    /// <summary>
    /// Surcharge pour correspondre au nom de table SQL
    /// </summary>
    [Table("Droide")]
    public class Droide
    {

        public int Id { get; set; }

        public string Matricule { get; set; }

        //public Weapon Weapon { get; set; }
}
}
