﻿using Miam.Web.Automation;
using OpenQA.Selenium;

namespace Miam.Web.AcceptanceTests
{
    public  class WriterCreateRestaurantPage
    {
        public static void GoTo()
        {
            var writerMenu = Driver.Instance.FindElement(By.Id("writer-menu"));
            writerMenu.Click();

            var addRestaurantMenuItem = Driver.Instance.FindElement(By.Id("add-restaurant-menu-item"));
            addRestaurantMenuItem.Click();
        }

        public static CreateRestaurantCommand CreateRestaurant(string restaurantName)
        {
            return new CreateRestaurantCommand(restaurantName);
        }
    }

    public class CreateRestaurantCommand
    {
        private readonly string _restaurantName;
        private string _city;
        private string _country;

        public CreateRestaurantCommand(string restaurantName)
        {
            _restaurantName = restaurantName;
        }

        public CreateRestaurantCommand WithCity(string city)
        {
            _city = city;
            return this;
        }

        public CreateRestaurantCommand WithCountry(string country)
        {
            _country = country;
            return this;
        }

        public void Create()
        {
            Driver.Instance.FindElement(By.Id("Name")).SendKeys(_restaurantName);
            Driver.Instance.FindElement(By.Id("City")).SendKeys(_city);
            Driver.Instance.FindElement(By.Id("Country")).SendKeys(_country);

            Driver.Instance.FindElement(By.Id("create_button")).Click();
        }
    }
}