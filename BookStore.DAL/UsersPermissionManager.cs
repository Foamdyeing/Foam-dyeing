using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookStore.Model;

namespace BookStore.DAL
{
    public class UsersPermissionManager
    {
        public int Add(UsersPermission model)
        {
            string sql = "insert into UsersPermission(RolesId,SystemMenuId) values(@RolesId,@SystemMenuId)";
            SqlParameter[] param =
            {
                new SqlParameter("@RolesId",model.RolesId),  
                new SqlParameter("@SystemMenuId",model.SystemMenuId)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);

        }

        public int Edit(UsersPermission model)
        {
            string sql = "update UsersPermission set RolesId = @RolesId,SystemMenuId=@SystemMenuId where Id=@Id";
            SqlParameter[] param =
            {
                new SqlParameter("@RolesId",model.RolesId),
                new SqlParameter("@SystemMenuId",model.SystemMenuId),
                new SqlParameter("@Id",model.Id)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);

        }

        public int Delete(UsersPermission model)
        {
            string sql = "delete from UsersPermission where Id=@Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",model.Id)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);

        }

        public List<UsersPermission> GetUsersPermissionsByRolesId(int rid)
        {
            string sql = "select Id,RolesId,SystemMenuId from UsersPermission where RolesId = @RolesId";
            SqlParameter[] param =
            {
                new SqlParameter("@RolesId",rid) 
            };
            var dt = SqlHelper.Query(sql, param);
            var list = new List<UsersPermission>();
            foreach (DataRow dr in dt.Rows)
            {
                UsersPermission up= new UsersPermission()
                {
                    Id = int.Parse(dr["Id"].ToString()),
                    RolesId = int.Parse(dr["RolesId"].ToString()),
                    SystemMenuId = int.Parse(dr["SystemMenuId"].ToString())
                };
                list.Add(up);
            }

            return list;
        }
    }
}