﻿using Advertisements.Contracts.UserProvider;
using MapsterMapper;
using Sev1.Advertisements.Application.Interfaces.Category;
using Sev1.Advertisements.Application.Repositories.Category;

namespace Sev1.Advertisements.Application.Implementations.Category
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserProvider _userProvider;
        private readonly IMapper _mapper;

        public CategoryServiceV1(
            ICategoryRepository categoryRepository,
            IUserProvider userProvider,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _userProvider = userProvider;
            _mapper = mapper;
        }
    }
}