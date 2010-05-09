using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineExamModel
{
    [Serializable]
    public class Exercise
    {
        #region 私有成员
        private int _ExerciseID;                                               //试卷编号
        private int _courseID;                                              //科目编号 
        private string _ExerciseName;                                          //试卷名称  
        private byte _ExerciseState;                                           //试卷状态
        private string _type;
        private string _userid;
        private string _state;

        #endregion 私有成员

        #region 属性

        public int ExerciseID
        {
            set
            {
                this._ExerciseID = value;
            }
            get
            {
                return this._ExerciseID;
            }
        }
        public int CourseID
        {
            set
            {
                this._courseID = value;
            }
            get
            {
                return this._courseID;
            }
        }
        public string ExerciseName
        {
            set
            {
                this._ExerciseName = value;
            }
            get
            {
                return this._ExerciseName;
            }
        }
        public byte ExerciseState
        {
            set
            {
                this._ExerciseState = value;
            }
            get
            {
                return this._ExerciseState;
            }
        }
        public string Type
        {
            set
            {
                this._type = value;
            }
            get
            {
                return this._type;
            }
        }
        public string UserID
        {
            set
            {
                this._userid = value;
            }
            get
            {
                return this._userid;
            }
        }
        public string state
        {
            set
            {
                this._state = value;
            }
            get
            {
                return this._state;
            }
        }

        #endregion 属性

    }
}
