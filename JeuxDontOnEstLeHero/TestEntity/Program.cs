using JeuxDontOnEstLeHero.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System;
using System.IO;

namespace TestEntity
{
    class Program
    {
        static void Main(string[] args)
        {

            ConfigurationBuilder builder = new ConfigurationBuilder();

            // Chemin du fichier json
            // Ajout des dépendances
            //      Microsoft.Extensions.Configuration
            //      Microsoft.Extensions.Configuration.FileExtensions
            //      Microsoft.Extensions.Configuration.Json
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            // Récupération de la chaine de connexion
            string connexion = config.GetConnectionString("DefaultContext_NAS");


            // Définir le SGDB
            // Ajout des dépendances
            //      Microsoft.EntityFrameworkCore.SqlServer
            DbContextOptionsBuilder optionBuilder = new DbContextOptionsBuilder();
            optionBuilder.UseSqlServer(connexion);
                    
                        // Connexion à la base de données
            using (DefaultContext Context = new DefaultContext(optionBuilder.Options))
            {
                var query = from Droide in Context.Droides
                            select Droide;

                foreach (var item in query.ToList())
                {
                    Console.WriteLine(item.Matricule);
                }

            }

        }
    }
}
