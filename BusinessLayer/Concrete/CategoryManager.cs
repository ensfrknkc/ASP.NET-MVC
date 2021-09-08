﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public int CategoryStatusDiffrance()
        {
            var trueCount = _categoryDal.List(x => x.CategoryStatus==true).Count();
            var falseCount = _categoryDal.List(x => x.CategoryStatus == false).Count();
            return Math.Abs(trueCount - falseCount);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public Category GetCategoryWithName(string name)
        {
            return _categoryDal.Get(x => x.CategoryName == name);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        //public void CategoryAddBL(Category p)
        //{
        //    if (p.CategoryName=="" || p.CategoryStatus==false)
        //    {
        //        //hata
        //    }
        //    else
        //    {
        //        _categoryDal.Insert(p);
        //    }
        //}
    }
}
