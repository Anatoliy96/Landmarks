using System;
using System.Collections.Generic;
using System.Text;
using LandmarkDAL.Models;
using LandmarkDAL.DAO.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace LandmarkDAL.DAO
{
   public class UniversalDAO<TEntity> : IDAO<TEntity>
        where TEntity : Common
    {
        LandmarkContext context;
        public UniversalDAO()
            : this(new LandmarkContext())
        {

        }

        public UniversalDAO(LandmarkContext Context)
        {
            this.context = Context;
        }
        public void Insert(TEntity Item)
        {
            context.Set<TEntity>().Add(Item);
            context.SaveChanges();
        }

        public void Delete(int ID)
        {
            TEntity toDelete = context.Set<TEntity>().Find(ID);
            context.Remove(toDelete);
            context.SaveChanges();
        } 

        public TEntity GetByID(int ID)
        {
            return context.Set<TEntity>().Find(ID);
        }

        public List<TEntity> GetAll()
        {
            try
            {
                if (context.Set<TEntity>().Count() == 0)
                    return null;
                return context.Set<TEntity>().ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public TEntity GetByName(string username)
        {
            return context.Set<TEntity>().Find(username);
        }
        public void Update(TEntity Item)
        {
            context.Set<TEntity>().Update(Item);
            context.SaveChanges();
        }
    }
}
