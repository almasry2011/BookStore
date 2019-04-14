namespace BookStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBooks1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Books (Price, Titel,Description,Specialization)VALUES" +
                         "(10,'Big Data', 'Big Data From Scratch', 'Information Technology')");

            Sql("INSERT INTO Books (Price, Titel,Description,Specialization)VALUES" +
                     "(10,'ASP.NET MVC', 'ASP.NET MVC From Scratch', 'Programming')");

            Sql("INSERT INTO Books (Price, Titel,Description,Specialization)VALUES" +
                   "(10,'JavaScript', 'JavaScript From Scratch',' Programming')");

            Sql("INSERT INTO Books (Price, Titel,Description,Specialization)VALUES" +
                  "(10,'Selenium WebDrive', 'Selenium From Scratch', 'Automation Testing')");

            Sql("INSERT INTO Books (Price, Titel,Description,Specialization)VALUES" +
            "(10,'Operating Systems', 'Operating Systems From Scratch', 'OS')");

            Sql("INSERT INTO Books (Price, Titel,Description,Specialization)VALUES" +
           "(10,'SQL Server Query', 'SQL Server From Scratch', 'MSSQL')");

            Sql("INSERT INTO Books (Price, Titel,Description,Specialization)VALUES" +
            "(10,'101 LINQ Query', '101 LINQ Query From Scratch', 'LINQ')");

            Sql("INSERT INTO Books (Price, Titel,Description,Specialization)VALUES" +
            "(10,'Python', 'Python From Scratch', 'Python')");

            Sql("INSERT INTO Books (Price, Titel,Description,Specialization)VALUES" +
            "(10,'Entity Framework', 'Entity Framework From Scratch', 'Entity Framework')");

            Sql("INSERT INTO Books (Price, Titel,Description,Specialization)VALUES" +
           "(10,'Bootstrap', 'Bootstrap From Scratch', 'Bootstrap')");

            Sql("INSERT INTO Books (Price, Titel,Description,Specialization)VALUES" +
       "(10,'JQuery', 'JQuery From Scratch', 'JQuery')");

            Sql("INSERT INTO Books (Price, Titel,Description,Specialization)VALUES" +
   "(10,'HTML', 'HTML From Scratch', 'HTML')");

        }

        public override void Down()
        {
        }
    }
}
