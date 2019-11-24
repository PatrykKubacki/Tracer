using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tracer.Data;
using Tracer.Models;
using Tracer.Repository;

namespace Tracer.Controllers
{
    [Authorize(Roles = "administrator")]
    public class ElementsController : Controller
    {
        readonly IElementsRepostiory<Element> _elementsRepostiory;
        readonly ICategoriesRepository<Category> _categoriesRepository;

        public ElementsController(IElementsRepostiory<Element> elementsRepostiory, ICategoriesRepository<Category> categoriesRepository)
        {
            _elementsRepostiory = elementsRepostiory;
            _categoriesRepository = categoriesRepository;
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var element = _elementsRepostiory.Elements.FirstOrDefault(e => e.ElementId == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoriesRepository.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Element element)
        {
            if (ModelState.IsValid)
            {
                _elementsRepostiory.Add(element);
                return RedirectToAction("Index","Home");
            }
            ViewData["CategoryId"] = new SelectList(_categoriesRepository.Categories, "CategoryId", "Name");
            return View(element);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var element = _elementsRepostiory.Elements.FirstOrDefault(x => x.ElementId == id);
            if (element == null)
                return NotFound();

            ViewData["CategoryId"] = new SelectList(_categoriesRepository.Categories, "CategoryId", "Name");
            return View(element);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Element element)
        {
            if (id != element.ElementId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _elementsRepostiory.Update(element);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_elementsRepostiory.ElementExists(element.ElementId))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction("Index","Home");
            }
            ViewData["CategoryId"] = new SelectList(_categoriesRepository.Categories, "CategoryId", "Name");
            return View(element);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var element = _elementsRepostiory.Elements.FirstOrDefault(e => e.ElementId == id);
            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var element = _elementsRepostiory.Elements.FirstOrDefault(e => e.ElementId == id);
            _elementsRepostiory.Delete(element);
            return RedirectToAction("Index","Home");
        }

    }
}
