﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using localhost;

public partial class Web_PaperAnalysis : System.Web.UI.Page
{

    BLLWS_User userService = new BLLWS_User();
    BLLWS_Paper paperService = new BLLWS_Paper();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "试卷统计分析";
      if (!Page.IsPostBack)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string userId = Session["userID"].ToString();
                string userName = userService.GetUserName(userId);
                Label i = (Label)Page.Master.FindControl("labUser");
                i.Text = userName;

                InitData();
            }
        }

    }

    protected void InitData()
    {
        DataSet ds = paperService.QueryAllPaper();
      //  DataTable[] table = new DataTable[1];
      //  table[0].Columns.Add("平均成绩");
      //  DataRow row = table[0].NewRow();
      //  row[0] = "ss";
      //  table[0].Rows.Add(row);
      //  ds.Tables.AddRange(table);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            lblMessage.Text = "没有试卷!";
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        InitData();

    }
    //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    GridView1.EditIndex = -1;
    //    InitData();
    //}
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string javasc = @"window.onload=function(){alert('删除成功')}";
        int ID = int.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString()); //取出要删除记录的主键值
        if (paperService.DeletePaper(ID) || paperService.DeletePaperDetail(ID))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ddd", javasc, true);
        }
        Response.Redirect("PaperLists.aspx");
    }
    //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    GridView1.EditIndex = e.NewEditIndex;  //GridView编辑项索引等于单击行的索引
    //    InitData();
    //}
    //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    string javasc = @"window.onload=function(){alert('更新修改成功')}";
    //    int ID = int.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString()); //取出要修改记录的主键值
    //    byte ddlpaper = byte.Parse(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlPaperState")).SelectedValue);
    //    if (ddlpaper == 0)
    //    {
    //        if (paperService.UpdatePate(ID))
    //        {
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "ddd", javasc, true);
    //            Response.Redirect("PaperLists.aspx");
    //        }
    //    }
    //    if (ddlpaper == 1)
    //    {
    //        if (paperService.UpdatePate1(ID))
    //        {
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "ddd", javasc, true);
    //            Response.Redirect("PaperLists.aspx");
    //        }
    //    }

    //}
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[4].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除吗?')");
            }

        }
        int i;
        //执行循环，保证每条数据都可以更新
        for (i = 0; i < GridView1.Rows.Count; i++)
        {
            //首先判断是否是数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标停留时更改背景色
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='Aqua'");
                //当鼠标移开时还原背景色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#CCFF66'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
}
