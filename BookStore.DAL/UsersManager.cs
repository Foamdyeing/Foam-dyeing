using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookStore.Model;

namespace BookStore.DAL
{
    public class UsersManager
    {
        /// <summary>
        /// 判断电子邮件是否存在的
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsExist(string email)
        {
            string sql = "select * from Users where Email = @Email";
            SqlParameter[] param =
            {
                new SqlParameter("@Email",email) 
            };
            return SqlHelper.Query(sql, param).Rows.Count > 0;
        }


        public int Add(Users u)
        {
            string sql = "insert into Users(Email,Password,NickName,Photo,CreateTime,RolesId) values(@Email,@Password,@NickName,@Photo,@CreateTime,@RolesId)";
            SqlParameter[] param =
            {
                new SqlParameter("@Email",u.Email),
                new SqlParameter("@Password",u.Password),
                new SqlParameter("@NickName",u.NickName),
                new SqlParameter("@Photo",u.Photo),
                new SqlParameter("@CreateTime",u.CreateTime),
                new SqlParameter("@RolesId",u.RolesId)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }


        public int Edit(Users u)
        {
            string sql = "update Users set Email=@Email,Password=@Password,NickName=@NickName,Photo=@Photo,CreateTime=@CreateTime,RolesId=@RolesId where Id=@Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Email",u.Email),
                new SqlParameter("@Password",u.Password),
                new SqlParameter("@NickName",u.NickName),
                new SqlParameter("@Photo",u.Photo),
                new SqlParameter("@CreateTime",u.CreateTime),
                new SqlParameter("@RolesId",u.RolesId),
                new SqlParameter("@Id",u.Id) 
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public int Delete(Users u)
        {
            string sql = "delete from Users where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",u.Id)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public List<Users> GetUsersList()
        {
            string sql = "select Id,Email,Password,NickName,Photo,CreateTime,RolesId from Users order by CreateTime desc";
            var dt = SqlHelper.Query(sql, null);
            var list = new List<Users>();
            foreach (DataRow item in dt.Rows)
            {
                Users u = new Users()
                {
                    Id = int.Parse(item["Id"].ToString()),
                    Email = item["Email"].ToString(),
                    Password = item["Password"].ToString(),
                    NickName = item["NickName"].ToString(),
                    Photo = item["Photo"].ToString(),
                    CreateTime = DateTime.Parse(item["CreateTime"].ToString()),
                    RolesId = int.Parse(item["RolesId"].ToString())
                };
                list.Add(u);
            }

            return list;
        }
        //.net framework 4.5 --> C# 5.0
        //.net framework 4.6 --> C# 6.0
        //.net framework 4.7 --> C# 7.0
        //.net framework 4.8 --> C# 8.0
        public List<Users> GetUsersListByNickName(string nickname)
        {
            string sql = "select Id,Email,Password,NickName,Photo,CreateTime,RolesId from Users where NickName like '%"+nickname+"%' order by CreateTime desc";
            var dt = SqlHelper.Query(sql, null);
            var list = new List<Users>();
            foreach (DataRow item in dt.Rows)
            {
                Users u = new Users()
                {
                    Id = int.Parse(item["Id"].ToString()),
                    Email = item["Email"].ToString(),
                    Password = item["Password"].ToString(),
                    NickName = item["NickName"].ToString(),
                    Photo = item["Photo"].ToString(),
                    CreateTime = DateTime.Parse(item["CreateTime"].ToString()),
                    RolesId = int.Parse(item["RolesId"].ToString())
                };
                list.Add(u);
            }

            return list;
        }


        public Users GetUsersById(int id)
        {
            string sql = "select Id,Email,Password,NickName,Photo,CreateTime,RolesId from Users where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",id)
            };
            var dt = SqlHelper.Query(sql, param);

            if(dt.Rows.Count > 0)
                return new Users()
                {
                    Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                    Email = dt.Rows[0]["Email"].ToString(),
                    Password = dt.Rows[0]["Password"].ToString(),
                    NickName = dt.Rows[0]["NickName"].ToString(),
                    Photo = dt.Rows[0]["Photo"].ToString(),
                    CreateTime = DateTime.Parse(dt.Rows[0]["CreateTime"].ToString()),
                    RolesId = int.Parse(dt.Rows[0]["RolesId"].ToString())
                };
            return null;
        }


        public Users Login(string email, string pwd)
        {
            string sql = "select Id,Email,Password,NickName,Photo,CreateTime,RolesId from Users where Email = @Email and Password = @Password";
            SqlParameter[] param =
            {
                new SqlParameter("@Email",email),
                new SqlParameter("@Password",pwd)
            };
            var dt = SqlHelper.Query(sql, param);
            if (dt.Rows.Count > 0)
                return new Users()
                {
                    Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                    Email = dt.Rows[0]["Email"].ToString(),
                    Password = dt.Rows[0]["Password"].ToString(),
                    NickName = dt.Rows[0]["NickName"].ToString(),
                    Photo = dt.Rows[0]["Photo"].ToString(),
                    CreateTime = DateTime.Parse(dt.Rows[0]["CreateTime"].ToString()),
                    RolesId = int.Parse(dt.Rows[0]["RolesId"].ToString())
                };
            return null;
        }

        /// <summary>
        /// 根据权限编号进行查询
        /// </summary>
        /// <param name="rolesId"></param>
        /// <returns></returns>
        public List<Users> GetUsersByRolesId(int rolesId)
        {
            string sql = "select Id,Email,Password,NickName,Photo,CreateTime,RolesId from Users where RolesId = @RolesId";

            SqlParameter[] param =
            {
                new SqlParameter("@RolesId",rolesId) 
            };
            var dt = SqlHelper.Query(sql, param);
            var list = new List<Users>();
            foreach (DataRow item in dt.Rows)
            {
                Users u = new Users()
                {
                    Id = int.Parse(item["Id"].ToString()),
                    Email = item["Email"].ToString(),
                    Password = item["Password"].ToString(),
                    NickName = item["NickName"].ToString(),
                    Photo = item["Photo"].ToString(),
                    CreateTime = DateTime.Parse(item["CreateTime"].ToString()),
                    RolesId = int.Parse(item["RolesId"].ToString())
                };
                list.Add(u);
            }

            return list;
        }
    }
}