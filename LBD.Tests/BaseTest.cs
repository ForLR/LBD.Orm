using LBD.DAL;
using LBD.DAL.Interfaces;
using LBD.Framework;
using LBD.Model;

namespace LBD.Tests
{
    [TestClass]
    public class BaseTest
    {
        ILBDClient db;
        public BaseTest()
        {
            db = new LBDClient(new ConnectionConfig(ConfigMange.GetConnStr()));
        }

        [TestMethod]
        public void FindFisrtTest()
        {
            var result = db.Find<Company>(x => x.Id > 0);
            Assert.IsTrue(result.Id > 0);
        }
        [TestMethod]
        public async Task FindFisrtAsyncTest()
        {
            var result = await db.FindAsync<Company>(1);
            Assert.IsTrue(result.Id > 0);
        }


        [TestMethod]
        public void InsertTest()
        {
            db.Insert(new Company() { CreateDate = DateTime.Now, Name = "test11" });
        }

        [TestMethod]
        public void UpdateTest()
        {
            var result = db.Find<Company>(x => x.Id > 0);
            result.Name = "test1";
            db.Update(result);
            db.SavaChange();
        }

        [TestMethod]
        public void DeleteTest()
        {
            var result = db.Find<Company>(x => x.Id > 0);
            db.Delete(result);
            db.SavaChange();
        }

        [TestMethod]
        public void BulkInsertTest()
        {
            List<Company> list = new List<Company>();
            foreach (var item in Enumerable.Range(0, 100))
            {
                list.Add(new Company()
                {

                    CreateDate = DateTime.Now,
                    Name = $"ÕÅÈý{item}"
                });

            }
            var result2 = db.BulkInsert(list);
            db.SavaChange();
            Assert.IsTrue(result2 > 0);
        }

    }
}