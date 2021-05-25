using Microsoft.AspNetCore.Mvc;
using System;

namespace NerdStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected Guid ClientId = Guid.Parse("9AABCCBB-46A7-43E8-BEC3-D316FFCB34D6");
    }
}