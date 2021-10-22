using System.Collections.Generic;

namespace CarParking.Models
{
    public class JsonActionResult
    {
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        public string DisplayMessage { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
