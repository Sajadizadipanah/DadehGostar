using DadehGostar.Data;
using DadehGostar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DadehGostar.Pages;

public class ContactModel : PageModel
{
    public void OnGet()
    {
    }
    public ContactModel(ApplicationDbContext context)
    {
        _context = context;
    }
    private readonly ApplicationDbContext? _context;

    [BindProperty]
    [Required(ErrorMessage = "وارد کردن نام الزامی است")]
    public string FullName { get; set; } = string.Empty;

    [BindProperty]
    [Required(ErrorMessage = "وارد کردن شماره تماس الزامی است")]
    [Phone(ErrorMessage = "شماره تماس معتبر نیست")]
    public string Phone { get; set; } = string.Empty;

    [BindProperty]
    [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    [Required(ErrorMessage = "وارد کردن پیام الزامی است")]
    [StringLength(1000, ErrorMessage = "پیام نباید بیشتر از ۱۰۰۰ کاراکتر باشد")]
    public string Message { get; set; } = string.Empty;
    public string ResultMessage { get; private set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var contactMessage = new ContactMessage
        {
            FullName = FullName,
            Phone = Phone,
            Email = Email,
            Message = Message,
            CreatedAt = DateTime.Now
        };

        _context.ContactMessages.Add(contactMessage);

        await _context.SaveChangesAsync();

        ResultMessage = "پیام شما با موفقیت ثبت شد.";

        return Page();
    }


}
