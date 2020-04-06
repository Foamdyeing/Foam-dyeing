using System.Collections.Generic;
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    public class RolesService
    {
        private RolesManager dal = new RolesManager();

        /// <summary>
        /// 判断名称是否存在
        /// </summary>
        /// <param name="title">权限名称</param>
        /// <returns>是否存在</returns>
        public bool IsExist(string title)
        {
            return dal.IsExist(title);
        }

        /// <summary>
        /// 新增权限信息
        /// </summary>
        /// <param name="r">要存储的对象</param>
        /// <returns>受影响行数</returns>
        public int Add(Roles r)
        {
            return dal.Add(r);
        }

        /// <summary>
        /// 编辑权限信息
        /// </summary>
        /// <param name="r">要编辑的对象</param>
        /// <returns>受影响行数</returns>
        public int Edit(Roles r)
        {
            return dal.Edit(r);
        }

        /// <summary>
        /// 删除权限信息
        /// </summary>
        /// <param name="r">要删除的对象</param>
        /// <returns>受影响行数</returns>
        public int Delete(Roles r)
        {
            return dal.Delete(r);
        }

        /// <summary>
        /// 查询所有的权限信息
        /// </summary>
        /// <returns>权限信息集合</returns>
        public List<Roles> GetRolesList()
        {
            return dal.GetRolesList();
        }

        /// <summary>
        /// 按照权限名称查询所有的权限信息(模糊查询)
        /// </summary>
        /// <returns>权限信息集合</returns>
        public List<Roles> GetRolesListByTitle(string title)
        {
            return dal.GetRolesListByTitle(title);
        }

        /// <summary>
        /// 按照id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns>权限对象</returns>
        public Roles GetRoles(int id)
        {
            return dal.GetRoles(id);
        }
    }
}