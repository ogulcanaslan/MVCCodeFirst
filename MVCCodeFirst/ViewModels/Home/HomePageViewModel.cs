using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCCodeFirst.Models;

namespace MVCCodeFirst.ViewModels.Home
{
    public class HomePageViewModel
    {
        public List<Kisiler> Kisiler { get; set; }
        public List<Adresler> Adresler { get; set; }
    }
}