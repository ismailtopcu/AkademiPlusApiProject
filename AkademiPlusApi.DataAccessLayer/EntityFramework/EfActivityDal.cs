using AkademiPlusApi.DataAccessLayer.Abstract;
using AkademiPlusApi.DataAccessLayer.Repositories;
using AkademiPlusApi.EntityLayer.Concrete;

namespace AkademiPlusApi.DataAccessLayer.EntityFramework
{
    public class EfActivityDal:GenericRepository<Activity>, IActivityDal
    {
    }
}
