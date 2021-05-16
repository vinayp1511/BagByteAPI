using BagByteAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BagByteAPI.Controllers
{
    public class AdminController : ApiController
    {
        string connection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        #region Barcode
        [HttpPost]
        public async Task<IHttpActionResult> InsertBarcode()
        {
            try
            {
                long TempOredrID = 0;
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return StatusCode(HttpStatusCode.UnsupportedMediaType);
                }
                var FilePath = "";
                var FileName = "";

                var files = await Request.Content.ReadAsMultipartAsync();

                var OrderID = await files.Contents[0].ReadAsStringAsync();
                TempOredrID = long.Parse(OrderID);
                //var Image = await files.Contents[1].ReadAsByteArrayAsync();

                var httprequest = HttpContext.Current.Request;

                if (httprequest.Files.Count > 0)
                {
                    foreach (string file in httprequest.Files)
                    {
                        var postedFile = httprequest.Files[file];
                        FileName = postedFile.FileName;
                        FilePath = HttpContext.Current.Server.MapPath("~/Images/Barcode/" + postedFile.FileName);
                        postedFile.SaveAs(FilePath);
                    }
                }

                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_InsertBarcode";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                sqlcmd.Parameters.AddWithValue("@OrderID", TempOredrID);
                sqlcmd.Parameters.AddWithValue("@ImageLocation", FilePath);
                sqlcmd.Parameters.AddWithValue("@ImageName", FileName);

                sqlcmd.CommandType = CommandType.StoredProcedure;
                //var result=
                sqlcon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

                return Ok();

            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllBarcode()
        {
            List<Barcode> barcode = new List<Barcode>();
            try
            {
                DataSet ds = new DataSet();
                SqlConnection sqlcon = new SqlConnection(connection);
                string storedprocedure = "BagByte_01_GetAllBarcodes";

                SqlCommand sqlcmd = new SqlCommand(storedprocedure, sqlcon);

                //sqlcmd.Parameters.AddWithValue("@ProductCatID", ProductCatID);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcon.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                adapter.Fill(ds);
                sqlcon.Close();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Barcode tempbarcode = new Barcode();

                    tempbarcode.BarcodeID = long.Parse(ds.Tables[0].Rows[i]["BarcodeID"].ToString());
                    tempbarcode.OrderID = long.Parse(ds.Tables[0].Rows[i]["OrderID"].ToString());
                    tempbarcode.ImageLocation = ds.Tables[0].Rows[i]["ImageLocation"].ToString();
                    tempbarcode.ImageName = ds.Tables[0].Rows[i]["ImageName"].ToString();
                    
                    barcode.Add(tempbarcode);
                }

            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString()));
            }
            return Ok(barcode);
        }

        #endregion


    }
}
