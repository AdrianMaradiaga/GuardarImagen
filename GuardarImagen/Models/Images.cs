using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace GuardarImagen.Models
{
    public class Images
    {
        [PrimaryKey, AutoIncrement]
        public int id {  get; set; }    
        public string name { get; set; }    
        public string description { get; set; }
        public byte[] image { get; set; }   
    }
}
