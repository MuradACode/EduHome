using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using Business.Services;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService service)
        {
            _sliderService = service;
        }

        //GET: Sliders
        public async Task<IActionResult> Index()
        {
            List<Slider> datas = new List<Slider>();

            try
            {
                 datas = await _sliderService.GetAll();
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }
            return View(datas);
        }

        // GET: SlidersController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Slider data = new Slider();

            try
            {
                data = await _sliderService.Get(id);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }
            return View(data);
        }

        // GET: SlidersController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SlidersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider data)
        {
            try
            {
                await _sliderService.Create(data);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }
        }

        // GET: SlidersController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var data = await _sliderService.Get(id);
            return View(data);
        }

        // POST: SlidersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Slider data)
        {
            try
            {
                await _sliderService.Update(data);
                
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }
        }

        // GET: SlidersController/Delete/5
        public IActionResult Delete(int? id)
        {
            return View();
        }

        // POST: SlidersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, Slider data)
        {
            try
            {
                await _sliderService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }
        }
    }
}
