using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentAttendanceManagement.Controllers
{
    public class StudentAttendanceController : Controller
    {
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

            List<StudentAttendanceDetailsModel> list = 
                new List<StudentAttendanceDetailsModel> { obj1, obj2 };
            return list;
        }

        // GET: StudentAttendanceController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentAttendanceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentAttendanceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentAttendanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentAttendanceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentAttendanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentAttendanceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentAttendanceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
