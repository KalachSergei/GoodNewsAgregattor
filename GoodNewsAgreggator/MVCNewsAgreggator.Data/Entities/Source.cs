﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNewsAgreggator.Data.Entities
{
    public class Source : BaseEntity
    {
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public string RssUrl { get; set; }
    }
}
