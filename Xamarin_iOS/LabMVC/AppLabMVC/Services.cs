using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NorthWind;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace AppLabMVC
{
    public class Product : IProduct
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
    class Services : INorthWindModel
    {
        public event ChangeStatusEventHandler ChangeStatus;

        public async Task<IProduct> GetProductByIDAsync(int ID)
        {
            IProduct Product = new Product();
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://ticapacitacion.com/webapi/northwind/");
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Notificar aqui que la API Web sera invocada
                ChangeStatus(this, new ChangeStatusEventArgs { Status = StatusOptions.CallingWebAPI });
                HttpResponseMessage Response = await Client.GetAsync($"product/{ID}");

                // Notificar aqui que se va a verificar el resultado de la llamada
                ChangeStatus(this, new ChangeStatusEventArgs { Status = StatusOptions.VerifyingResult });
                if (Response.IsSuccessStatusCode)
                {
                    var JSONProduct = await Response.Content.ReadAsStringAsync();
                    Product = JsonConvert.DeserializeObject<Product>(JSONProduct);
                    if (Product != null)
                    {
                        // Notificar aqui que el producto fue encontrado
                        ChangeStatus(this, new ChangeStatusEventArgs { Status = StatusOptions.ProductFound });
                    }
                    else
                    {
                        // Notificat aqui que el producto no fue encontrado
                        ChangeStatus(this, new ChangeStatusEventArgs { Status = StatusOptions.ProductNotFound });
                    }
                }
            }
            return Product;
        }

        public class ChangeStatusEventArgs : IChangeStatusEventArgs
        {
            public StatusOptions Status { get; set; }
        }
    }
}
