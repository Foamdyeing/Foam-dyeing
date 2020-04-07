using System.Collections.Generic;
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    public class WebMenuService
    {
        private WebMenuManager dal = new WebMenuManager();
        public int Add(WebMenu m)
        {
            return dal.Add(m);
        }

        public int Edit(WebMenu m)
        {
            return dal.Edit(m);
        }

        public int Delete(WebMenu m)
        {
            return dal.Delete(m);
        }

        public List<WebMenu> GetWebMenusList()
        {
            return dal.GetWebMenusList();
        }


        public List<WebMenu> GetWebMenusListByTitle(string title)
        {
            return dal.GetWebMenusListByTitle(title);
        }

        public List<WebMenu> GetWebMenusListByParentId(int parentId = 0)
        {
            return dal.GetWebMenusListByParentId(parentId);
        }


        public WebMenu GetWebMenuById(int id)
        {
            return dal.GetWebMenuById(id);
        }
    }
}