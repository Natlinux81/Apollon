﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Models
{
    public class Tournament
    {
        public Tournament(string organisation, string tournamentname, string category, string location)
        {
            Organisation = organisation;
            Tournamentname = tournamentname;
            Category = category;
            //Startdate = startdate;
            //Enddate = enddate;
            Location = location;
        }        

        public string Organisation { get; }
        public string Tournamentname { get; }
        public string Category { get; }
        //public DateTime Startdate { get; }
        //public DateTime Enddate { get; }
        public string Location { get; }
    }
}