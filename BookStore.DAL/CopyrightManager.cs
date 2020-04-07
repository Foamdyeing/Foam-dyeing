using System.Data.SqlClient;
using BookStore.Model;

namespace BookStore.DAL
{
    public class CopyrightManager
    {
        public bool IsExist()
        {
            string sql = "select top 1 (*) from Copyright";
            var dt = SqlHelper.Query(sql, null);
            return dt.Rows.Count > 0;
        }


        public int Add(Copyright model)
        {
            string sql = "insert into Copyright(Title,Content,Address,Tel1,Tel2,QQ1,QQ2,Wechat,Email,Logo,Images)";
            sql += " values(@Title,@Content,@Address,@Tel1,@Tel2,@QQ1,@QQ2,@Wechat,@Email,@Logo,@Images)";

            SqlParameter[] param =
            {
                new SqlParameter("@Title",model.Title),
                new SqlParameter("@Content",model.Content),
                new SqlParameter("@Address",model.Address),
                new SqlParameter("@Tel1",model.Tel1),
                new SqlParameter("@Tel2",model.Tel2),
                new SqlParameter("@QQ1",model.QQ1),
                new SqlParameter("@QQ2",model.QQ2),
                new SqlParameter("@Wechat",model.Wechat),
                new SqlParameter("@Email",model.Email),
                new SqlParameter("@Logo",model.Logo),
                new SqlParameter("@Images",model.Images)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public int Edit(Copyright model)
        {
            string sql =
                "update Copyright set Title=@Title,Content=@Content,Address=@Address,Tel1=@Tel1,Tel2=@Tel2,QQ1=@QQ1,QQ2=@QQ2,Wechat=@Wechat,Logo=@Logo,Images=@Images where Id = @Id";

            SqlParameter[] param =
            {
                new SqlParameter("@Title",model.Title),
                new SqlParameter("@Content",model.Content),
                new SqlParameter("@Address",model.Address),
                new SqlParameter("@Tel1",model.Tel1),
                new SqlParameter("@Tel2",model.Tel2),
                new SqlParameter("@QQ1",model.QQ1),
                new SqlParameter("@QQ2",model.QQ2),
                new SqlParameter("@Wechat",model.Wechat),
                new SqlParameter("@Email",model.Email),
                new SqlParameter("@Logo",model.Logo),
                new SqlParameter("@Images",model.Images),
                new SqlParameter("@Id",model.Id)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }



        public Copyright GetCopyright()
        {
            string sql = "select top 1 * from Copyright";
            var dt = SqlHelper.Query(sql, null);
            
            if (dt.Rows.Count > 0)
            {
                return new Copyright()
                {
                    Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                    Title = dt.Rows[0]["Title"].ToString(),
                    Content = dt.Rows[0]["Content"].ToString(),
                    Address = dt.Rows[0]["Address"].ToString(),
                    Tel1 = dt.Rows[0]["Tel1"].ToString(),
                    Tel2 = dt.Rows[0]["Tel2"].ToString(),
                    QQ1 = dt.Rows[0]["QQ1"].ToString(),
                    QQ2 = dt.Rows[0]["QQ2"].ToString(),
                    Wechat = dt.Rows[0]["Wechat"].ToString(),
                    Email = dt.Rows[0]["Email"].ToString(),
                    Logo = dt.Rows[0]["Logo"].ToString(),
                    Images = dt.Rows[0]["Images"].ToString()
                };
            }
            else
            {
                return null;
            }

        }
    }
}