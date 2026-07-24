using BloodBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    public class ReportsController : Controller
    {
        private readonly BloodBankDbContext _context;

        public ReportsController(BloodBankDbContext context)
        {
            _context = context;
        }

        public IActionResult Filter(string bloodGroup)
        {
            var donors = _context.Donors.AsQueryable();

            if (!string.IsNullOrEmpty(bloodGroup))
            {
                donors = donors.Where(d => d.BloodGroup == bloodGroup);
            }

            return View(donors.ToList());
        }
    
    public IActionResult Sort()
        {
            var donors = _context.Donors
                .OrderByDescending(d => d.LastDonationDate)
                .ToList();

            return View(donors);
        }

        public IActionResult DonationCount()
        {
            var result = _context.Donors
                .Select(d => new DonationCountVM
                {
                    FullName = d.FullName,
                    TotalDonations = d.Donations.Count()
                })
                .ToList();

            return View(result);
        }

        public IActionResult TotalVolume()
        {
            int total = _context.Donations.Sum(d => d.VolumeMl);

            return View(total);
        }
    }
}
