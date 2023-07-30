﻿using CommerceApp.Entities;

namespace CommerceApp.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategory { get; set; }

        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); //stackoverflow
        }
    }
    public class ProductListModel
    {
        public PagingInfo PagingInfo { get; set; }
        public List<Product> Products { get; set; }
    }
}
