using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCCodeFirst.Models
{
    [Table("Adresler")]
    public class Adresler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity) ]
        public int ID { get; set; }


        [StringLength(300)]
        public string AdresTanim { get; set; }

        public virtual Kisiler Kisi { get; set; } //Tablolar arasında ilişkiyi tanımlayan propertydir.
        //bir adresinde bir tane kişi olacaktır.
    }
}