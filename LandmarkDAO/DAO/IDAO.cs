using LandmarkDAL.DAO.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandmarkDAL.DAO
{
   public interface IDAO<TEntity>
    {

        public void Insert(TEntity Item);

        public void Delete(int ID);

        public TEntity GetByID(int ID);

        public List<TEntity> GetAll();

        public void Update(TEntity Item);
    }
}
