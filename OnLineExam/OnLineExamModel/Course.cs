using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineExamModel
{
    //考试科目类
    [Serializable]
    public class Course
    {
        #region 私有成员

        private int _departmentId;		
        private string _departmentName;		//部门ID

        public int DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }
       	//部门名       

        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }

        #endregion 私有成员
    }
}
