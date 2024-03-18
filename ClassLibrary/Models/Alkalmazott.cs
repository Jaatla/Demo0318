using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Alkalmazott
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(40)]
        public string Nev { get; set; }
        [StringLength(20)]
        public string Beosztas { get; set; }
        public int Fonok { get; set; }
        public DateTime Belepes { get; set; }
        public int Fizetes { get; set; }
        public int Jutalom { get; set; }
        public int OsztId { get; set; }

        public Alkalmazott()
        {
        }

        public Alkalmazott(string sor)
        {
            var a = sor.Split(';');

            Id = Convert.ToInt32(a[0]);
            Nev = a[1];
            Beosztas = a[2];
            Fonok = a[3]==""?0:Convert.ToInt32(a[3]);
            Belepes = DateTime.Parse(a[4]);
            Fizetes = Convert.ToInt32(a[5]);
            Jutalom = a[6]==""?0:Convert.ToInt32(a[6]); ;
            OsztId = Convert.ToInt32(a[7]); ;
        }

        public override string? ToString()
        {
            return "A nevem "+Nev+" beosztásom "+Beosztas+", fizetésem "+Fizetes+"$ a főnököm:"+Fonok;
        }
    }
}
