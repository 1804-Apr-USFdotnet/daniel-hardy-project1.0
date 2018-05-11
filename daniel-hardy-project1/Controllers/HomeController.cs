using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace daniel_hardy_project1.Controllers
{
    public class HomeController : Controller
    {
        BusinessLibrary bl = new BusinessLibrary();
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Models.Resturant resturant)
        {
            try
            {
                bl.addResturant(resturant);
                //RedirectToAction("GetAll", "Home"); <-- doesn't work!
                Response.Redirect("~/Home/GetAll");
            }
            catch (Exception ex)
            {
                //NLog goes here
                logger.LogException(NLog.LogLevel.Error, "Controller: Function: Update: " + ex.Message, ex);
                return View();
            }
            return View();
        }

        public ActionResult Details(int id)
        {

            return View(bl.GetResturantByID(id));
        }
        public ActionResult Edit(int id)
        {
            return View(bl.GetReviewbyID(id));
        }

        [HttpPost]
        public ActionResult Edit(Models.Review rev)
        {
            try
            {
                bl.updateReview(rev);
                Response.Redirect("~/Home/Details/" + rev.rs_id);
            }

            catch (Exception ex)
            {
                logger.LogException(NLog.LogLevel.Error, "Controller: Function: Edit: " + ex.Message, ex);
                return View();
            }
            return View();
        }


        public ActionResult AddReview(Models.Review review)
        {
            try
            {
                bl.addReview(review);
                Response.Redirect("~/Home/Details/" + review.rs_id);
            }
            catch (Exception ex)
            {
                logger.LogException(NLog.LogLevel.Error, "Controller: Function: AddReview: " + ex.Message, ex);
                return View();
            }
            return View();
        }

        public ActionResult Name()
        {
            return View(bl.getResturantsbyName());
        }
        public ActionResult State()
        {
            return View(bl.getResturantsbyState());
        }

        [HttpPost]
        public ActionResult Search(string partial)
        {
            return View(bl.SearchRestutants(partial));
        }
        public ActionResult Update(int id)
        {
            return View(bl.GetResturantByID(id));
        }

        [HttpPost]
        public ActionResult Update(Models.Resturant resturant)
        {
            try
            {
                bl.updateResturant(resturant);
                Response.Redirect("~/Home/GetAll");
            }
            catch (Exception ex)
            {
                logger.LogException(NLog.LogLevel.Error, "Controller: Function: Update: " + ex.Message, ex);
                return View();
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            return View(bl.GetResturantByID(id));
        }

        public ActionResult DeleteReview(int id)
        {
            return View(bl.GetReviewbyID(id));
        }

        [HttpPost]
        public ActionResult Delete(Models.Resturant resturant)
        {
            try
            {
                bl.deleteResturant(resturant);
                Response.Redirect("~/Home/GetAll");
            }
            catch (Exception ex)
            {
                //NLog goes here
                logger.LogException(NLog.LogLevel.Error, "Controller: Function: Delete: " + ex.Message, ex);
                return View();
            }
            return View();

        }

        [HttpPost]
        public ActionResult DeleteReview(Models.Review review)
        {
            ViewBag.id = review.rs_id;
            try
            {
                bl.deleteReview(review);
                Response.Redirect("~/Home/Details/" + review.rs_id);
            }
            catch (Exception ex)
            {
                //NLog goes here
                logger.LogException(NLog.LogLevel.Error, "Controller: Function: DeleteReview: " + ex.Message, ex);
                return View();
            }
            return View();

        }

        public ActionResult GetAll()
        {
            return View(bl.getAllResturants());
        }

        public ActionResult getTop()
        {
            return View(bl.getTopResturants());
        }

    }
}