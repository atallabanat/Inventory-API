using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web.Http;

namespace Inventory.Controllers
{
    public class InventoryController : ApiController
    {

        #region  POST Methods

        [HttpPost]
        [ActionName("Login")]
        public IHttpActionResult Login(DataObj dataObj)
        {
            try
            {
                var json = JObject.Parse(dataObj.dataObj);
                //if (! json.h("password"))
                //{
                //    return Content(HttpStatusCode.OK, "You must Provide 'password' parameter");
                //}
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_Login";
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = json["username"];
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = json["password"];

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }

        [HttpPost]
        [ActionName("ADD_Invoice_Sales")]
        public IHttpActionResult ADD_Invoice_Sales(string json)
        {
            try
            {
               // var json = JObject.Parse(dataObj.dataObj);
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_ADD_Invoice_Sales";
                cmd.Parameters.Add("@json", SqlDbType.NVarChar).Value = json;
                ////cmd.Parameters.Add("@Invoice_Net_Total", SqlDbType.Decimal).Value = json["Invoice_Net_Total"];
                ////cmd.Parameters.Add("@Invoice_before_NetTotal", SqlDbType.Decimal).Value = json["Invoice_before_NetTotal"];
                ////cmd.Parameters.Add("@R_Item_No", SqlDbType.Int).Value = json["R_Item_No"];
                ////cmd.Parameters.Add("@R_Item_Name", SqlDbType.NVarChar).Value = json["R_Item_Name"];
                ////cmd.Parameters.Add("@R_Unit_No", SqlDbType.Int).Value = json["R_Unit_No"];
                ////cmd.Parameters.Add("@R_Unit_Name", SqlDbType.NVarChar).Value = json["R_Unit_Name"];
                ////cmd.Parameters.Add("@R_Sores_No", SqlDbType.Int).Value = json["R_Sores_No"];
                ////cmd.Parameters.Add("@R_Quantity", SqlDbType.Decimal).Value = json["R_Quantity"];
                ////cmd.Parameters.Add("@R_Price_Sales", SqlDbType.Decimal).Value = json["R_Price_Sales"];
                ////cmd.Parameters.Add("@R_Discount_Percentage", SqlDbType.Decimal).Value = json["R_Discount_Percentage"];
                ////cmd.Parameters.Add("@R_Total", SqlDbType.Decimal).Value = json["R_Total"];
                ////cmd.Parameters.Add("@R_Bouns", SqlDbType.Decimal).Value = json["R_Bouns"];
                ////cmd.Parameters.Add("@ID_User", SqlDbType.Int).Value = json["ID_User"];

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }


        [HttpPost]
        [ActionName("ADD_Transfer_Bond")]
        public IHttpActionResult ADD_Transfer_Bond(string json)
        {
            try
            {
                
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_ADD_Transfer_Bond";
                cmd.Parameters.Add("@json", SqlDbType.NVarChar).Value = json;


                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }



        #endregion

        #region DELETE Methods


        [HttpPost]
        [ActionName("Delete_Invoice_Sales")]
        public IHttpActionResult Delete_Invoice_Sales(int Invoice_No , int ID_User)
        {
            try
            {
                //var json = JObject.Parse(dataObj.dataObj);
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_Delete_Invoice_Sales";
                cmd.Parameters.Add("@Invoice_No", SqlDbType.Int).Value = Invoice_No;
                cmd.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User;

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }


        [HttpPost]
        [ActionName("Delete_Transfer_Bond")]
        public IHttpActionResult Delete_Transfer_Bond(int Bond_No , int ID_User)
        {
            try
            {
                ////var json = JObject.Parse(dataObj.dataObj);
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_Delete_Transfer_Bond";
                cmd.Parameters.Add("@Bond_No", SqlDbType.Int).Value = Bond_No;
                cmd.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User;

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }

        #endregion

        #region GET Methods
        [HttpGet]
        [ActionName("PQ_Unit")]
        public IHttpActionResult PQ_Unit(int R_Sores_No, int R_Item_No, int R_Unit_No)
        {
            try
            {
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_Select_PQ_Unit";
                cmd.Parameters.Add("@R_Sores_No", SqlDbType.Int).Value = R_Sores_No;
                cmd.Parameters.Add("@R_Item_No", SqlDbType.Int).Value = R_Item_No;
                cmd.Parameters.Add("@R_Unit_No", SqlDbType.Int).Value = R_Unit_No;


                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }



        [HttpGet]
        [ActionName("Home")]
        public IHttpActionResult Home(int ID_User, int R_Sores_No)
        {
            try
            {
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_Home";
                cmd.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User;
                cmd.Parameters.Add("@R_Sores_No", SqlDbType.Int).Value = R_Sores_No;

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }


        [HttpGet]
        [ActionName("Item_Name")]
        
        public IHttpActionResult Item_Name(int R_Sores_No)
        {
            try
            {

                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_Item_Name";
                cmd.Parameters.Add("@R_Sores_No", SqlDbType.Int).Value = R_Sores_No;

                c.Open();
                rdr = cmd.ExecuteReader();
                object dt = new object();
                dt="ss"+rdr;
                c.Close();
                return Content(HttpStatusCode.OK,"xxs"+ dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }

        [HttpGet]
        [ActionName("Item")]
        public IHttpActionResult Item(string Barcode)
        {
            try
            {

                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select AName,SalesPrice from items with(nolock) where MainBarcode=@MainBarcode";
                cmd.Parameters.AddWithValue("@MainBarcode", Barcode);

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                 dt.Load(rdr);
                
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }

        [HttpGet]
        [ActionName("items")]
        public IHttpActionResult items()
        {
            try
            {

                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select MainBarcode,AName,EName,SalesPrice,PurchasePrice from items";
                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);

                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }

        [HttpGet]
        [ActionName("Stores")]
        public IHttpActionResult Stores()
        {
            try
            {

                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select ID,AName,EName from Stores";
                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);

                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }


        [HttpGet]
        [ActionName("Unit")]
        public IHttpActionResult Unit()
        {
            try
            {

                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select ID,AName,EName,CreationDate from Unit";
                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);

                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }


        [HttpGet]
        [ActionName("MaxInvoice_Sales")]
        public IHttpActionResult MaxInvoice_Sales(DataObj dataObj)
        {
            try
            {
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_MaxInvoice_Sales";

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }

        [HttpGet]
        [ActionName("Max_Transfer_Bond")]
        public IHttpActionResult Max_Transfer_Bond(DataObj dataObj)
        {
            try
            {
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_Max_Transfer_Bond";

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }


        [HttpGet]
        [ActionName("Select_Invoice_DATA")]
        public IHttpActionResult Select_Invoice_DATA(int ID_User, int Invoice_No)
        {
            try
            {
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_Select_Invoice_DATA";
                cmd.Parameters.Add("@ID_User", SqlDbType.NVarChar).Value = ID_User;
                cmd.Parameters.Add("@Invoice_No", SqlDbType.NVarChar).Value = Invoice_No;

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }

        [HttpGet]
        [ActionName("Select_Transfer_Bond_DATA")]
        public IHttpActionResult Select_Transfer_Bond_DATA(int ID_User, int Bond_No)
        {
            try
            {
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_Select_Transfer_Bond_DATA";
                cmd.Parameters.Add("@ID_User", SqlDbType.NVarChar).Value = ID_User;
                cmd.Parameters.Add("@Bond_No", SqlDbType.NVarChar).Value = Bond_No;

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }



        [HttpGet]
        [ActionName("Select_InvoiceNo")]
        public IHttpActionResult Select_InvoiceNo(int ID_User)
        {
            try
            {
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_Select_InvoiceNo";
                cmd.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User;

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }

        [HttpGet]
        [ActionName("Select_Transfer_Bond_No")]
        public IHttpActionResult Select_Transfer_Bond_No(int ID_User)
        {
            try
            {
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_Select_Transfer_Bond_No";
                cmd.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User;

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }


        [HttpGet]
        [ActionName("Stores_Name")]
        public IHttpActionResult Stores_Name()
        {
            try
            {
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_Stores_Name";
               

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }



        [HttpGet]
        [ActionName("Select_Unit")]
        public IHttpActionResult Select_Unit(int Item_No)
        {
            try
            {
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_Select_Unit";
                cmd.Parameters.Add("@Item_No", SqlDbType.Int).Value = Item_No;

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }

        [HttpGet]
        [ActionName("ss")]
        public IHttpActionResult ss(DataObj dataObj)
        {
            try
            {
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand();
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString);
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Tablet_ss";
                

                c.Open();
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                c.Close();
                return Content(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Exception : " + ex.Message);
            }
        }

        #endregion

    }
}
