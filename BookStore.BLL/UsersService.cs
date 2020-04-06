using System;
using System.Collections.Generic;
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    public class UsersService
    {
        private UsersManager dal = new UsersManager();

        /// <summary>
        /// 判断电子邮件是否存在的
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsExist(string email)
        {
            return dal.IsExist(email);
        }


        public int Add(Users u)
        {
            return dal.Add(u);
        }


        public int Edit(Users u)
        {
            return dal.Edit(u);
        }

        public int Delete(Users u)
        {
            return dal.Delete(u);
        }

        public List<Users> GetUsersList()
        {
            return dal.GetUsersList();
        }
        //.net framework 4.5 --> C# 5.0
        //.net framework 4.6 --> C# 6.0
        //.net framework 4.7 --> C# 7.0
        //.net framework 4.8 --> C# 8.0
        public List<Users> GetUsersListByNickName(string nickname)
        {
            return dal.GetUsersListByNickName(nickname);
        }


        public Users GetUsersById(int id)
        {
            return dal.GetUsersById(id);
        }


        public Users Login(string email, string pwd)
        {
            return dal.Login(email, pwd);
        }

        /// <summary>
        /// 根据权限编号进行查询
        /// </summary>
        /// <param name="rolesId"></param>
        /// <returns></returns>
        public List<Users> GetUsersByRolesId(int rolesId)
        {
            return dal.GetUsersByRolesId(rolesId);
        }
    }
}