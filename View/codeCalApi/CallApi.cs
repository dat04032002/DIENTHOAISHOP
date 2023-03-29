
using System.Net.Http.Headers;




namespace view.CodeCallApi
{
    public class CallApi
    {
        #region snippet_HttpClient

        public static HttpClient client = new HttpClient();


        public static string APILINK = "https://localhost:44313";


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
        public static async Task<Object> Get( string LinkAPI)
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
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

            }
            return obj;
        }
        public static async Task<Object> GetByID(string LinkAPI)
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
        public static async Task<Object> Update(string linkapi, Object temp)
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
                else
                {
                    obj = "";
                }
            }
            catch (Exception e)
            {
                e.ToString();
                obj = "";
            }
            return obj;
        }
        public static async Task<Object> Insert(string linkapi, Object temp)
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
                else
                {
                    obj = null;
                }
            }
            catch (Exception e)
            {
                e.ToString();
              
            }
            return obj;
        }
       
    }

}