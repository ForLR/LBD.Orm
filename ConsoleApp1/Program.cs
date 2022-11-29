using LBD.DAL;
using LBD.DAL.Interfaces;
using LBD.DAL.Mysql;
using LBD.Framework;
using LBD.Model;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ILBDClient db = new LBDClient(new ConnectionConfig(ConfigMange.GetConnStr()));
            var result = db.Find<Company>(x => x.Id > 1);
            //var results = db.FindList<Company>(x => x.Id > 1 && x.Id != 3);

            //List<Company> list = new List<Company>();

            //{
            //    list.Add(new Company()
            //    {

            //        CreateDate = DateTime.Now,
            //        Name = $"张三{i}"
            //    });
            //}
            //var result2 = db.BulkInsert(list);

            //var test = string.Empty;

            result.Name = "test1";
            db.Update(result);
            db.Insert(new Company() { CreateDate = DateTime.Now, Name = "test11" });
            db.SavaChange();
            //var deleteResult = db.Delete(result);
            //var insertResult = db.Insert(new Company { CreateDate = DateTime.Now, Name = "李四" });

            Console.WriteLine("Hello World!");
        }
    }
}
