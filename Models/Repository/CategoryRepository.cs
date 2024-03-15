﻿using Models.Data;
using Models.Repository.IRepository;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var categoryFromDb = base.FirstOrDefault(x => x.Id == category.Id);
            if (categoryFromDb != null)
            {
                categoryFromDb.CategoryName = category.CategoryName;
                categoryFromDb.DisplayOrder = category.DisplayOrder;
            }
        }

        public void UpdateName(string category)
        {
            var categoryFromDb = base.FirstOrDefault(x => x.CategoryName == category);
            if (categoryFromDb != null)
            {
                categoryFromDb.CategoryName = category;
            }
        }
    }
}
