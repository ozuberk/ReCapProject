﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarImageDto : IDto
    {
        public int ImageId { get; set; }
        public int CarId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
