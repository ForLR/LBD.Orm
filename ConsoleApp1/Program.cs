using LBD.DAL;
using LBD.DAL.Interfaces;
using LBD.Framework;
using LBD.Model;
using System;
using System.Collections.Generic;
using LBD.CodeFirst;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlCodeMapping sqlCodeMapping = new SqlCodeMapping();
            var createSql = sqlCodeMapping.MappingToSql<Company>();
            Console.WriteLine(createSql);

            // ILBDClient db = new LBDClient(new ConnectionConfig(ConfigMange.GetConnStr()));
            // var result = db.Find<Company>(x=>x.Id>1);
            // var results = db.FindList<Company>(x => x.Id > 1&&x.Id!=3);

            // List<Company> list = new List<Company>();
            // for (int i = 0; i < 100; i++)
            // {
            //     list.Add(new Company() {

            //     CreateDate=DateTime.Now,
            //     Name=$"张三{i}"
            //     });
            // }
            //var result2=db.BulkInsert(list);

            //result.Name = "test1";
            //db.Update(result);
            //db.Insert(new Company() { CreateDate = DateTime.Now,Name="test11" }) ;
            //db.SavaChange();
            //var deleteResult = db.Delete(result);
            //var  insertResult=db.Insert(new Company { CreateDate = DateTime.Now,Name="李四" }) ;

            //Console.WriteLine("Hello World!");


        }
    }
}
