using System;
using System.Collections.Generic;
using CarParking.Models;

namespace CarParking.Helpers
{
    public class JsonUtility
    {
        public JsonActionResult Success(object resultData = null, string message = "")
        {
            return new JsonActionResult
            {
                IsSuccess = true,
                DisplayMessage = message,
                Result = resultData
            };
        }

        public JsonActionResult Error(Exception ex, string message = "")
        {
            return new JsonActionResult
            {
                IsSuccess = false,
                DisplayMessage = message,
                ErrorMessages = new List<string> {ex.ToString()}
            };
        }
    }
}
