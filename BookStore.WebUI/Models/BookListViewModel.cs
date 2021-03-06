﻿using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebUI.Models
{
    public class BookListViewModel
    {
        public IEnumerable< Book> Books { get; set; }
        public Book Book { get; set; }

        public PagingInfo PagingInfo { get; set; }
        public string CurrentSpecilization { get; set; }
        public int SearchPagesNumber { get; set; }
        public IEnumerable<string> SpecializationColl { get; set; }
    }
}