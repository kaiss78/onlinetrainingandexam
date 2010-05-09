using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using OnLineExamBLLWS.DALWS_Exercise;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// BLLWS_Exercise 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_Exercise : System.Web.Services.WebService
    {
        DALWS_Exercise.DALWS_Exercise service = new DALWS_Exercise.DALWS_Exercise();

        [WebMethod]
        public DataSet QueryAllExercise()
        {
            return service.QueryAllExercise();
        }

        //修改试卷状态
        [WebMethod]
        public bool UpdateExercises(int spp)
        {
            return service.UpdateExerciseState(spp);
        }

        //修改试卷状态
        [WebMethod]
        public bool UpdateExercises1(int spp)
        {
            return service.UpdateExerciseState1(spp);
        }

        /// <summary>
        /// 根据PaperId删除试卷
        /// </summary>
        /// <param name="PaperId"></param>
        /// <returns></returns>
        [WebMethod]
        public bool DeleteExercise(int ExerciseId)
        {
            return service.DeleteExercise(ExerciseId);
        }

        /// <summary>
        /// 根据PaperId删除试卷的题
        /// </summary>
        /// <param name="PaperId"></param>
        /// <returns></returns>
        [WebMethod]
        public bool DeleteExerciseDetail(int ExerciseId)
        {
            return service.DeleteExerciseDetail(ExerciseId);
        }

        [WebMethod]
        public DataSet GetAllExerciseSing(int ExerciseId, string sb)
        {
            return service.GetAllExerciseSing(ExerciseId, sb);
        }

        [WebMethod]
        public DataSet GetAllExerciseSingMark(int ExerciseId, string sb)
        {
            return service.GetAllExerciseSingMark(ExerciseId, sb);
        }

        [WebMethod]
        public DataSet GetAllExerciseMult(int ExerciseId, string sb)
        {
            return service.GetAllExerciseMult(ExerciseId, sb);
        }

        [WebMethod]
        public DataSet GetAllExerciseMultMark(int ExerciseId, string sb)
        {
            return service.GetAllExerciseMultMark(ExerciseId, sb);
        }

        [WebMethod]
        public DataSet GetAllExerciseJudg(int ExerciseId, string sb)
        {
            return service.GetAllExerciseJudg(ExerciseId, sb);
        }

        [WebMethod]
        public DataSet GetAllExerciseJudgMark(int ExerciseId, string sb)
        {
            return service.GetAllExerciseJudgMark(ExerciseId, sb);
        }

        [WebMethod]
        public DataSet GetAllExerciseFill(int ExerciseId, string sb)
        {
            return service.GetAllExerciseFill(ExerciseId, sb);
        }

        [WebMethod]
        public DataSet GetAllExerciseFillMark(int ExerciseId, string sb)
        {
            return service.GetAllExerciseFillMark(ExerciseId, sb);
        }

        [WebMethod]
        public DataSet GetAllExerciseQues(int ExerciseId, string sb)
        {
            return service.GetAllExerciseQues(ExerciseId, sb);
        }

        [WebMethod]
        public DataSet GetAllExerciseQuesMark(int ExerciseId, string sb)
        {
            return service.GetAllExerciseQuesMark(ExerciseId, sb);
        }

        [WebMethod]
        public DataSet QueryExercise()
        {
            return service.QueryExercise();
        }

        [WebMethod]
        public string GetExerciseType(int id)
        {
            return service.GetExerciseType(id);
        }

        [WebMethod]
        public List<Exercise> SelectExercise()
        {
            return service.SelectExercise().ToList();
        }
    }
}
