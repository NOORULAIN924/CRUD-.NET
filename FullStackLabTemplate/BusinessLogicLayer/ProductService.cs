using Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class ProductService : IProductService
    {
        public List<ProductModel> GetAllData()
        {
            return CRUD.GetAllData();
        }

        public ProductModel? GetDataById(int id)
        {
            return CRUD.GetDataById(id);
        }

        public bool InsertData(ProductModel model)
        {
            return CRUD.InsertData(model);
        }

        public bool UpdateData(ProductModel model)
        {
            return CRUD.UpdateData(model);
        }

        public bool DeleteData(int id)
        {
            return CRUD.DeleteData(id);
        }
    }
}