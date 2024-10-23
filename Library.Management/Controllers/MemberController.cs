﻿using Library.Management.Service.InterfaceService;
using Microsoft.AspNetCore.Mvc;

namespace Library.Management.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _MemberService;
        public MemberController(IMemberService MemberService)
        {
            _MemberService = MemberService;
            
        }
        //GET: Members
       public async Task<IActionResult> Index()
        {
            try
            {
                var memberList = await _MemberService.GetAllAsync();
                return View(memberList);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "An error occured while loading member list";
                return View("Error");
            }
        }
        //GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || id == 0)
            {
                TempData["ErrorMessage"] = "Member id was not provided";
                return View("Not Found");
            }
            try
            {
                var member = await _MemberService.GetById(id.Value);
                return View(member);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Error");
            }
        }
    }
}
