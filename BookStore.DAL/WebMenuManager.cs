using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookStore.Model;

namespace BookStore.DAL
{
    public class WebMenuManager
    {
        public int Add(WebMenu m)
        {
            string sql = "insert into WebMenu(Title,Link,ParentId) values(@Title,@Link,@ParentId)";
            SqlParameter[] param =
            {
                new SqlParameter("@Title",m.Title),
                new SqlParameter("@Link",m.Link),
                new SqlParameter("@ParentId",m.ParentId)
            };

            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public int Edit(WebMenu m)
        {
            string sql = "update WebMenu set Title=@Title,Link=@Link,ParentId=@ParentId where Id=@Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Title",m.Title),
                new SqlParameter("@Link",m.Link),
                new SqlParameter("@ParentId",m.ParentId),
                new SqlParameter("@Id",m.Id)
            };

            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public int Delete(WebMenu m)
        {
            string sql = "delete from WebMenu where Id=@Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",m.Id)
            };

            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public List<WebMenu> GetWebMenusList()
        {
            string sql = "select Id,Title,Link, ParentId from WebMenu";
            var dt = SqlHelper.Query(sql, null);
            var list = new List<WebMenu>();
            foreach (DataRow dr in dt.Rows)
            {
                var item = FileData(dr);
                list.Add(item);
            }

            return list;
        }


        public List<WebMenu> GetWebMenusListByTitle(string title)
        {
            string sql = $"select Id,Title,Link, ParentId from WebMenu where Title like '%{title}%'";
            var dt = SqlHelper.Query(sql, null);
            var list = new List<WebMenu>();
            foreach (DataRow dr in dt.Rows)
            {
                var item = FileData(dr);
                list.Add(item);
            }

            return list;
        }

        public List<WebMenu> GetWebMenusListByParentId(int parentId = 0)
        {
            string sql = "select Id,Title,Link, ParentId from WebMenu where ParentId = @ParentId";
            SqlParameter[] param =
            {
                new SqlParameter("@ParentId",parentId)
            };
            var dt = SqlHelper.Query(sql, param);
            var list = new List<WebMenu>();
            foreach (DataRow dr in dt.Rows)
            {
                var item = FileData(dr);
                list.Add(item);
            }

            return list;
        }


        public WebMenu GetWebMenuById(int id)
        {
            string sql = "select Id,Title,Link,ParentId where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",id)
            };
            var dt = SqlHelper.Query(sql, param);
            WebMenu menu = null;
            foreach (DataRow dr in dt.Rows)
            {
                menu = FileData(dr);
            }

            return menu;
        }

        public WebMenu FileData(DataRow dr)
        {
            return new WebMenu()
            {
                Id = int.Parse(dr["Id"].ToString()),
                Title = dr["Title"].ToString(),
                Link = dr["Link"].ToString(),
                ParentId = int.Parse(dr["ParentId"].ToString())
            };
        }
    }
}