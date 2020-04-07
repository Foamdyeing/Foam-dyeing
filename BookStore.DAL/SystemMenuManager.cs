using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookStore.Model;

namespace BookStore.DAL
{
    public class SystemMenuManager
    {
        public int Add(SystemMenu m)
        {
            string sql = "insert into SystemMenu(Title,Link,ParentId) values(@Title,@Link,@ParentId)";
            SqlParameter[] param =
            {
                new SqlParameter("@Title",m.Title),
                new SqlParameter("@Link",m.Link),
                new SqlParameter("@ParentId",m.ParentId)
            };

            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public int Edit(SystemMenu m)
        {
            string sql = "update SystemMenu set Title=@Title,Link=@Link,ParentId=@ParentId where Id=@Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Title",m.Title),
                new SqlParameter("@Link",m.Link),
                new SqlParameter("@ParentId",m.ParentId),
                new SqlParameter("@Id",m.Id)
            };

            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public int Delete(SystemMenu m)
        {
            string sql = "delete from SystemMenu where Id=@Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",m.Id)
            };

            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public List<SystemMenu> GetSystemMenusList()
        {
            string sql = "select Id,Title,Link, ParentId from SystemMenu";
            var dt = SqlHelper.Query(sql, null);
            var list = new List<SystemMenu>();
            foreach (DataRow dr in dt.Rows)
            {
                var item = FileData(dr);
                list.Add(item);
            }

            return list;
        }


        public List<SystemMenu> GetSystemMenusListByTitle(string title)
        {
            string sql = $"select Id,Title,Link, ParentId from SystemMenu where Title like '%{title}%'";
            var dt = SqlHelper.Query(sql, null);
            var list = new List<SystemMenu>();
            foreach (DataRow dr in dt.Rows)
            {
                var item = FileData(dr);
                list.Add(item);
            }

            return list;
        }

        public List<SystemMenu> GetSystemMenusListByParentId(int parentId = 0)
        {
            string sql = "select Id,Title,Link, ParentId from SystemMenu where ParentId = @ParentId";
            SqlParameter[] param =
            {
                new SqlParameter("@ParentId",parentId) 
            };
            var dt = SqlHelper.Query(sql, param);
            var list = new List<SystemMenu>();
            foreach (DataRow dr in dt.Rows)
            {
                var item = FileData(dr);
                list.Add(item);
            }

            return list;
        }


        public SystemMenu GetSystemMenuById(int id)
        {
            string sql = "select Id,Title,Link,ParentId where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",id) 
            };
            var dt = SqlHelper.Query(sql, param);
            SystemMenu menu = null;
            foreach (DataRow dr in dt.Rows)
            {
                menu = FileData(dr);
            }

            return menu;
        }

        public SystemMenu FileData(DataRow dr)
        {
            return new SystemMenu()
            {
                Id = int.Parse(dr["Id"].ToString()),
                Title = dr["Title"].ToString(),
                Link = dr["Link"].ToString(),
                ParentId = int.Parse(dr["ParentId"].ToString())
            };
        }

    }
}