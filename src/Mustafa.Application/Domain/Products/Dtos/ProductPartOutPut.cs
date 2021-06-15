

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Mustafa.Domain.Entities;
using System;

namespace Mustafa.Domain.Products.Dtos
{
    public class ProductPartOutPut : EntityDto<int>
    {
        public string Name { get; set; }
        public string Descr { get; set; }
        public float LastPrice { get; set; }
        public string ImgPath { get; set; }
    }
}
