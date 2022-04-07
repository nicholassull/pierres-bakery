using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PierresBakery.Models;
using System.Threading.Tasks;
using PierresBakery.ViewModels;

namespace PierresBakery.Controllers
{
  public class AccountController : Controller
  {
    private readonly PierresBakeryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PierresBakeryContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }
  }
}