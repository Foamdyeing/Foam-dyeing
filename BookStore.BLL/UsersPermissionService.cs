using System.Collections.Generic;
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    public class UsersPermissionService
    {
        private UsersPermissionManager dal = new UsersPermissionManager();

        public int Add(UsersPermission model)
        {
            return dal.Add(model);

        }

        public int Edit(UsersPermission model)
        {
            return dal.Edit(model);

        }

        public int Delete(UsersPermission model)
        {
            return dal.Delete(model);

        }

        public List<UsersPermission> GetUsersPermissionsByRolesId(int rid)
        {
            return dal.GetUsersPermissionsByRolesId(rid);
        }

    }
}