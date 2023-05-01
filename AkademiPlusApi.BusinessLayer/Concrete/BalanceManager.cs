using AkademiPlusApi.BusinessLayer.Abstract;
using AkademiPlusApi.DataAccessLayer.Abstract;
using AkademiPlusApi.EntityLayer.Concrete;
using System.Collections.Generic;

namespace AkademiPlusApi.BusinessLayer.Concrete
{
    public class BalanceManager : IBalanceService
    {
        private readonly IBalanceDal _balanceDal;

        public BalanceManager(IBalanceDal balanceDal)
        {
            _balanceDal = balanceDal;
        }

        public void TDelete(Balance t)
        {
            _balanceDal.Delete(t);
        }

        public Balance TGetByID(int id)
        {
            return _balanceDal.GetByID(id);
        }

        public List<Balance> TGetList()
        {
            return _balanceDal.GetList();
        }

        public void TInsert(Balance t)
        {
            _balanceDal.Insert(t);
        }

        public void TUpdate(Balance t)
        {
            _balanceDal.Update(t);
        }
    }
}
