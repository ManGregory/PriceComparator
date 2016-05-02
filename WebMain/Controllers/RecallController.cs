﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMain.Models;

namespace WebMain.Controllers
{
    public class RecallController : Controller
    {
        // GET: Recall
        public ActionResult Index(string labs)
        {
            return View(new RecallViewModel
            {
                Labs = GetLabs(),
                Recalls = GetRecalls(labs)
            });
        }

        private IEnumerable<RecallModel> GetRecalls(string labs)
        {
            string pathToRecalls = HttpContext.Server.MapPath("~/Content/recalls.txt");
            var lines = System.IO.File.ReadAllLines(pathToRecalls);
            return (from line in lines
                select line.Split(new[] {"~"}, StringSplitOptions.RemoveEmptyEntries)
                into recallParts
                where recallParts.Length >= 2
                select new RecallModel {LabName = recallParts[0], Recall = recallParts[1]})
                .Where(
                    r =>
                        (!string.IsNullOrWhiteSpace(labs) && r.LabName.ToLower() == labs.ToLower()) ||
                        string.IsNullOrWhiteSpace(labs));
        }

        private SelectList GetLabs()
        {
            return new SelectList(new []
            {
                new SelectListItem {Value = "Bioplus", Text = "Bioplus"},
                new SelectListItem {Value = "Medlabtest", Text = "Medlabtest"},
                new SelectListItem {Value = "Nikolab", Text = "Nikolab"},
                new SelectListItem {Value = "Dnk", Text = "Dnk"},
                new SelectListItem {Value = "Dila", Text = "Dila"},
                new SelectListItem {Value = "Synevo", Text = "Synevo"},
                new SelectListItem {Value = "Uldc", Text = "Uldc"}
            }, "Value", "Text");
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }   
        }
    }
}
