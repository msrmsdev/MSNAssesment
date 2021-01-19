using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using CIBDigiTechAssessment.MVC.ViewModel;
using CIBDigiTechAssessment.WebAPI;
using CIBDigiTechAssessment.MVC.Client;
using System.Web.Script.Serialization;

namespace CIBDigiTechAssessment.MVC.Controllers
{
    public class PhoneBookController : Controller
    {
        private PhoneBookDBEntities db = new PhoneBookDBEntities();

        // GET: PhoneBook
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public JsonResult Create(string PhoneBooksJson)
        {
            if (ModelState.IsValid)
            {
                var js = new JavaScriptSerializer();
                CreateUpdatePhoneBookViewModel[] pvm = js.Deserialize<CreateUpdatePhoneBookViewModel[]>(PhoneBooksJson);
                if (pvm != null)
                {
                    PhoneBookClient pbc = new PhoneBookClient();
                    var error = ValidateData(pvm[0]);
                    if (error != string.Empty)
                        return Json(new { Success = false, Error = error }, JsonRequestBehavior.AllowGet);

                    Models.PhoneBook entity = new Models.PhoneBook();
                    AssignValues(entity, pvm[0]);
                    bool result = pbc.Create(entity);
                    return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
        }


        private void AssignValues(Models.PhoneBook entity, CreateUpdatePhoneBookViewModel pvm)
        {
            entity.FirstName = pvm.FirstName;
            entity.LastName = pvm.LastName;
            entity.Email = pvm.Email;
            entity.Contact = pvm.Contact;
            entity.Address = pvm.Address;
        }


        private string ValidateData(CreateUpdatePhoneBookViewModel pvm)
        {
            string error = string.Empty;
            if (pvm.FirstName == string.Empty)
            {
                error += "Please enter FirstName.";
            }
            if (pvm.LastName == string.Empty)
            {
                error += "Please enter LastName.";
            }
            if (pvm.Email == string.Empty)
            {
                error += "Please enter Email.";
            }
            if (pvm.Address == string.Empty)
            {
                error += "Please enter Address.";
            }
            return error;
        }

        public ActionResult LoadData()
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data    
                var customerData = (from tempcustomer in db.PhoneBooks
                                    select tempcustomer);

                //Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);
                }
                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.FirstName == searchValue
                    || m.LastName == searchValue || m.Contact == searchValue
                    );
                }

                //total number of rows count     
                recordsTotal = customerData.Count();
                //Paging     
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                throw;
            }
        }
    }
}