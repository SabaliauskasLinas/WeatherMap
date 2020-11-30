using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public class TestService : ITestService
    {
        public List<TestEntity> GetEntities()
        {
            return new List<TestEntity> { new TestEntity { Name = "Linas", Age = 18 }, new TestEntity { Name = "Dovilė", Age = 17 } };
        }

        public List<NewTestEntity> GetNewEntities()
        {
            return new List<NewTestEntity> { new NewTestEntity { Name = "Dovydas", Age = 18, Email = "Lala" }, new NewTestEntity { Name = "Kebabas", Age = 17, Email = "Ooo" } };
        }
    }
}
