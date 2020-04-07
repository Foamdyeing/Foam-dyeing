using System.Collections.Generic;
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    public class FriendLinkService
    {
        private FriendLinkManager dal = new FriendLinkManager();

        public bool IsExist(string title)
        {
            return dal.IsExist(title);
        }

        public int Add(FriendLink model)
        {
            return dal.Add(model);
        }


        public int Edit(FriendLink model)
        {
            return dal.Edit(model);
        }

        public int Delete(FriendLink model)
        {
            return dal.Delete(model);
        }


        public List<FriendLink> GetFriendLinkList()
        {
            return dal.GetFriendLinkList();
        }

        public List<FriendLink> GetFriendLinkListByTitle(string title)
        {
            return dal.GetFriendLinkListByTitle(title);
        }

        public List<FriendLink> GetFriendLinkListByIsShow(bool isShow)
        {
            return dal.GetFriendLinkListByIsShow(isShow);
        }


        public FriendLink GetFriendLink(int id)
        {
            return dal.GetFriendLink(id);
        }

    }
}