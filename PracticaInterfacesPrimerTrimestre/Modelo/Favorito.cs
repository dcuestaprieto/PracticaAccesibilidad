﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaInterfacesPrimerTrimestre.Modelo
{
    [Table("favoritos")]
    public class Favorito
    {
        [PrimaryKey]
        public string UserId { get; set; }
        [PrimaryKey]
        public string DogId { get; set; }
    }
}