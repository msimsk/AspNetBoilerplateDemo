﻿using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using Mustafa.Domain.Categories.Dtos;
using Mustafa.Domain.Entities;
using Mustafa.Domain.Unitlines.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Products.Dtos
{
    public class CreateProductInput
    {
        public string Name { get; set; }
        public string Descr { get; set; }
        public IFormFile myImg { set; get; }
        public float? LastPrice { get; set; }
        public CategoryPartOutPut Category { get; set; }
        public UnitlinePartOutPut Unitline { get; set; }
    }
}
