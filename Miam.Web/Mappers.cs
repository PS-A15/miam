﻿using System;
using System.Collections.Generic;
using System.Linq;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Home;
using Miam.Web.ViewModels.Restaurant;
using Miam.Web.ViewModels.Review;
using Ninject.Parameters;

namespace Miam.Web
{
    public static class Mappers
    {
        // Restaurant
        public static Restaurant CreateRestaurantFrom(RestaurantCreateViewModel restaurantViewModel)
        {
            return new Restaurant
            {
                Id = restaurantViewModel.RestaurantId,
                City = restaurantViewModel.City,
                Name = restaurantViewModel.Name,
                Country = restaurantViewModel.Country,
                RestaurantContactDetail = Mappers.CreateContactDetailFromViewModel(restaurantViewModel.ContactDetailViewModel)
            };
        }

        private static RestaurantContactDetail CreateContactDetailFromViewModel(ContactDetailViewModel contactDetailViewModel)
        {
            if (contactDetailViewModel== null) return null;
            return new RestaurantContactDetail()
            {
                Facebook = contactDetailViewModel.Facebook,
                FaxPhone = contactDetailViewModel.FaxPhone,
                OfficePhone = contactDetailViewModel.OfficePhone,
                TwitterAlias = contactDetailViewModel.TwitterAlias,
                WebPage = contactDetailViewModel.WebPage
            };
        }

        public static RestaurantDeleteViewModel CreateRestaurantDeleteViewModelFrom(Restaurant restaurant)
        {
            return new RestaurantDeleteViewModel
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                City = restaurant.City,
                Country = restaurant.Country
            };
        }

        public static RestaurantEditViewModel createRestaurantEditViewModelFrom(Restaurant restaurant)
        {

            return new RestaurantEditViewModel
            {
                Id = restaurant.Id,
                City = restaurant.City,
                Country = restaurant.Country,
                Name = restaurant.Name,
                RestaurantContactDetailViewModel = Mappers.CreateRestaurantContactDetailViewModelFrom(restaurant.RestaurantContactDetail),
                ReviewsViewModel = Mappers.CreateReviewViewModelFrom(restaurant.Reviews)
            };
        }

        private static List<ReviewIndexViewModel> CreateReviewViewModelFrom(ICollection<Review> reviews)
        {
            if (reviews == null) return null;
            return reviews
                .Select(x => new ReviewIndexViewModel
                {
                    Body = x.Body,
                    Rating = x.Rating,
                    WriterName = x.Writer.Name
                }).ToList();
        }

        private static ContactDetailViewModel CreateRestaurantContactDetailViewModelFrom(RestaurantContactDetail restaurantContactDetail)
        {
            if (restaurantContactDetail == null) return null;
            return new ContactDetailViewModel
            {
                Facebook = restaurantContactDetail.Facebook,
                FaxPhone = restaurantContactDetail.FaxPhone,
                OfficePhone = restaurantContactDetail.OfficePhone,
                TwitterAlias = restaurantContactDetail.TwitterAlias,
                WebPage = restaurantContactDetail.WebPage
            };

        }

        public static IEnumerable<HomeIndexViewModel> CreateHomeIndexViewModelFrom(List<Restaurant> restaurants)
        {
            return restaurants
                .Select(x => new HomeIndexViewModel
                {
                    Name = x.Name,
                    City = x.City,
                    Country = x.Country,
                    RatingReviewsAverage = x.CalculateReviewsRatingAverage()
                }).ToList();
        }

        public static RestaurantCreateViewModel CreateRestaurantCreateViewModelFrom(Restaurant restaurant)
        {
            return new RestaurantCreateViewModel
            {
                RestaurantId = restaurant.Id,
                City = restaurant.City,
                Country = restaurant.Country,
                Name = restaurant.Name,
                ContactDetailViewModel = Mappers.CreateContactDetailViewModelFrom(restaurant.RestaurantContactDetail) 
            };
        }

        private static ContactDetailViewModel CreateContactDetailViewModelFrom(RestaurantContactDetail ContactDetail)
        {
            if (ContactDetail == null) return null;
            return new ContactDetailViewModel()
            {
                Facebook = ContactDetail.Facebook,
                FaxPhone = ContactDetail.FaxPhone,
                OfficePhone = ContactDetail.OfficePhone,
                TwitterAlias = ContactDetail.TwitterAlias,
                WebPage = ContactDetail.WebPage
            };
        }


        public static IEnumerable<RestaurantIndexViewModel> CreateRestaurantIndexViewModelFrom(List<Restaurant> restaurants)
        {
            var homeIndexViewModel = restaurants
               .Select(x => new RestaurantIndexViewModel
               {
                   Id = x.Id,
                   Name = x.Name,
                   City = x.City,
                   Country = x.Country,
                   RatingReviewsAverage = x.CalculateReviewsRatingAverage(),
                   CountOfReviews = x.Reviews.Count,
               }).ToList();

            return homeIndexViewModel;
        }


        //Review
        public static Review CreateReviewFrom(ReviewCreateViewModel reviewCreateViewModel)
        {
            var review = new Review
            {
                Body = reviewCreateViewModel.Body,
                Rating = reviewCreateViewModel.Rating,
                RestaurantId = reviewCreateViewModel.RestaurantId,
            };
            return review;
        }

        public static ReviewCreateViewModel CreateReviewCreateViewModelFrom(Review review)
        {
            return new ReviewCreateViewModel
            {
                RestaurantId = review.RestaurantId,
                Body = review.Body,
                Rating = review.Rating
            };
        }

        public static void UpdateRestaurantFromViewModel(Restaurant restaurant,RestaurantEditViewModel restaurantEditViewModel)
        {
            restaurant.City = restaurantEditViewModel.City;
            restaurant.Country = restaurantEditViewModel.Country;
            restaurant.Name = restaurantEditViewModel.Name;
            //Todo: revoir la gestion du contact details
            if (restaurant.RestaurantContactDetail == null && restaurantEditViewModel != null)
            {
                restaurant.RestaurantContactDetail = new RestaurantContactDetail();
            }
            Mappers.UpdateRestaurantContactDetailFromViewModel(restaurant.RestaurantContactDetail,
                                                               restaurantEditViewModel.RestaurantContactDetailViewModel);
        }

        private static void UpdateRestaurantContactDetailFromViewModel(RestaurantContactDetail restaurantContactDetail, ContactDetailViewModel restaurantContactDetailViewModel)
        {
            if (restaurantContactDetailViewModel != null) 
            {
                restaurantContactDetail.Facebook = restaurantContactDetailViewModel.Facebook;
                restaurantContactDetail.FaxPhone = restaurantContactDetailViewModel.FaxPhone;
                restaurantContactDetail.OfficePhone = restaurantContactDetailViewModel.OfficePhone;
                restaurantContactDetail.TwitterAlias = restaurantContactDetailViewModel.TwitterAlias;
                restaurantContactDetail.WebPage = restaurantContactDetailViewModel.WebPage;
            }

        }
    }
}