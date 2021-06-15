using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Uow;
using Abp.Extensions;
using Mustafa.Authorization;
using Mustafa.Domain.Categories.Dtos;
using Mustafa.EntityFrameworkCore.Repositories;
using Mustafa.Domain.Entities;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System.Linq;
using Abp.Linq.Extensions;
using Abp.Collections.Extensions;
using System.Collections.Generic;
using System;

namespace Mustafa.Domain.Categories


{
    [AbpAuthorize(PermissionNames.Category)]
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryFullOutPut, int, GetAllCategoryInput, CreateCategoryInput, UpdateCategoryInput, GetCategoryInput, DeleteCategoryInput>, ICategoryAppService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryAppService(
            ICategoryRepository categoryRepository,
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<Category, int> repository) : base(repository)
        {
            _categoryRepository = categoryRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }
        [AbpAuthorize(PermissionNames.Category_Create)]
        public override async Task<CategoryFullOutPut> CreateAsync(CreateCategoryInput input)
        {

            var category = new Category()
            {
                Name = input.Name,
                Descr = input.Descr,
            };

            await _categoryRepository.InsertAsync(category);
            await _unitOfWorkManager.Current.SaveChangesAsync();

            return MapToEntityDto(category);
            //return base.CreateAsync(input);
        }
        [AbpAuthorize(PermissionNames.Category_Update)]
        public override async Task<CategoryFullOutPut> UpdateAsync(UpdateCategoryInput input)
        {
            var category = await _categoryRepository.GetAsync(input.Id);

            if (category == null)
                throw new EntityNotFoundException(typeof(Category), input.Id);

            category.Name = input.Name.IsNullOrEmpty() ? category.Name : input.Name;
            category.Descr = input.Descr;

            await _categoryRepository.UpdateAsync(category);
            await _unitOfWorkManager.Current.SaveChangesAsync();
            return MapToEntityDto(category);

            //return await base.UpdateAsync(input);
        }
        [AbpAuthorize(PermissionNames.Category_GetList)]
        public override async Task<PagedResultDto<CategoryFullOutPut>> GetAllAsync(GetAllCategoryInput input)
        {
            return await base.GetAllAsync(input);
        }
        protected override IQueryable<Category> CreateFilteredQuery(GetAllCategoryInput input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name) || x.Descr.Contains(input.Name))
                .Where(x => x.IsDeleted.Equals(input.IsDeleted));
        }
        [AbpAuthorize(PermissionNames.Category_Get)]
        public override async Task<CategoryFullOutPut> GetAsync(GetCategoryInput input)
        {
            return await base.GetAsync(input);
        }
        [AbpAuthorize(PermissionNames.Category_Delete)]
        public override async Task DeleteAsync(DeleteCategoryInput input)
        {
            //var category = await _categoryRepository.GetAsync(input.Id);
            //if (category == null) throw new EntityNotFoundException(typeof(Category), input.Id);

            //category.IsDeleted = true;


            //await _categoryRepository.UpdateAsync(category);
            //await _unitOfWorkManager.Current.SaveChangesAsync();
            await base.DeleteAsync(input);
        }

        public async Task<List<CategoryFullOutPut>> GetList()
        {
            throw new NullReferenceException("Manuel Hata");
            var categories = await _categoryRepository.GetAllListAsync(x => x.IsDeleted.Equals(false));
            return ObjectMapper.Map<List<CategoryFullOutPut>>(categories);
        }
    }
}
