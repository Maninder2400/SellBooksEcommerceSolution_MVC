using SellBooks.DataAccess.Data;
using SellBooks.DataAccess.Repository.IRepository;
using SellBooks.Models;
using SellBooks.Models.ViewModels;
using SellBooks.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SellBooksEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> CompanyList = _unitOfWork.Company.GetAll().ToList();
            return View(CompanyList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                //insert
                return View(new Company());
            }
            else
            {
                //update or edit
                Company company = _unitOfWork.Company.Get(u => u.Id == id);
                return View(company);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                
                if (company.Id == 0) {
                    _unitOfWork.Company.Add(company);
                    TempData["success"] = "Company created successfully";
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                    TempData["success"] = "Company updated successfully";
                }
                _unitOfWork.Save();
                
                return RedirectToAction("Index");
            }
            else
            {
                return View(company);
            }

        }

        //public IActionResult DeleteImage(int imageId)
        //{
        //    var imageToBeDeleted = _unitOfWork.CompanyImage.Get(u => u.Id == imageId);
        //    int companyId = imageToBeDeleted.CompanyId;
        //    if (imageToBeDeleted != null)
        //    {
        //        if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
        //        {
        //            var oldImagePath =
        //                           Path.Combine(_webHostEnvironment.WebRootPath,
        //                           imageToBeDeleted.ImageUrl.TrimStart('\\'));

        //            if (System.IO.File.Exists(oldImagePath))
        //            {
        //                System.IO.File.Delete(oldImagePath);
        //            }
        //        }

        //        _unitOfWork.CompanyImage.Remove(imageToBeDeleted);
        //        _unitOfWork.Save();

        //        TempData["success"] = "Deleted successfully";
        //    }

        //    return RedirectToAction(nameof(Upsert), new { id = companyId });
        //}

        //Edit and create are combined 
        //public IActionResult Edit(int? id)
        //{
        //    if (id == 0 || id == null)
        //    {
        //        return NotFound();
        //    }
        //    Company? companyFromDb = _unitOfWork.Company.Get(u => u.Id == id);//works on the primary key for searching a record
        //                                                                         //Company? companyFromDb1 = _db.Catagories.FirstOrDefault(x => x.Id == id);//can work on any field of the table for searching a record if not found returns null
        //                                                                         //Company? companyFromDb2 = _db.Catagories.Where(u => u.Id == id).FirstOrDefault();//if we have several conditions to find a record in the db and then return all or first object

        //    if (companyFromDb == null) { return NotFound(); }
        //    return View(companyFromDb);
        //}
        //[HttpPost]
        //public IActionResult Edit(Company company)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Company.Update(company);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Company Edited Successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View(company);
        //}

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> CompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = CompanyList });    
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if (companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}

