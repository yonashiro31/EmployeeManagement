using System;

namespace EmployeeManagement.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Title { get; set; }

        public string Password { get; set; }

        public bool Cd { get; set; }
        public bool Publish { get; set; }
    }
}
