using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiTempoAgoraSQLite.Models
{
    public class Cidade
    {
     
            [PrimaryKey, AutoIncrement] public int Id { get; set; }

          

            public string? nome { get; set; }

            public string? Uf { get; set; }




        
    }
}
