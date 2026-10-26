using System;
using System.Collections.Generic;
using Models;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ProductService : IProductService
    {
        // Wired to pull records into the table
        public List<ProductModel> GetAllData()
        {
            return CRUD.GetAllData();
        }

        // Wired to make the orange "Edit" button pull data back up into the input fields
        public ProductModel? GetDataById(int id)
        {
            return CRUD.GetDataById(id);
        }

        // Wired to make the blue "Add" / "Update" button save brand new records
        public bool InsertData(ProductModel model)
        {
            return CRUD.InsertData(model);
        }

        // Wired to make the blue button update existing records when in edit mode
        public bool UpdateData(ProductModel model)
        {
            return CRUD.UpdateData(model);
        }

        // Wired to make the red "Delete" button drop entries instantly
        public bool DeleteData(int id)
        {
            return CRUD.DeleteData(id);
        }
    }
}
