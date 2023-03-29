using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using Common.Entities;


namespace view.CodeCallApi
{
    public class CallApiSanPham
    {
        #region snippet_HttpClient

        public static HttpClient client = new HttpClient();


        public static string APILINK = "https://localhost:44313/";


        #endregion snippet_HttpClient

        private static void Unit()
        {
            try
            {
                client.BaseAddress = new Uri(APILINK);
                client.Timeout = TimeSpan.FromMinutes(30);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch (Exception ex)
            {
               
            }
        }
        public static async Task<Object> SearchIDTemplateAsync(string LinkAPI)
        {
            Unit();

            dynamic result = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(LinkAPI);


                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<Object>();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public static async Task<Object> GetTemplateAsync(string LinkAPI)
        {
            Unit();
            Object obj = new Object();
            try
            {
                HttpResponseMessage response = await client.GetAsync(LinkAPI);

                if (response.IsSuccessStatusCode)
                {
                    obj = await response.Content.ReadAsAsync<Object>();
                }
            }
            catch (Exception ex)
            {
            
            }
            return obj;
        }
        public static async Task<Object> DeleteSanPham( string linkapi,int temp)
        {
            Unit() ;
            Object obj = new Object();
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(linkapi,value: temp);
                if (response.IsSuccessStatusCode)
                {
                    obj=await response.Content.ReadAsAsync<Object>();
                }
            }catch(Exception e)
            {
          
            }
            return obj;
        }
        public static async Task<Object> UpdateSanPham(string linkapi, SanPhammodel temp)
        {
            Unit();
            Object obj = new Object();
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(linkapi, temp);
                if (response.IsSuccessStatusCode)
                {
                    obj = await response.Content.ReadAsAsync<Object>();
                }
            }
            catch (Exception e)
            {
          
            }
            return obj;
        }
        public static async Task<Object> Insert_SanPham(string linkapi, SanPhammodel temp)
        {
            Unit();
            Object obj = new Object();
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(linkapi, temp);
                if (response.IsSuccessStatusCode)
                {
                    obj = await response.Content.ReadAsAsync<Object>();
                }
            }
            catch (Exception e)
            {
               
            }
            return obj;
        }



    }
}