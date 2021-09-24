using LandmarkDAL.DAO.Context;
using LandmarkDAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandmarkDAL.DAO
{
    public class UsersDAO : IDAO<ApplicationUser>
    {
        LandmarkContext context;
        public UsersDAO()
            : this(new LandmarkContext())
        {

        }
        public UsersDAO(LandmarkContext Context)
        {
            this.context = Context;
        }
        public void Insert(ApplicationUser Item)
        {
            context.Set<ApplicationUser>().Add(Item);
            context.SaveChanges();
        }

        public void Delete(int ID)
        {
            ApplicationUser toDelete = context.Set<ApplicationUser>().Find(ID);
            context.Remove(toDelete);
            context.SaveChanges();
        }

        public ApplicationUser GetByID(int ID)
        {
            return context.Set<ApplicationUser>().Find(ID);
        }

        public List<ApplicationUser> GetAll()
        {
            try
            {
                if (context.Set<ApplicationUser>().Count() == 0)
                    return null;
                return context.Set<ApplicationUser>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ApplicationUser GetbyName(string username)
        {
            return context.Set<ApplicationUser>().FirstOrDefault(au => au.UserName == username);
        }

        public void Update(ApplicationUser Item)
        {
            context.Set<ApplicationUser>().Update(Item);
            context.SaveChanges();
        }
    }
}
