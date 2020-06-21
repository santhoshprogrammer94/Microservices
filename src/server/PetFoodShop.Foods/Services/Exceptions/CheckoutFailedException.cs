﻿namespace PetFoodShop.Foods.Services.Exceptions
{
    using System;

    public class CheckoutFailedException : Exception
    {
        public CheckoutFailedException(string message) : base(message)
        {
        }
    }
}