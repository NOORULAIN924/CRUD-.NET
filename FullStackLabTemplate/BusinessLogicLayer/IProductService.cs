using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public interface IProductService
    {
        List<ProductModel> GetAllData();
        ProductModel? GetDataById(int id);
        bool InsertData(ProductModel model);
        bool UpdateData(ProductModel model);
        bool DeleteData(int id);
    }
}