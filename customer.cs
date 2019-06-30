[33mcommit 7fd66817f8688294372253e7193e9380990fd053[m[33m ([m[1;36mHEAD -> [m[1;32mmaster[m[33m)[m
Author: mohsen <mohsen.amirkhani@live.com>
Date:   Sun Jun 30 19:19:35 2019 +0430

    init

[1mdiff --git a/Data/AppDbContext.cs b/Data/AppDbContext.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..2159e00[m
[1m--- /dev/null[m
[1m+++ b/Data/AppDbContext.cs[m
[36m@@ -0,0 +1,13 @@[m
[32m+[m[32musing Microsoft.EntityFrameworkCore;[m
[32m+[m[32musing razorPage.Data.Models;[m
[32m+[m[32musing razorPage.Models;[m
[32m+[m
[32m+[m[32mnamespace razorPage.Data[m
[32m+[m[32m{[m
[32m+[m[32m    public class AppDbContext : DbContext[m
[32m+[m[32m    {[m
[32m+[m[32m        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}[m
[32m+[m[32m        public DbSet<Movie> Movie { get; set; }[m
[32m+[m[32m        public DbSet<Customer> Customers { get; set; }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/Models/Customer.cs b/Models/Customer.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..3cbc15b[m
[1m--- /dev/null[m
[1m+++ b/Models/Customer.cs[m
[36m@@ -0,0 +1,11 @@[m
[32m+[m[32musing System.ComponentModel.DataAnnotations;[m
[32m+[m
[32m+[m[32mnamespace razorPage.Data.Models[m
[32m+[m[32m{[m
[32m+[m[32m    public class Customer[m
[32m+[m[32m    {[m
[32m+[m[32m        public int Id { get; set; }[m
[32m+[m[32m        [Required][m
[32m+[m[32m        public string Name { get; set; }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/Models/Movie.cs b/Models/Movie.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..c340e39[m
[1m--- /dev/null[m
[1m+++ b/Models/Movie.cs[m
[36m@@ -0,0 +1,19 @@[m
[32m+[m[32musing System;[m
[32m+[m[32musing System.ComponentModel.DataAnnotations;[m
[32m+[m[32musing System.ComponentModel.DataAnnotations.Schema;[m
[32m+[m
[32m+[m[32mnamespace razorPage.Models[m
[32m+[m[32m{[m
[32m+[m[32m    public class Movie[m
[32m+[m[32m    {[m
[32m+[m[32m        public int ID { get; set; }[m
[32m+[m[32m        public string Title { get; set; }[m
[32m+[m
[32m+[m[32m        [DataType(DataType.Date)][m
[32m+[m[32m        [Display(Name = "Released Date")][m
[32m+[m[32m        public DateTime ReleaseDate { get; set; }[m
[32m+[m[32m        public string Genre { get; set; }[m
[32m+[m[32m        [Column(TypeName = "decimal(18, 2)")][m
[32m+[m[32m        public decimal Price { get; set; }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/Pages/Create.cshtml b/Pages/Create.cshtml[m
[1mnew file mode 100644[m
[1mindex 0000000..bacc264[m
[1m--- /dev/null[m
[1m+++ b/Pages/Create.cshtml[m
[36m@@ -0,0 +1,21 @@[m
[32m+[m[32m@page[m
[32m+[m[32m@model razorPage.Pages.CreateModel[m
[32m+[m[32m@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers[m
[32m+[m[32m@{[m
[32m+[m[32m    ViewData["Title"] = "Create Customer";[m
[32m+[m[32m}[m
[32m+[m[32m<html>[m
[32m+[m[32m<body>[m
[32m+[m[32m    <p>[m
[32m+[m[32m        Enter your name.[m
[32m+[m[32m    </p>[m
[32m+[m[32m    <div asp-validation-summary="All"></div>[m
[32m+[m[32m    <form method="POST">[m
[32m+[m[32m        <div>Name:[m[41m [m
[32m+[m[32m            <input asp-for="Customer.Name" />[m
[32m+[m[32m            <span asp-validation-for="Customer.Name"></span>[m
[32m+[m[32m        </div>[m
[32m+[m[32m        <input type="submit" />[m
[32m+[m[32m    </form>[m
[32m+[m[32m</body>[m
[32m+[m[32m</html>[m
\ No newline at end of file[m
[1mdiff --git a/Pages/Create.cshtml.cs b/Pages/Create.cshtml.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..45a4910[m
[1m--- /dev/null[m
[1m+++ b/Pages/Create.cshtml.cs[m
[36m@@ -0,0 +1,33 @@[m
[32m+[m[32musing System.Threading.Tasks;[m
[32m+[m[32musing Microsoft.AspNetCore.Mvc;[m
[32m+[m[32musing Microsoft.AspNetCore.Mvc.RazorPages;[m
[32m+[m[32musing razorPage.Data;[m
[32m+[m[32musing razorPage.Data.Models;[m
[32m+[m
[32m+[m[32mnamespace razorPage.Pages[m
[32m+[m[32m{[m
[32m+[m[32m    public class CreateModel : PageModel[m
[32m+[m[32m    {[m
[32m+[m[32m        private readonly AppDbContext _db;[m
[32m+[m
[32m+[m[32m        public CreateModel(AppDbContext db)[m
[32m+[m[32m        {[m
[32m+[m[32m            _db = db;[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        [BindProperty][m
[32m+[m[32m        public Customer Customer { get; set; }[m
[32m+[m
[32m+[m[32m        public async Task<IActionResult> OnPostAsync()[m
[32m+[m[32m        {[m
[32m+[m[32m            if (!ModelState.IsValid)[m
[32m+[m[32m            {[m
[32m+[m[32m                return Page();[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            _db.Customers.Add(Customer);[m
[32m+[m[32m            await _db.SaveChangesAsync();[m
[32m+[m[32m            return RedirectToPage("/Index");[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/Pages/Edit.cshtml b/Pages/Edit.cshtml[m
[1mnew file mode 100644[m
[1mindex 0000000..109d30f[m
[1m--- /dev/null[m
[1m+++ b/Pages/Edit.cshtml[m
[36m@@ -0,0 +1,24 @@[m
[32m+[m[32m@page "{id:int}"[m
[32m+[m[32m@model razorPage.Pages.EditModel[m
[32m+[m[32m@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers[m
[32m+[m
[32m+[m[32m@{[m
[32m+[m[32m    ViewData["Title"] = "Edit Customer";[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32m<h1>Edit Customer - @Model.Customer.Id</h1>[m
[32m+[m[32m<form method="post">[m
[32m+[m[32m    <div asp-validation-summary="All"></div>[m
[32m+[m[32m    <input asp-for="Customer.Id" type="hidden" />[m
[32m+[m[32m    <div>[m
[32m+[m[32m        <label asp-for="Customer.Name"></label>[m
[32m+[m[32m        <div>[m
[32m+[m[32m            <input asp-for="Customer.Name" />[m
[32m+[m[32m            <span asp-validation-for="Customer.Name" ></span>[m
[32m+[m[32m        </div>[m
[32m+[m[32m    </div>[m
[32m+[m[41m [m
[32m+[m[32m    <div>[m
[32m+[m[32m        <button type="submit">Save</button>[m
[32m+[m[32m    </div>[m
[32m+[m[32m</form>[m
\ No newline at end of file[m
[1mdiff --git a/Pages/Edit.cshtml.cs b/Pages/Edit.cshtml.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..74be11b[m
[1m--- /dev/null[m
[1m+++ b/Pages/Edit.cshtml.cs[m
[36m@@ -0,0 +1,56 @@[m
[32m+[m[32musing System;[m
[32m+[m[32musing System.Threading.Tasks;[m
[32m+[m[32musing Microsoft.AspNetCore.Mvc;[m
[32m+[m[32musing Microsoft.AspNetCore.Mvc.RazorPages;[m
[32m+[m[32musing Microsoft.EntityFrameworkCore;[m
[32m+[m[32musing razorPage.Data;[m
[32m+[m[32musing razorPage.Data.Models;[m
[32m+[m
[32m+[m[32mnamespace razorPage.Pages[m
[32m+[m[32m{[m
[32m+[m[32m    public class EditModel : PageModel[m
[32m+[m[32m    {[m
[32m+[m[32m        private readonly AppDbContext _db;[m
[32m+[m
[32m+[m[32m        public EditModel(AppDbContext db)[m
[32m+[m[32m        {[m
[32m+[m[32m            _db = db;[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        [BindProperty(SupportsGet=true)][m
[32m+[m[32m        public Customer Customer { get; set; }[m
[32m+[m
[32m+[m[32m        public async Task<IActionResult> OnGetAsync()[m
[32m+[m[32m        {[m
[32m+[m[32m            Customer = await _db.Customers.FindAsync(Customer.Id);[m
[32m+[m
[32m+[m[32m            if (Customer == null)[m
[32m+[m[32m            {[m
[32m+[m[32m                return RedirectToPage("/Index");[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            return Page();[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        public async Task<IActionResult> OnPostAsync()[m
[32m+[m[32m        {[m
[32m+[m[32m            if (!ModelState.IsValid)[m
[32m+[m[32m            {[m
[32m+[m[32m                return Page();[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            _db.Attach(Customer).State = EntityState.Modified;[m
[32m+[m
[32m+[m[32m            try[m
[32m+[m[32m            {[m
[32m+[m[32m                await _db.SaveChangesAsync();[m
[32m+[m[32m            }[m
[32m+[m[32m            catch (DbUpdateConcurrencyException)[m
[32m+[m[32m            {[m
[32m+[m[32m                throw new Exception($"Customer {Customer.Id} not found!");[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            return RedirectToPage("/Index");[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/Pages/Error.cshtml b/Pages/Error.cshtml[m
[1mnew file mode 100644[m
[1mindex 0000000..6f92b95[m
[1m--- /dev/null[m
[1m+++ b/Pages/Error.cshtml[m
[36m@@ -0,0 +1,26 @@[m
[32m+[m[32m﻿@page[m
[32m+[m[32m@model ErrorModel[m
[32m+[m[32m@{[m
[32m+[m[32m    ViewData["Title"] = "Error";[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32m<h1 class="text-danger">Error.</h1>[m
[32m+[m[32m<h2 class="text-danger">An error occurred while processing your request.</h2>[m
[32m+[m
[32m+[m[32m@if (Model.ShowRequestId)[m
[32m+[m[32m{[m
[32m+[m[32m    <p>[m
[32m+[m[32m        <strong>Request ID:</strong> <code>@Model.RequestId</code>[m
[32m+[m[32m    </p>[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32m<h3>Development Mode</h3>[m
[32m+[m[32m<p>[m
[32m+[m[32m    Swapping to the <strong>Development</strong> environment displays detailed information about the error that occurred.[m
[32m+[m[32m</p>[m
[32m+[m[32m<p>[m
[32m+[m[32m    <strong>The Development environment shouldn't be enabled for deployed applications.</strong>[m
[32m+[m[32m    It can result in displaying sensitive information from exceptions to end users.[m
[32m+[m[32m    For local debugging, enable the <strong>Development</strong> environment by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>[m
[32m+[m[32m    and restarting the app.[m
[32m+[m[32m</p>[m
[1mdiff --git a/Pages/Error.cshtml.cs b/Pages/Error.cshtml.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..b2e60fb[m
[1m--- /dev/null[m
[1m+++ b/Pages/Error.cshtml.cs[m
[36m@@ -0,0 +1,23 @@[m
[32m+[m[32musing System;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m[32musing System.Diagnostics;[m
[32m+[m[32musing System.Linq;[m
[32m+[m[32musing System.Threading.Tasks;[m
[32m+[m[32musing Microsoft.AspNetCore.Mvc;[m
[32m+[m[32musing Microsoft.AspNetCore.Mvc.RazorPages;[m
[32m+[m
[32m+[m[32mnamespace razorPage.Pages[m
[32m+[m[32m{[m
[32m+[m[32m    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)][m
[32m+[m[32m    public class ErrorModel : PageModel[m
[32m+[m[32m    {[m
[32m+[m[32m        public string RequestId { get; set; }[m
[32m+[m
[32m+[m[32m        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);[m
[32m+[m
[32m+[m[32m        public void OnGet()[m
[32m+[m[32m        {[m
[32m+[m[32m            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[1mdiff --git a/Pages/Index.cshtml b/Pages/Index.cshtml[m
[1mnew file mode 100644[m
[1mindex 0000000..adc383a[m
[1m--- /dev/null[m
[1m+++ b/Pages/Index.cshtml[m
[36m@@ -0,0 +1,33 @@[m
[32m+[m[32m﻿@page[m
[32m+[m[32m@model razorPage.Pages.IndexModel[m
[32m+[m[32m@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers[m
[32m+[m[32m@{[m
[32m+[m[32m    ViewData["Title"] = "Customers";[m
[32m+[m[32m}[m
[32m+[m[32m<h1>Contacts</h1>[m
[32m+[m[32m<form method="post">[m
[32m+[m[32m    <table class="table">[m
[32m+[m[32m        <thead>[m
[32m+[m[32m            <tr>[m
[32m+[m[32m                <th>ID</th>[m
[32m+[m[32m                <th>Name</th>[m
[32m+[m[32m            </tr>[m
[32m+[m[32m        </thead>[m
[32m+[m[32m        <tbody>[m
[32m+[m[32m            @foreach (var contact in Model.Customers)[m
[32m+[m[32m            {[m
[32m+[m[32m                <tr>[m
[32m+[m[32m                    <td>@contact.Id</td>[m
[32m+[m[32m                    <td>@contact.Name</td>[m
[32m+[m[32m                    <td>[m
[32m+[m[32m                        <a asp-page="./Edit" asp-route-id="@contact.Id">edit</a>[m
[32m+[m[32m                        <button type="submit" asp-page-handler="delete"[m[41m [m
[32m+[m[32m                                asp-route-id="@contact.Id">delete</button>[m
[32m+[m[32m                    </td>[m
[32m+[m[32m                </tr>[m
[32m+[m[32m            }[m
[32m+[m[32m        </tbody>[m
[32m+[m[32m    </table>[m
[32m+[m
[32m+[m[32m    <a asp-page="./Create">Create</a>[m
[32m+[m[32m</form>[m
\ No newline at end of file[m
[1mdiff --git a/Pages/Index.cshtml.cs b/Pages/Index.cshtml.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..4b3a154[m
[1m--- /dev/null[m
[1m+++ b/Pages/Index.cshtml.cs[m
[36m@@ -0,0 +1,40 @@[m
[32m+[m[32m﻿using System.Threading.Tasks;[m
[32m+[m[32musing Microsoft.AspNetCore.Mvc;[m
[32m+[m[32musing Microsoft.AspNetCore.Mvc.RazorPages;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m[32musing Microsoft.EntityFrameworkCore;[m
[32m+[m[32musing razorPage.Data;[m
[32m+[m[32musing razorPage.Data.Models;[m
[32m+[m[32musing System;[m
[32m+[m
[32m+[m[32mnamespace razorPage.Pages[m
[32m+[m[32m{[m
[32m+[m[32m    public class IndexModel : PageModel[m
[32m+[m[32m    {[m
[32m+[m[32m        private readonly AppDbContext _db;[m
[32m+[m
[32m+[m[32m        public IndexModel(AppDbContext db)[m
[32m+[m[32m        {[m
[32m+[m[32m            _db = db;[m
[32m+[m[32m        }[m
[32m+[m[32m        public IList<Customer> Customers { get; private set; }[m
[32m+[m
[32m+[m[32m        public async Task OnGetAsync()[m
[32m+[m[32m        {[m
[32m+[m[32m            Customers = await _db.Customers.ToListAsync();[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        public async Task<IActionResult> OnPostDeleteAsync(int id)[m
[32m+[m[32m        {[m
[32m+[m[32m            var contact = await _db.Customers.FindAsync(id);[m
[32m+[m
[32m+[m[32m            if (contact != null)[m
[32m+[m[32m            {[m
[32m+[m[32m                _db.Customers.Remove(contact);[m
[32m+[m[32m                await _db.SaveChangesAsync();[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            return RedirectToPage();[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/Pages/Movies/Create.cshtml b/Pages/Movies/Create.cshtml[m
[1mnew file mode 100644[m
[1mindex 0000000..7619719[m
[1m--- /dev/null[m
[1m+++ b/Pages/Movies/Create.cshtml[m
[36m@@ -0,0 +1,49 @@[m
[32m+[m[32m@page[m
[32m+[m[32m@model razorPage.Pages_Movies.CreateModel[m
[32m+[m
[32m+[m[32m@{[m
[32m+[m[32m    ViewData["Title"] = "Create";[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32m<h1>Create</h1>[m
[32m+[m
[32m+[m[32m<h4>Movie</h4>[m
[32m+[m[32m<hr />[m
[32m+[m[32m<div class="row">[m
[32m+[m[32m    <div class="col-md-4">[m
[32m+[m[32m        <form method="post">[m
[32m+[m[32m            <div asp-validation-summary="ModelOnly" class="text-danger"></div>[m
[32m+[m[32m            <div class="form-group">[m
[32m+[m[32m                <label asp-for="Movie.Title" class="control-label"></label>[m
[32m+[m[32m                <input asp-for="Movie.Title" class="form-control" />[m
[32m+[m[32m                <span asp-validation-for="Movie.Title" class="text-danger"></span>[m
[32m+[m[32m            </div>[m
[32m+[m[32m            <div class="form-group">[m
[32m+[m[32m                <label asp-for="Movie.ReleaseDate" class="control-label"></label>[m
[32m+[m[32m                <input asp-for="Movie.ReleaseDa