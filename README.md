# MVCCodeFirst

Proje Empty MVC olarak Açtık
HomController içerisinde HomePage Açtık layout kullanarak View ekledik.


Reference Kısmına manage NuGet Packagesdan
kurarken:
bootstrap, jquery, FakeData, Entity Framework, (Web Esention)=>Evde Bak
(NuGet Managment) 


models içinde Kişiler ve Adres adında class oluşturduk bu classlar attribute alıyo

Models içerisinde Managers adında klasör oluşturdujk içerisinde Veritabanı
işlemlerini tutacağım DatabaseContext adında bir class Oluşturdum



Web.config : içerisinde bunu Yaz
  <configSections>
    <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
    <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
  </configSections>
	<connectionStrings>
		<add name="DatabaseContext" providerName="System.Data.SqlClient" connectionString="Server=Z29-9;Database=Bilgi;uid=sa;pwd=11072010"/>
	</connectionStrings>
		
Eğer evde Yapacaksak

<connectionStrings>
		<add name="DatabaseContext" providerName="System.Data.SqlClient" connectionString="Server=.;Database=Bilgi;Integrated security=true;/>
	</connectionStrings>
