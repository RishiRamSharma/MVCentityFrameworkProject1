namespace MVCentityFrameworkNewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDefaultValue : DbMigration
    {
        public override void Up()
        {
            // Department
            Sql("insert Departments values('Account')");
            Sql("insert Departments values('Sales')");
            Sql("insert Departments values('Marketing')");

            // Designation
            Sql("insert Designations values('ProgramManager')");
            Sql("insert Designations values('TechinicalLeader')");
            Sql("insert Designations values('Programer')");
        }
        
        public override void Down()
        {
        }
    }
}
