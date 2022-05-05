using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace StudentAdmissionManagement.Controllers
{
    [Route("api/[controller]")]
    public class StudentAdmissionController : Controller
    {
        [HttpGet]
        public IEnumerable<StudenAdmissionDetailsModel> Get()
        {
            //var obj1 = new StudenAdmissionDetailsModel({
            //    StudentID = 1,
            //    StudentName = "Adam",
            //    StudentClass = "X",
            //    DateOfJoining = DateTime.Now
            //});
            var obj1 = new StudenAdmissionDetailsModel();
            var obj2 = new StudenAdmissionDetailsModel();
            var obj3 = new StudenAdmissionDetailsModel
            {
                StudentID = 3, StudentName ="Tran Chan", StudentClass ="Z", DateOfJoining=DateTime.Now,
            };

            obj1.StudentID = 1;
            obj2.StudentID = 2;

            obj1.StudentName = "Adam";
            obj2.StudentName = "Brad";

            obj1.StudentClass = "X";
            obj2.StudentClass = "Y";

            obj1.DateOfJoining = obj2.DateOfJoining = DateTime.Now;

            List<StudenAdmissionDetailsModel> listObj = 
                new List<StudenAdmissionDetailsModel> { obj1, obj2, obj3 };

            return listObj;
        }

        // GET: StudentAdmissionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentAdmissionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentAdmissionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentAdmissionController/Create
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

        // GET: StudentAdmissionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentAdmissionController/Edit/5
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

        // GET: StudentAdmissionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentAdmissionController/Delete/5
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
