using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookStore.Model;

namespace BookStore.DAL
{
    public class SeoManager
    {
        public int Add(Seo seo)
        {
            string sql = "insert into Seo(Title,Keyword,Description,WebMenuId) values(@Title,@Keyword,@Description,@WebMenuId)";

            SqlParameter[] param =
            {
                new SqlParameter("@Title",seo.Title),
                new SqlParameter("@Keyword",seo.Keyword),
                new SqlParameter("@Description",seo.Description),
                new SqlParameter("@WebMenuId",seo.WebMenuId)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public int Edit(Seo seo)
        {
            string sql = "update Seo set Title = @Title,Keyword=@Keyword,Description=@Description,WebMenuId=@WebMenuId where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Title",seo.Title),
                new SqlParameter("@Keyword",seo.Keyword),
                new SqlParameter("@Description",seo.Description),
                new SqlParameter("@WebMenuId",seo.WebMenuId),
                new SqlParameter("@Id",seo.Id)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public int Delete(Seo seo)
        {
            string sql = "delete from Seo where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",seo.Id)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public List<Seo> GetSeoList()
        {
            string sql = "select * from Seo";
            var dt = SqlHelper.Query(sql, null);
            var list = new List<Seo>();
            foreach (DataRow dr in dt.Rows)
            {
                Seo s = FillData(dr);
                list.Add(s);
            }

            return list;
        }

        public List<Seo> GetSeoListByTitle(string title)
        {
            string sql = "select * from Seo where Title like '%"+title+"%'";
            
            var dt = SqlHelper.Query(sql, null);
            var list = new List<Seo>();
            foreach (DataRow dr in dt.Rows)
            {
                Seo s = FillData(dr);
                list.Add(s);
            }

            return list;
        }


        public List<Seo> GetSeoListByWebMenuId(int webMenuId)
        {
            string sql = "select * from Seo where WebMenuId = @WebMenuId";
            SqlParameter[] param =
            {
                new SqlParameter("@WebMenuId",webMenuId) 
            };
            var dt = SqlHelper.Query(sql, param);
            var list = new List<Seo>();
            foreach (DataRow dr in dt.Rows)
            {
                Seo s = FillData(dr);
                list.Add(s);
            }

            return list;
        }


        public Seo GetSeo(int id)
        {
            string sql = "select * from Seo where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",id)
            };
            var dt = SqlHelper.Query(sql, param);
            Seo seo = null;
            foreach (DataRow dr in dt.Rows)
            {
                seo = FillData(dr);
            }

            return seo;
        }


        public Seo FillData(DataRow dr)
        {
            return new Seo()
            {
                Id = int.Parse(dr["Id"].ToString()),
                Title = dr["Title"].ToString(),
                Keyword = dr["Keyword"].ToString(),
                Description = dr["Description"].ToString(),
                WebMenuId = int.Parse(dr["WebMenuId"].ToString())
            };
        }
    }
}