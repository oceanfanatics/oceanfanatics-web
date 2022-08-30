using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using oceanfanatics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.ViewComponents
{
    public class ContactUsViewComponent : ViewComponent
    {
        private readonly IConfiguration _config;

        public ContactUsViewComponent(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IViewComponentResult> InvokeAsync(string destination)
        {
            var submitted = String.Empty;
            var contactRequest = new Contact();
            if (Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
               
                contactRequest.Name = Request.Form[nameof(contactRequest.Name)];
                contactRequest.ContactNumber = Request.Form[nameof(contactRequest.ContactNumber)];
                contactRequest.EmailAddress = Request.Form[nameof(contactRequest.EmailAddress)];
                contactRequest.Message = Request.Form[nameof(contactRequest.Message)];

                var mailingService = new SendEmail(_config);

                var sendemail = await mailingService.Send(
                    $"Inquiry from website: {destination}",
                  contactRequest.EmailAddress,
                    $"{contactRequest.Name}requests you with message {contactRequest.Message} to contact them on {contactRequest.EmailAddress} or {contactRequest.ContactNumber}");
                if (sendemail)
                {
                    submitted = "sent";
                }
                else
                {
                    submitted = "not sent";
                }

                TempData["submitted"] = submitted;
                return View("ContactSuccess");

            }
            TempData["submitted"] = submitted;
            return View(contactRequest);
        }
    }
}
