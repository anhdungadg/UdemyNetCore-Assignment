using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentAttendanceManagement.Controllers
{
    /// <summary>
    /// Controller của Student Attendance
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    //[Route("[controller]")]
    public class StudentAttendanceController : ControllerBase
    {
        private static List<StudentAttendanceDetailsModel> _studentAttendanceDetails= new List<StudentAttendanceDetailsModel>();


        /// <summary>
        /// Lấy dữ liệu danh sách sinh viên
        /// </summary>
        /// <returns>StudentAttendanceDetailsModel object</returns>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET /api/StudentAttendance/Get
        /// </remarks>
        /// <response code="200">Thật tuyệt vời không thể tin nỗi</response>
        /// <response code="500">Xong phin rồi, lo viết resignation letter đi pa</response>
        [HttpGet]
        public IEnumerable<StudentAttendanceDetailsModel> Get()
        {
            var obj1 = new StudentAttendanceDetailsModel
            {
                StudentId = 1,
                StudentName = "Adam",
                AttendencePercentage = 83.02
            };
            var obj2 = new StudentAttendanceDetailsModel
            {
                StudentId = 2,
                StudentName = "Brad",
                AttendencePercentage = 71.02
            };

            _studentAttendanceDetails.Add(obj1);
            _studentAttendanceDetails.Add(obj2);
            return _studentAttendanceDetails;
        }

        [HttpPost]
        public IEnumerable<StudentAttendanceDetailsModel> AddStudent(StudentAttendanceDetailsModel data)
        {
            _studentAttendanceDetails.Add(data);

            return _studentAttendanceDetails;
        }
    }
}
