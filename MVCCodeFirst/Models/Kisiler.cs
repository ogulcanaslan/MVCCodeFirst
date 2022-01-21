using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //Key Yazdeığımız yerden otomatik ekledik
using System.ComponentModel.DataAnnotations.Schema;  // Table yazdığımız yerden otomatik eklemeyle ekledik
using System.Linq;
using System.Web;

namespace MVCCodeFirst.Models
{
    [Table("Kisiler")] //Tablomuzda isim vermek istiyorsak buraya attibute yani nitelik ekliyoruz eğer eklemezsek kendisi program otomatik isim verir)
    public class Kisiler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Anahtar konulan yani primary key PK olan alanı tanımldım 
        //Birde Identity Tanımlıyoruz
        public int ID { get; set; }


        [StringLength(20), Required]//varchar(20) ve Required komutu ile boş Geçilemez Diyoruz.
        public string Ad { get; set; }


        [StringLength(20),Required]
        public string SoyAd { get; set; }


        [Required]
        public int Yas { get; set; }


        public virtual List<Adresler> Adresler { get; set; } //Tablolar Arasında ilişkiyi taınmlayan property budur.

        /* Bir Kişinin birden çok adresi olacak o yüzden listelenmesi
         * için generic kullanarak listelenmesini istedik aynı zamanda veri tabanındaki
         * tablo baglantılarını da bu sekilde yapmıs oluyoruz.
         */


    }
}