using System;
using System.Collections.Generic;
using System.Data.Entity; //DbContext'ten kalıtım alırken otomatik çağırdık nuGet Manager'da Entity Frameworkü eklediğimiz için DbContexti Çağırdık 
using System.Linq;
using System.Web;
using MVCCodeFirst.Models; // Sonradan ekledik Kişiler ve Adresler classına erişmek için bunu Yazıyoruz.

namespace MVCCodeFirst.Models.Managers
{

    /*
     * Veritabanı bağlantımızı yapacak olan class budur ama entity ile bağlantı yapmamızı 
     * sağlayacak DbContext classımuızdan kalıtımlar bu class ve kütüphane olarak da dbcontext için 
     * using System.Data.Entity ekleriz. Kalıtım olarak Database işlemlerini yapmak için Yetkili kılacaktır.
     */
    public class DatabaseContext : DbContext
    {
        /*
         * DB Set gibi bir kaç özellik ekliycez .list gibi genericdir
         * db set de kisiler tablosunu temsil edecek bir propety olusturmak için
         */

        public DbSet<Kisiler> Kisiler { get; set; }

        public DbSet<Adresler> Adresler { get; set; }



        /*
         * Database context (Veritabanı temsileden classımızın constructoruna)
         * Bu oluşturucutu ekememiz lazım database.setini methodunu kullanarak 
         * ilgili veritabanı oluşturucu classımızı newleyip birtane
         * veriyorum
         */
        public DatabaseContext()
        {
            Database.SetInitializer(new VeritabaniOlusturucu());
        }
        /*
         * Bunları oluşturmamızın nedeni kisiler ve adresler diye bir satırdaki verileri tutması için oluşturulan classlar
         * yani veri tutmak için Peki bizim bu tablomuzu temsil edecek propertyler özellikler nerede işte o özellikleri burdaki özellikler
         * Yani tablolarımızın içinde CRUD işlemlerini yaparken bunları kullanacağoz tipte DbSet olduğundan ilgili CRUD methodları Gelicektir.
         */

        public class VeritabaniOlusturucu : CreateDatabaseIfNotExists<DatabaseContext>
        {
            /*
             * Databaseim var mı diye bakıyor yoksa oluşturması için yazılan bir class veritabanı oluşturmayı sağlıyor
             * içinde ikitane method geliyor. Bunlar ezilebilir Metotlar
             * 
             * 1) InitailazeDatabase: Database oluştururken ki çalışan metot yani oluşmadan önce alışan mehod.
             * 
             * 2) Seed: Database oluştururken sonraki çalışan metottur.
             * Bizim 2. çaşlışcaz çünkü içinde data basıcaz veritabanımızın
             * database çalışması lazım seed metıtu ezim kendi kodlarımızı yazmamızı sağlıyor.
             */

            protected override void Seed(DatabaseContext context)
            {
                //örnek data basıcaz burada kişiler insert ediliyor
                for (int i = 0; i < 10; i++)
                {
                    Kisiler kisi = new Kisiler();
                    kisi.Ad = FakeData.NameData.GetFirstName();
                    kisi.SoyAd = FakeData.NameData.GetSurname();
                    kisi.Yas = FakeData.NumberData.GetNumber(10, 99);
                    //FakeDatanın içerisinde numberdata classının içindeki getNumber metodunu Çağırıyoruz.
                    // bu Randoö değer veriypr biz 10 ile 99 arasında number değer ver diyoruz
                    context.Kisiler.Add(kisi);

                }
                // beniim database imedki kisiler tabloma insert et kisileri 10 kişi
                context.SaveChanges();

                //Burada Adresler insert ediliyor.



                List<Kisiler> tumKisiler = context.Kisiler.ToList();
                // Kisiler listesini çekiyor select * From Kisiler oluyo gibi düşünebiliriz.

                foreach (Kisiler kisi in tumKisiler)  // Her bir kişi için dön
                {
                    //1 veya 5 arasında dön ve bu kişilere adres ata
                    for (int i = 0; i < FakeData.NumberData.GetNumber(1,5); i++)
                    {
                        Adresler adres = new Adresler();
                        adres.AdresTanim = FakeData.PlaceData.GetAddress();
                        adres.Kisi = kisi;

                        //ilgili kisi için dönecek ve nekadar dönüyorsa adres atıyor.
                        context.Adresler.Add(adres);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}