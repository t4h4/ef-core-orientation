dotnet add package Microsoft.EntityFrameworkCore.Sqlite  
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.3
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 3.2.4 


// Database created with Code First
dotnet tool install --global dotnet-ef   
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate  //Create migration

// Create migration for n tier application 
dotnet ef migrations add InitialCreate --startup-project ../app.webui  //app.webui project start point.

dotnet ef database update
// If n tier application
dotnet ef database update --startup-project ../app.webui

dotnet ef migrations add addColumnProductCategoryId  //new column, new migrations
dotnet ef database update   //new update

dotnet ef database uptade dönmek_istenilen_nokta     //güncellemeyi geriye alabiliyoruz. o migrations'un down metodu çalıştı. lokalde migrations duruyor fakat database'den alınıyor. lokalden de silmek için aşağıdaki komutu kullanabilirsin.

dotnet ef migrations remove    //lokalde migrations silinir. ama sadece database den silinmiş olanlar silinir. database den silinmemiş olanlar varsa hata verir.

dotnet ef database update 0    //bütün migrationlar veritabanında siliniyor. 0. adıma gelinmiş olunuyor.

dotnet ef database drop --force      //database'i siler.



// Database first with Northwind database

komut sonrası -h koyarak yardım olaylarını görebilirsin.

dotnet ef dbcontext scaffold [arguments] [options]

dotnet ef dbcontext scaffold "server=localhost;port=3306;database=northwind;user=root;" "Pomelo.EntityFrameworkCore.MySql" --output-dir "Data/EfCore" --context NorthwindContext
