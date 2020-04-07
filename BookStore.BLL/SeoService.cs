using System.Collections.Generic;
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    public class SeoService
    {
        private SeoManager dal = new SeoManager();

        public int Add(Seo seo)
        {
            return dal.Add(seo);
        }

        public int Edit(Seo seo)
        {
            return dal.Edit(seo);
        }

        public int Delete(Seo seo)
        {
            return dal.Delete(seo);
        }

        public List<Seo> GetSeoList()
        {
            return dal.GetSeoList();
        }

        public List<Seo> GetSeoListByTitle(string title)
        {
            return dal.GetSeoListByTitle(title);
        }


        public List<Seo> GetSeoListByWebMenuId(int webMenuId)
        {
            return dal.GetSeoListByWebMenuId(webMenuId);
        }


        public Seo GetSeo(int id)
        {
            return dal.GetSeo(id);
        }
    }
}