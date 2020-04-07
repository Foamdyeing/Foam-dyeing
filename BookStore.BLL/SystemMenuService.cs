using System.Collections.Generic;
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    public class SystemMenuService
    {
        private SystemMenuManager dal = new SystemMenuManager();

        public int Add(SystemMenu m)
        {
            return dal.Add(m);
        }

        public int Edit(SystemMenu m)
        {
            return dal.Edit(m);
        }

        public int Delete(SystemMenu m)
        {
            return dal.Delete(m);
        }

        public List<SystemMenu> GetSystemMenusList()
        {
            return dal.GetSystemMenusList();
        }


        public List<SystemMenu> GetSystemMenusListByTitle(string title)
        {
            return dal.GetSystemMenusListByTitle(title);
        }

        public List<SystemMenu> GetSystemMenusListByParentId(int parentId = 0)
        {
            return dal.GetSystemMenusListByParentId(parentId);
        }


        public SystemMenu GetSystemMenuById(int id)
        {
            return dal.GetSystemMenuById(id);
        }
    }
}