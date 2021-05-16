using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Data.SqlClient;
using BagByteAPI.Models;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace BagByteAPI.Controllers
{
    [Route("api/bagbyte")]
    public class BagbyteController : ApiController
    {
        string connection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        
        #region User
        //[Route("api/bagbyte")]
        //[HttpPost]
        [HttpPost]
        public IHttpActionResult VerifyUser([FromBody]RegisterUser verifyuser) //send parameter in body as json data
        //public IHttpActionResult VerifyUser(string Email,string Password) // send parameter with url
        {
            bool Valid = true;
            VerifyUser user = new VerifyUser();
            try
            {
                DataSet ds = new DataSet();
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_VerifyUser";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                if (!string.IsNullOrEmpty(verifyuser.Email))
                {
                    sqlcmd.Parameters.AddWithValue("@Email",verifyuser.Email);
                }
                else
                {
                    sqlcmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(verifyuser.Password))
                {
                    sqlcmd.Parameters.AddWithValue("@Password",verifyuser.Password);
                }
                else
                {
                    sqlcmd.Parameters.AddWithValue("@Password", DBNull.Value);
                }
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcon.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    //RegisterUser tempUser = new RegisterUser();
                    user.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                    //user.FName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    //user.LName = ds.Tables[0].Rows[0]["LastName"].ToString();
                    //user.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    //user.Contact = ds.Tables[0].Rows[0]["Contact"].ToString();
                    //user.Gender = ds.Tables[0].Rows[0]["Gender"].ToString();
                    //user.DateOfBirth = DateTime.Parse(ds.Tables[0].Rows[0]["DateOfBirth"].ToString());
                    user.Email = (ds.Tables[0].Rows[0]["Email"].ToString());
                    user.UserRole = (ds.Tables[0].Rows[0]["UserRole"].ToString());                                    
                }
                else
                {
                    Valid = false;
                }

                sqlcon.Close();

                //if(Valid==true)
                //{
                //    long UserID = user.UserID;
                //}
                //return Valid;
            }

            catch(Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }
            return Ok(user);
        }

        [HttpPost]
        public HttpResponseMessage PostRegisterUser([FromBody]RegisterUser users)
        {
            try
            {
                string FName = users.FName;
                string LName = users.LName;
                string Address = users.Address;
                string Contact = users.Contact;
                string Email = users.Email;
                string Password = users.Password;
                //string Gender = users.Gender;
                string DateOfBirth = users.DateOfBirth;
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_InsertUser";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                if (!string.IsNullOrEmpty(FName))
                {
                    sqlcmd.Parameters.AddWithValue("@FName", FName);
                }
                else
                {
                    sqlcmd.Parameters.AddWithValue("@FName", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(LName))
                {
                    sqlcmd.Parameters.AddWithValue("@LName", LName);
                }
                else
                {
                    sqlcmd.Parameters.AddWithValue("@LName", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(Address))
                {
                    sqlcmd.Parameters.AddWithValue("@Address", Address);
                }
                else
                {
                    sqlcmd.Parameters.AddWithValue("@Address", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(Contact))
                {
                    sqlcmd.Parameters.AddWithValue("@Contact", Contact);
                }
                else
                {
                    sqlcmd.Parameters.AddWithValue("@Contact", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(Email))
                {
                    sqlcmd.Parameters.AddWithValue("@Email", Email);
                }
                else
                {
                    sqlcmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(Password))
                {
                    sqlcmd.Parameters.AddWithValue("@Password", Password);
                }
                else
                {
                    sqlcmd.Parameters.AddWithValue("@Password", DBNull.Value);
                }
                //if (!string.IsNullOrEmpty(Gender))
                //{
                //    sqlcmd.Parameters.AddWithValue("@Gender", Gender);
                //}
                //else
                //{
                //    sqlcmd.Parameters.AddWithValue("@Gender", DBNull.Value);
                //}
                if (!string.IsNullOrEmpty(DateOfBirth.ToString()))
                {
                    sqlcmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                }
                else
                {
                    sqlcmd.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
                }

                sqlcmd.CommandType = CommandType.StoredProcedure;
                //var result=
                sqlcon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

                return Request.CreateResponse("succesfully created");
            }
            catch(Exception ex)
            {
                
               return Request.CreateResponse(ex.ToString());
            }
        } 
        //public void VerifyUser(string UserName,string Password)
        //{

        //}
        [HttpPut]
        public HttpResponseMessage UpdateRegisterUser([FromBody]RegisterUser users)
        {
            try
            {
                string FName = users.FName;
                string LName = users.LName;
                string Address = users.Address;
                string Contact = users.Contact;
                string Email = users.Email;
                //string Password = users.Password;
                //string Gender = users.Gender;
                //DateTime DateOfBirth = users.DateOfBirth;

                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_UpdateUser";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                sqlcmd.Parameters.AddWithValue("@FName", FName);
                sqlcmd.Parameters.AddWithValue("@LName", LName);
                sqlcmd.Parameters.AddWithValue("@Address", Address);
                sqlcmd.Parameters.AddWithValue("@Contact", Contact);
                //sqlcmd.Parameters.AddWithValue("@Email", Email);
                //sqlcmd.Parameters.AddWithValue("@Password", Password);
                //sqlcmd.Parameters.AddWithValue("@Gender", Gender);
                //sqlcmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

                sqlcmd.CommandType = CommandType.StoredProcedure;
                //var result=
                sqlcon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

                return Request.CreateResponse("succesfully Updated");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(ex.ToString());
            }
        } 

        [HttpDelete]
        public void DeleteUser(long UserID)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_DeleteUser";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                sqlcmd.Parameters.AddWithValue("@UserID", UserID);

                sqlcmd.CommandType = CommandType.StoredProcedure;
                //var result=
                sqlcon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

            }
            catch(Exception ex)
            {
                //return Request.CreateResponse(ex.ToString());
            }
        }
        

        [HttpGet]
        public IHttpActionResult user(long UserID,long UserRoleID)
        {
            RegisterUser user = new RegisterUser();
            try
            {
                DataSet ds=new DataSet();
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_GetUser";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                sqlcmd.Parameters.AddWithValue("@UserID", UserID);
                sqlcmd.Parameters.AddWithValue("@UserRoleID", UserRoleID);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcon.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                adapter.Fill(ds);

                if(ds.Tables[0].Rows.Count>0)
                {
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["FirstName"].ToString()))
                    {
                        user.FName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    }
                    else
                    {
                        user.FName = string.Empty;
                    }
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["LastName"].ToString()))
                    {
                        user.LName = ds.Tables[0].Rows[0]["LastName"].ToString();
                    }
                    else
                    {
                        user.LName = string.Empty;
                    }
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Address"].ToString()))
                    {
                        user.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    }
                    else
                    {
                        user.Address = string.Empty;
                    }
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Contact"].ToString()))
                    {
                        user.Contact = ds.Tables[0].Rows[0]["Contact"].ToString();
                    }
                    else
                    {
                        user.Contact = string.Empty;
                    }
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Gender"].ToString()))
                    {
                        user.Gender = ds.Tables[0].Rows[0]["Gender"].ToString();
                    }
                    else
                    {
                        user.Gender = string.Empty;
                    }
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["DateOfBirth"].ToString()))
                    {
                        user.DoB = DateTime.Parse(ds.Tables[0].Rows[0]["DateOfBirth"].ToString());
                    }
                    else
                    {
                        user.DoB = DateTime.Parse(string.Empty);
                    }
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["DateOfBirth"].ToString()))
                    {
                        user.Email = (ds.Tables[0].Rows[0]["DateOfBirth"].ToString());
                    }
                    else
                    {
                        user.Email = string.Empty;
                    }
                }

                sqlcon.Close();
            }
            catch (Exception ex)
            {

                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }

            return Ok(user);
        }

        [HttpPut]
        public void ChangePassword(string Email,string Password)
        {
            SqlConnection sqlcon = new SqlConnection(connection);
            string storedprocedure = "BagByte_01_UpdatePassword";

            SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

            sqlcmd.Parameters.AddWithValue("@Email", Email);
            sqlcmd.Parameters.AddWithValue("@Password", Password);

            sqlcmd.CommandType = CommandType.StoredProcedure;
            //var result=
            sqlcon.Open();
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }

        #endregion User 

        #region Product
        [HttpPost]
        public async Task<IHttpActionResult> InsertProduct()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return StatusCode(HttpStatusCode.UnsupportedMediaType);
                }
                var FilePath="";
                var FileName="";

                var files = await Request.Content.ReadAsMultipartAsync();

                var Name = await files.Contents[0].ReadAsStringAsync();
                //var Image = await files.Contents[1].ReadAsByteArrayAsync();

                var httprequest = HttpContext.Current.Request;

                if(httprequest.Files.Count>0)
                {
                    foreach(string file in httprequest.Files)
                    {
                        var postedFile=httprequest.Files[file];
                        FileName=postedFile.FileName;
                        FilePath = HttpContext.Current.Server.MapPath("~/Images/productcategory/" + postedFile.FileName);
                        postedFile.SaveAs(FilePath);
                    }
                }
                
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_InsertImage";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                sqlcmd.Parameters.AddWithValue("@ProductName", Name);
                sqlcmd.Parameters.AddWithValue("@ImageLocation",FilePath);
                sqlcmd.Parameters.AddWithValue("@ImageName",FileName );

                sqlcmd.CommandType = CommandType.StoredProcedure;
                //var result=
                sqlcon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

                return Ok();

                //Stream stream = Content.ReadAsStreamAsync().Result;
                //Image image = Image.FromStream(stream);
                
                //String filePath = HostingEnvironment.MapPath("~/Images/");
                //String[] headerValues = (String[])Request.Headers.GetValues("UniqueId");
                //String fileName = headerValues[0] + ".jpg";
                //String fullPath = Path.Combine(filePath, fileName);
                //image.Save(fullPath);
            }
            catch(Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllProductCategory()
        {
          List<Productcategory> pc = new List<Productcategory>();
            try
            {
                //DataSet ds=new DataSet();
                //SqlConnection sqlcon = new SqlConnection(connection);
                //string storedprocedure = "BagByte_01_GetProductCategory";

                //SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                ////sqlcmd.Parameters.AddWithValue("@UserID", UserID);
                ////sqlcmd.CommandType = CommandType.StoredProcedure;

                //sqlcon.Open();

                //SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                //adapter.Fill(ds);
                //sqlcon.Close();

                string Path = "D:/VINAY/BagByteAPI/BagByteAPI/Images/ProductCategory";
                string[] Images = Directory.GetFiles(Path);

                long ProductID = 0;
                for (int i = 0; i < Images.Length; i++)
                {
                    ProductID++;
                    Productcategory temppc = new Productcategory();

                    temppc.ProductID = ProductID;
                    temppc.ProCatName = "Product_"+Convert.ToString(ProductID);
                    //temppc.ProImage=(byte[])(ds.Tables[0].Rows[i]["ProductCategoryImage"]);
                    temppc.ImageLocation = Images[i];
                    temppc.ImageName = "Product_" + Convert.ToString(ProductID);

                    pc.Add(temppc);
                }
                
            }
            catch(Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }
            return Ok(pc);           
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertSubProduct()
        {
            try
            {
                decimal Price1;
                int Quantity1;
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return StatusCode(HttpStatusCode.UnsupportedMediaType);
                }
                var FilePath = "";
                var FileName = "";

                var files = await Request.Content.ReadAsMultipartAsync();

                var Name = await files.Contents[0].ReadAsStringAsync();
                var Price=await (files.Contents[1].ReadAsStringAsync());
                var Desc=await files.Contents[2].ReadAsStringAsync();
                var Quantity=await files.Contents[3].ReadAsStringAsync();
                var BrandName=await files.Contents[4].ReadAsStringAsync();
                //var Image = await files.Contents[1].ReadAsByteArrayAsync();

                Price1 = decimal.Parse(Price);
                Quantity1 = int.Parse(Quantity);

                var httprequest = HttpContext.Current.Request;

                if (httprequest.Files.Count > 0)
                {
                    foreach (string file in httprequest.Files)
                    {
                        var postedFile = httprequest.Files[file];
                        FileName = postedFile.FileName;
                        FilePath = HttpContext.Current.Server.MapPath("~/Images/products/" + postedFile.FileName);
                        postedFile.SaveAs(FilePath);
                    }
                }

                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_Insertproduct";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                sqlcmd.Parameters.AddWithValue("@ProductName", Name);
                sqlcmd.Parameters.AddWithValue("@Price", Price1);
                sqlcmd.Parameters.AddWithValue("@Desc", Desc);
                sqlcmd.Parameters.AddWithValue("@Quantity", Quantity1);
                sqlcmd.Parameters.AddWithValue("@BrandName", BrandName);
                sqlcmd.Parameters.AddWithValue("@ImageLocation", FilePath);
                sqlcmd.Parameters.AddWithValue("@ImageName", FileName);

                sqlcmd.CommandType = CommandType.StoredProcedure;
                //var result=
                sqlcon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();


                return Ok();
            }
            catch(Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllSubProduct(long ProductCatID)
        {
            List<Product> pc = new List<Product>();
            try
            {
                DataSet ds = new DataSet();
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_GetAllProducts";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                sqlcmd.Parameters.AddWithValue("@ProductCatID", ProductCatID);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcon.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                adapter.Fill(ds);
                sqlcon.Close();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Product temppc = new Product();

                    temppc.ProductID = long.Parse(ds.Tables[0].Rows[i]["ProductID"].ToString());
                    temppc.ProductName = ds.Tables[0].Rows[i]["ProductName"].ToString();
                    temppc.ProCatName = ds.Tables[0].Rows[i]["ProductCatName"].ToString();
                    temppc.Price =decimal.Parse(ds.Tables[0].Rows[i]["ProductPrice"].ToString());
                    temppc.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    temppc.BrandName = ds.Tables[0].Rows[i]["BrandName"].ToString();
                    //temppc.ProImage=(byte[])(ds.Tables[0].Rows[i]["ProductCategoryImage"]);
                    temppc.ImageLocation = ds.Tables[0].Rows[i]["ImageLocation"].ToString();
                    temppc.ImageName = ds.Tables[0].Rows[i]["ImageName"].ToString();

                    pc.Add(temppc);
                }

            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }
            return Ok(pc);
        }

        [HttpGet]
        public IHttpActionResult GetProductDetail(long ProductID)
        {
            List<Product> pc = new List<Product>();
            try
            {
                DataSet ds = new DataSet();
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_GetProductDetail";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                sqlcmd.Parameters.AddWithValue("@ProductID", ProductID);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcon.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                adapter.Fill(ds);
                sqlcon.Close();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Product temppc = new Product();

                    temppc.ProductID = long.Parse(ds.Tables[0].Rows[i]["ProductID"].ToString());
                    temppc.ProductName = ds.Tables[0].Rows[i]["ProductName"].ToString();
                    temppc.ProCatName = ds.Tables[0].Rows[i]["ProductCategoryName"].ToString();
                    temppc.Price = decimal.Parse(ds.Tables[0].Rows[i]["ProductPrice"].ToString());
                    temppc.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    temppc.BrandName = ds.Tables[0].Rows[i]["BrandName"].ToString();
                    //temppc.ProImage=(byte[])(ds.Tables[0].Rows[i]["ProductCategoryImage"]);
                    //temppc.ImageLocation = ds.Tables[0].Rows[i]["ImageLocation"].ToString();
                    temppc.ImageName = ds.Tables[0].Rows[i]["ImageName"].ToString();

                    pc.Add(temppc);
                }

            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }
            return Ok(pc);
        }

        #endregion 

        #region Order
        [HttpPost]
        public HttpResponseMessage InsertOrder(long ProductID,long UserID,long Quantity)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_InsertOrder";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                sqlcmd.Parameters.AddWithValue("@ProductID",ProductID);
                sqlcmd.Parameters.AddWithValue("@Quantity", Quantity);
                sqlcmd.Parameters.AddWithValue("@UserID", UserID);
                //sqlcmd.Parameters.AddWithValue("@Contact", Contact);
                //sqlcmd.Parameters.AddWithValue("@Email", Email);
                //sqlcmd.Parameters.AddWithValue("@Password", Password);
                //sqlcmd.Parameters.AddWithValue("@Gender", Gender);
                //sqlcmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

                sqlcmd.CommandType = CommandType.StoredProcedure;
                //var result=
                sqlcon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

                return Request.CreateResponse("Succesfully inserted");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(ex.ToString());
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllOrders(long UserID)
        {
            List<Orders> orders = new List<Orders>();
            try
            {
                DataSet ds = new DataSet();
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_GetAllOrders";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                sqlcmd.Parameters.AddWithValue("@UserID", UserID);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcon.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                adapter.Fill(ds);
                sqlcon.Close();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Orders temporder = new Orders();

                    temporder.OrderID = long.Parse(ds.Tables[0].Rows[i]["OrderID"].ToString());
                    temporder.ProductImage = ds.Tables[0].Rows[i]["ImageLocation"].ToString();
                    temporder.ProductName = ds.Tables[0].Rows[i]["ProductName"].ToString();
                    temporder.BrandName = ds.Tables[0].Rows[i]["BrandName"].ToString();
                    temporder.DeliveryDate = DateTime.Parse(ds.Tables[0].Rows[i]["DeliveryDate"].ToString());
                    
                    orders.Add(temporder);
                }

            }
            catch(Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }

            return Ok(orders);
        }

        [HttpGet]
        public IHttpActionResult GetOrderDetail(long OrderID)
        {
            Orders temporder = new Orders();
            try
            {
                DataSet ds = new DataSet();
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_GetOrderDetail";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                //sqlcmd.Parameters.AddWithValue("@UserID", UserID);
                sqlcmd.Parameters.AddWithValue("@OrderID", OrderID);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcon.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    temporder.OrderID = long.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                    temporder.ProductName = ds.Tables[0].Rows[0]["ProductName"].ToString();
                    temporder.ProductImage = ds.Tables[0].Rows[0]["ProductImage"].ToString();
                    temporder.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                    temporder.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                    temporder.Address = (ds.Tables[0].Rows[0]["Address"].ToString());
                    temporder.DeliveryDate =DateTime.Parse(ds.Tables[0].Rows[0]["DeliveryDate"].ToString());
                }

                sqlcon.Close();
            }
            catch(Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }
            return Ok(temporder);
           
        }
        #endregion

        #region Cart

        [HttpPost]
        public IHttpActionResult AddProductToCart(long ProductID,long UserID)   
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_AddToCart";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                //sqlcmd.Parameters.AddWithValue("@UserID", UserID);
                sqlcmd.Parameters.AddWithValue("@ProductID", ProductID);
                sqlcmd.Parameters.AddWithValue("@UserID", UserID);

                sqlcmd.CommandType = CommandType.StoredProcedure;
                //var result=
                sqlcon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

            }
            catch(Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }
            return Ok();
           
        }

        [HttpGet]
        public IHttpActionResult GetCartList(long UserID)
        {
            List<Carts> orders = new List<Carts>();
         //   List<Orders> orders = new List<Orders>();
            try
            {
                DataSet ds = new DataSet();
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_GetCartList";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                sqlcmd.Parameters.AddWithValue("@UserID", UserID);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcon.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                adapter.Fill(ds);
                sqlcon.Close();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Carts temporder = new Carts();

                    temporder.CartID = long.Parse(ds.Tables[0].Rows[i]["CartID"].ToString());
                    temporder.ProductID = long.Parse(ds.Tables[0].Rows[i]["ProductID"].ToString());
                    temporder.ProductName = ds.Tables[0].Rows[i]["ProductName"].ToString();
                    temporder.Quantity = int.Parse(ds.Tables[0].Rows[i]["Quantity"].ToString());
                    temporder.Price = decimal.Parse(ds.Tables[0].Rows[i]["ProductPrice"].ToString());
                    temporder.ProductImage = ds.Tables[0].Rows[i]["ImageName"].ToString();
                    
                    orders.Add(temporder);
                }

            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }

            return Ok(orders);
           // return Ok();
        }

        [HttpDelete]
        public void RemoceFromCart(long CartID)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_RemoveFromCart";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                sqlcmd.Parameters.AddWithValue("@UserID", CartID);

                sqlcmd.CommandType = CommandType.StoredProcedure;
                //var result=
                sqlcon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

            }
            catch (Exception ex)
            {
                //return Request.CreateResponse(ex.ToString());
            }
        }
        #endregion

        #region WishList

        [HttpPost]
        public IHttpActionResult AddProductToWishlist(long CartID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_AddToWishlist";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                //sqlcmd.Parameters.AddWithValue("@UserID", UserID);
                sqlcmd.Parameters.AddWithValue("@CartID", CartID);

                sqlcmd.CommandType = CommandType.StoredProcedure;
                //var result=
                sqlcon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }
            return Ok();

        }

        [HttpGet]
        public IHttpActionResult GetWishList(long UserID)
        {
            List<Wishlists> Wishlist = new List<Wishlists>();
            try
            {
                DataSet ds = new DataSet();
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_GetWishList";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                sqlcmd.Parameters.AddWithValue("@UserID", UserID);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcon.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                adapter.Fill(ds);
                sqlcon.Close();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Wishlists Tempwihlist = new Wishlists();

                    Tempwihlist.WishList = long.Parse(ds.Tables[0].Rows[i]["CartID"].ToString());
                    Tempwihlist.ProductID = long.Parse(ds.Tables[0].Rows[i]["ProductID"].ToString());
                    Tempwihlist.ProductName = ds.Tables[0].Rows[i]["ProductName"].ToString();
                    Tempwihlist.ProductCatName = ds.Tables[0].Rows[i]["ProductCategoryName"].ToString();
                    Tempwihlist.Price = decimal.Parse(ds.Tables[0].Rows[i]["ProductPrice"].ToString());
                    Tempwihlist.ProductImage = ds.Tables[0].Rows[i]["ImageName"].ToString();

                    Wishlist.Add(Tempwihlist);
                }

            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }

            return Ok(Wishlist);
        }
        #endregion
        #region Feedback
        [HttpPost]
        public void InsertFeedBack([FromBody]Feedback Feedback)
        {
            SqlConnection sqlcon = new SqlConnection(connection);
            string storedprocedure = "BagByte_01_InsertFeedback";

            SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

            sqlcmd.Parameters.AddWithValue("@UserID", Feedback.UserID);
            sqlcmd.Parameters.AddWithValue("@ProductID", Feedback.ProductID);
            sqlcmd.Parameters.AddWithValue("@Description", Feedback.Description);

            sqlcmd.CommandType = CommandType.StoredProcedure;
            //var result=
            sqlcon.Open();
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
    }
}
