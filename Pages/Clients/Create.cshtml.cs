using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Crud__Asp.net_core_.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            clientInfo.name = Request.Form["name"];
            clientInfo.email= Request.Form["email"];
            clientInfo.phone = Request.Form["phone"];
            clientInfo.address = Request.Form["address"];

            if (clientInfo.name.Length == 0 || clientInfo.email.Length == 0 || clientInfo.phone.Length == 0 || clientInfo.address.Length == 0) 
            {
                errorMessage = "All the fields are required";
                return;
            }
            
            //save the new client into the db;
            clientInfo.name = ""; clientInfo.email = ""; clientInfo.phone = ""; clientInfo.address = "";
            successMessage = "New Client Added Correctly";
        }
    }
}
