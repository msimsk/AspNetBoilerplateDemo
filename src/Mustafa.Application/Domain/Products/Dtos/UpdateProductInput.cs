using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using Mustafa.Domain.Categories.Dtos;
using Mustafa.Domain.Entities;
using Mustafa.Domain.Unitlines.Dto;
using System;

namespace Mustafa.Domain.Products.Dtos
{
    public class UpdateProductInput : EntityDto<int>
    {
        public string Name { get; set; }
        public string ImgPath { get; set; }
        public IFormFile myImg { set; get; }
        public string Descr { get; set; }
        public bool IsDeleted { get; set; }
        public float LastPrice { get; set; }
        public CategoryPartOutPut Category { get; set; }
        public UnitlinePartOutPut Unitline { get; set; }

    }
}
