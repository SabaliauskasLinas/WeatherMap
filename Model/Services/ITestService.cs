using System.Collections.Generic;
using Model.Entities;

namespace Model.Services
{
    public interface ITestService
    {
        List<TestEntity> GetEntities();
        List<NewTestEntity> GetNewEntities();
    }
}