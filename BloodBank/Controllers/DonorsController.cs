
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodBank.Models;

public class DonorsController : Controller
{
    private readonly BloodBankDbContext _context;

    public DonorsController(BloodBankDbContext context)
    {
        _context = context;
    }

    // GET: DONORS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Donors.ToListAsync());
    }

    // GET: DONORS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var donor = await _context.Donors
            .FirstOrDefaultAsync(d => d.DonorId == id);

        if (donor == null)
            return NotFound();

        return View(donor);
    }

    // GET: DONORS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DONORS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    public async Task<IActionResult> Create([Bind("DonorId,FullName,BloodGroup,ContactNo,City,LastDonationDate")] Donor donor)
    {
        if (ModelState.IsValid)
        {
            _context.Add(donor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(donor);
    }

    // GET: DONORS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var donor = await _context.Donors.FindAsync(id);

        if (donor == null)
            return NotFound();

        return View(donor);
    }

    // POST: DONORS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    public async Task<IActionResult> Edit(Donor donor)
    {
        if (ModelState.IsValid)
        {
            _context.Update(donor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(donor);
    }

    // GET: DONORS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var donor = await _context.Donors
            .FirstOrDefaultAsync(d => d.DonorId == id);

        if (donor == null)
            return NotFound();

        return View(donor);
    }

    // POST: DONORS/Delete/5
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var donor = await _context.Donors.FindAsync(id);

        if (donor != null)
        {
            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool DonorExists(int? donorid)
    {
        return _context.Donors.Any(e => e.DonorId == donorid);
    }
}
