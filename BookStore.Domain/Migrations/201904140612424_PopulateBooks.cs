namespace BookStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBooks : DbMigration
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


        }
        
        public override void Down()
        {
        }
    }
}
