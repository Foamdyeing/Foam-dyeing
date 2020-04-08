using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;

namespace BookStore.WebApp.Admins
{
    public partial class Login : System.Web.UI.Page
    {
        private UsersService bll = new UsersService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 登入按钮的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            //1. 获取账号,密码文本框的值
            string ac = this.txtAccount.Text.Trim();
            string pwd = this.txtPassword.Text.Trim();
            var user = bll.Login(ac, pwd);
            if (user == null)
            {
                Response.Write("<script>alert('账号或者密码错误');location.href='Login.aspx';</script>");
            }
            else
            {
                //登入成功的时候,我们需要进行判断是否记住这个账号和密码
                if (ckbRememberMe.Checked) //记住情况下
                {
                    //记住的情况下,我们使用 Cookie
                    //(1) 创建Cookie
                    HttpCookie userEmail_cookie = new HttpCookie("LoginOk", user.Id.ToString());
                    //(2) 设置过期时间,从当前开始计算,加上7天时间
                    userEmail_cookie.Expires = DateTime.Now.AddDays(7);
                    //(3) 生成Cookie
                    Response.Cookies.Add(userEmail_cookie);

                    //我们后台登入的时候一般会记录2个内容,1. 登入用户的信息   2. 权限信息
                    HttpCookie rolesId_cookie = new HttpCookie("RolesId", user.RolesId.ToString());
                    rolesId_cookie.Expires = DateTime.Now.AddDays(7);
                    //(3) 生成Cookie
                    Response.Cookies.Add(rolesId_cookie);
                }
                else
                {
                    //不记住的情况下,我们使用Session
                    Session["LoginOk"] = user.Id;
                    Session["RolesId"] = user.RolesId;
                }

                Response.Write("<script>alert('登入成功');location.href='main/Main.aspx'</script>");
                //如何限制后台界面内容必须是登入之后才能看到的
            }
        }
    }
}