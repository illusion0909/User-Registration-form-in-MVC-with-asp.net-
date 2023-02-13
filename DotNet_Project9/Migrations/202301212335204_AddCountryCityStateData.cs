namespace DotNet_Project9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryCityStateData : DbMigration
    {
        public override void Up()
        {
            Sql("insert Countries values('India')");
            Sql("insert Countries values('USA')");
            Sql("insert Countries values('ABC')");


            Sql("insert States values('PB',1)");
            Sql("insert States values('HP',1)");
            Sql("insert States values('UP',1)");
            Sql("insert States values('CALIFORNIA',2)");
            Sql("insert States values('W.DC',2)");
            Sql("insert States values('XYZ',3)");
            Sql("insert States values('OPC',3)");

            Sql("insert Cities values('LDH',1)");
            Sql("insert Cities values('ASR',1)");
            Sql("insert Cities values('MOHALI',1)");

            Sql("insert Cities values('SHIMLA',2)");
            Sql("insert Cities values('UNA',2)");
            Sql("insert Cities values('KANGRA',2)");
            Sql("insert Cities values('abc',3)");
            Sql("insert Cities values('Aaa',3)");
            Sql("insert Cities values('bbb',3)");
        }
        
        public override void Down()
        {
        }
    }
}
