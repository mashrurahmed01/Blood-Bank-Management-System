using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Models
{
    public class DonationCountVM
    {
        public string? FullName { get; set; }
        public int TotalDonations { get; set; }
    }
}
