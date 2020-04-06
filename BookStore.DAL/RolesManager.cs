using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookStore.Model;

namespace BookStore.DAL
{
    public class RolesManager
    {
        /// <summary>
        /// 判断名称是否存在
        /// </summary>
        /// <param name="title">权限名称</param>
        /// <returns>是否存在</returns>
        public bool IsExist(string title)
        {
            string sql = "select count(*) from Roles where Title = @Title";
            SqlParameter[] param =
            {
                new SqlParameter("@Title",title) 
            };
            object ob = SqlHelper.ExecuteSaclar(sql, param);
            return int.Parse(ob.ToString()) > 0;
        }

        /// <summary>
        /// 新增权限信息
        /// </summary>
        /// <param name="r">要存储的对象</param>
        /// <returns>受影响行数</returns>
        public int Add(Roles r)
        {
            string sql = "insert into Roles(Title) values(@Title)";
            SqlParameter[] param =
            {
                new SqlParameter("@Title",r.Title) 
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 编辑权限信息
        /// </summary>
        /// <param name="r">要编辑的对象</param>
        /// <returns>受影响行数</returns>
        public int Edit(Roles r)
        {
            string sql = "update Roles set Title = @Title where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Title",r.Title) ,
                new SqlParameter("@Id",r.Id)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 删除权限信息
        /// </summary>
        /// <param name="r">要删除的对象</param>
        /// <returns>受影响行数</returns>
        public int Delete(Roles r)
        {
            string sql = "delete from Roles where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",r.Id)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 查询所有的权限信息
        /// </summary>
        /// <returns>权限信息集合</returns>
        public List<Roles> GetRolesList()
        {
            string sql = "select Id,Title from Roles order by Id desc";
            var dt = SqlHelper.Query(sql, null);
            List<Roles> list = new List<Roles>();
            foreach (DataRow dr in dt.Rows)
            {
                Roles r = new Roles()
                {
                    Id = int.Parse(dr["Id"].ToString()),
                    Title = dr["Title"].ToString()
                };
                list.Add(r);
            }

            return list;
        }

        /// <summary>
        /// 按照权限名称查询所有的权限信息(模糊查询)
        /// </summary>
        /// <returns>权限信息集合</returns>
        public List<Roles> GetRolesListByTitle(string title)
        {
            string sql = $"select Id,Title from Roles where Title like '%{title}%'  order by Id desc";
            var dt = SqlHelper.Query(sql, null);
            List<Roles> list = new List<Roles>();
            foreach (DataRow dr in dt.Rows)
            {
                Roles r = new Roles()
                {
                    Id = int.Parse(dr["Id"].ToString()),
                    Title = dr["Title"].ToString()
                };
                list.Add(r);
            }

            return list;
        }

        /// <summary>
        /// 按照id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns>权限对象</returns>
        public Roles GetRoles(int id)
        {
            string sql = "select Id,Title from Roles where Id = @Id order by Id desc";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",id)
            };
            var dt = SqlHelper.Query(sql, param);
            if (dt.Rows.Count > 0)
            {
                return new Roles()
                {
                    Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                    Title = dt.Rows[0]["Title"].ToString()
                };
            }

            return null;
        }
    }
}