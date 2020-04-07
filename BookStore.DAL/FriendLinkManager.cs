using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookStore.Model;

namespace BookStore.DAL
{
    public class FriendLinkManager
    {

        public bool IsExist(string title)
        {
            string sql = "select * from FriendLink where Title = @Title";
            SqlParameter[] param =
            {
                new SqlParameter("@Title",title) 
            };
            var dt = SqlHelper.Query(sql, param);
            return dt.Rows.Count > 0;
        }

        public int Add(FriendLink model)
        {
            string sql = "insert into FriendLink(Title,Link,IsShow) values(@Title,@Link,@IsShow)";
            SqlParameter[] param =
            {
                new SqlParameter("@Title",model.Title),
                new SqlParameter("@Link",model.Link),
                new SqlParameter("@IsShow",model.IsShow)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }


        public int Edit(FriendLink model)
        {
            string sql = "update FriendLink set Title=@Title,Link=@Link,IsShow=@IsShow where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Title",model.Title),
                new SqlParameter("@Link",model.Link),
                new SqlParameter("@IsShow",model.IsShow),
                new SqlParameter("@Id",model.Id) 
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public int Delete(FriendLink model)
        {
            string sql = "delete from FriendLink where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",model.Id)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }


        public List<FriendLink> GetFriendLinkList()
        {
            string sql = "select * from FriendLink";
            var dt = SqlHelper.Query(sql, null);
            var list = new List<FriendLink>();
            foreach (DataRow dr in dt.Rows)
            {
                FriendLink f = FillData(dr);
                list.Add(f);
            }

            return list;
        }

        public List<FriendLink> GetFriendLinkListByTitle(string title)
        {
            string sql = "select * from FriendLink where Title like '%"+title+"%'";
            var dt = SqlHelper.Query(sql, null);
            var list = new List<FriendLink>();
            foreach (DataRow dr in dt.Rows)
            {
                FriendLink f = FillData(dr);
                list.Add(f);
            }

            return list;
        }

        public List<FriendLink> GetFriendLinkListByIsShow(bool isShow)
        {
            string sql = "select * from FriendLink where isShow = @isShow";
            SqlParameter[] param =
            {
                new SqlParameter("@IsShow",isShow)
            };
            var dt = SqlHelper.Query(sql, param);
            var list = new List<FriendLink>();
            foreach (DataRow dr in dt.Rows)
            {
                FriendLink f = FillData(dr);
                list.Add(f);
            }

            return list;
        }


        public FriendLink GetFriendLink(int id)
        {
            string sql = "select * from FriendLink where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",id) 
            };
            var dt = SqlHelper.Query(sql, param);
            FriendLink f = null;
            foreach (DataRow dr in dt.Rows)
            {
                f = FillData(dr);
            }

            return f;
        }

        public FriendLink FillData(DataRow dr)
        {
            return new FriendLink()
            {
                Id = int.Parse(dr["Id"].ToString()),
                Title = dr["Title"].ToString(),
                Link = dr["Link"].ToString(),
                IsShow = bool.Parse(dr["IsShow"].ToString())
            };
        }
    }
}