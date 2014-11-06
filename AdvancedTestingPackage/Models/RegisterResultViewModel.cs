
using System.Collections.Generic;

namespace AdvancedTestingPackage.Models
{
    public class RegisterResultViewModel
    {
        public bool Succeed { get; set; }
        public List<string> Errors { get; set; }

        public RegisterResultViewModel()
        {
            Errors = new List<string>();
        }
    }
}