
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    public class CopyrightService
    {
        private CopyrightManager dal = new CopyrightManager();

        public bool IsExist()
        {
            return dal.IsExist();
        }


        public int Add(Copyright model)
        {
            return dal.Add(model);
        }

        public int Edit(Copyright model)
        {
            return dal.Edit(model);
        }



        public Copyright GetCopyright()
        {
            return dal.GetCopyright();

        }


    }
}