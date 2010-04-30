using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineExamModel
{
    [Serializable]
    public class Exam
    {
        public Exam()
        {
        }

        public Exam(int examID, int courseID, int paperID, DateTime start, DateTime end)
        {
            this.ExamID = examID;
            this.CourseID = courseID;
            this.PaperID = paperID;
            this.StartTime = start;
            this.EndTime = end;
        }

        #region 属性
        public int ExamID { get; set; }
        public int CourseID { get; set; }
        public int PaperID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        #endregion 属性
    }
}
