﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CPMobile.Helper;
using System.Diagnostics;
using CPMobile.Models;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading;
using CPMobile.Service;
using Xamarin.Forms;
using Akavache;

[assembly: Dependency(typeof(CPFeedService))]
namespace CPMobile.Service
{
    public class CPFeedService :ICPFeeds
    {
        bool initialized = false;

        static string clientId = "WRymObjweyg9fj78Z5FV3R-uHeoVt_Oh";
        static string clientSecret = "NQyjvo7N7eN06Xu9nTHm4jRt0X7IZThNwPAKVnp9GBcOZKm89xIOhbeOIQrOXVJj";
        static string baseUrl = "http://189.211.201.181:75/GazzetaWebservice/";
        
        public CPFeedService()
        {

        }

        public async Task Init()
        {
            //initialized = true;
            //if (!String.IsNullOrEmpty(Settings.AuthToken))
            //{
            //    GetArticleAsync(1);
            //    return;
            //}
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(baseUrl);

            //    // We want the response to be JSON.
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    // Build up the data to POST.
            //    List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
            //    postData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            //    postData.Add(new KeyValuePair<string, string>("client_id", clientId));
            //    postData.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
            //    FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
            //    // Post to the Server and parse the response.
            //    try
            //    {
            //        var response = await client.PostAsync("Token", content);
            //        response.EnsureSuccessStatusCode();
            //        string jsonString = response.Content.ReadAsStringAsync().Result;
            //        CPAuthToken responseData = JsonHelper.Deserialize<CPAuthToken>(jsonString);

            //        Settings.AuthToken = responseData.access_token;
                    
            //        GetArticleAsync(1);
            //        // return the Access Token.
            //        //return responseData.ToString();
            //    }
            //    catch (Exception ex)
            //    {

            //        initialized = false;
            //    }

            //}
        }

        public async Task<CPFeed> GetArticleAsync(int page, int cveCategoria)
        {
            if (!initialized)
                await Init();
            var accessToken = Settings.AuthToken;

            if (!string.IsNullOrEmpty(accessToken))
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Add the Authorization header with the AccessToken.
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                    // create the URL string.
                    string url = string.Format("api/tblnoticias/categoria/{0}", cveCategoria);

                    // make the request
                    HttpResponseMessage response = await client.GetAsync(url);

                    // parse the response and return the data.
                    string jsonString = await response.Content.ReadAsStringAsync();
                    string jsonArmado = "{'items':" + jsonString + "}";

                    CPFeed responseData = JsonHelper.Deserialize<CPFeed>(jsonArmado);                    Debug.WriteLine(responseData);
                    await BlobCache.LocalMachine.InsertObject<CPFeed>("DefaultArticle", responseData, DateTimeOffset.Now.AddDays(1));
                    return responseData;
                }
            }
            else
            {
                Init();
                return null;
            }
        }

        public async Task<string> GetCategorias()
        {


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Add the Authorization header with the AccessToken.
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " );

                    // create the URL string.
                    string url = string.Format("api/tblcategorias", "");

                    // make the request
                HttpResponseMessage response = await client.GetAsync(url);

                    // parse the response and return the data.
                string jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    string jsonArmado = "{\"Categos\":"+jsonString+"}";
                    Debug.WriteLine(jsonArmado);
                    jsonArmado = "{'Categos':[{'$id':'1','cveCategoria':1,'descCategoria':'COMUNIDAD','activo':'S','fechaRegistro':'2017-10-26T23:11:23','fechaActualizacion':'2017-10-26T23:11:23'},{'$id':'2','cveCategoria':2,'descCategoria':'CULTURA','activo':'S','fechaRegistro':'2017-10-26T23:11:23','fechaActualizacion':'2017-10-26T23:11:23'},{'$id':'3','cveCategoria':3,'descCategoria':'ACADEMIA','activo':'S','fechaRegistro':'2017-10-26T23:11:23','fechaActualizacion':'2017-10-26T23:11:23'},{'$id':'4','cveCategoria':4,'descCategoria':'DEPORTES','activo':'S','fechaRegistro':'2017-10-26T23:11:23','fechaActualizacion':'2017-10-26T23:11:23'}]}";
                    CPFeedCat responseData = JsonHelper.Deserialize<CPFeedCat>(jsonArmado);
                    //await BlobCache.LocalMachine.InsertObject<CPFeedCat>("DefaultCategory", responseData, DateTimeOffset.Now.AddDays(1));
                return jsonArmado;
                }
        }

        //public string GetCate(){
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(baseUrl);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        // Add the Authorization header with the AccessToken.
        //        client.DefaultRequestHeaders.Add("Authorization", "Bearer ");

        //        // create the URL string.
        //        string url = string.Format("api/tblcategorias", "");

        //        // make the request
        //        var response = client.GetAsync(url).Result();

        //        // parse the response and return the data.
        //        string jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        //        string jsonArmado = "{\"Categos\":" + jsonString + "}";
        //        Debug.WriteLine(jsonArmado);
        //        jsonArmado = "{'Categos':[{'$id':'1','cveCategoria':1,'descCategoria':'COMUNIDAD','activo':'S','fechaRegistro':'2017-10-26T23:11:23','fechaActualizacion':'2017-10-26T23:11:23'},{'$id':'2','cveCategoria':2,'descCategoria':'CULTURA','activo':'S','fechaRegistro':'2017-10-26T23:11:23','fechaActualizacion':'2017-10-26T23:11:23'},{'$id':'3','cveCategoria':3,'descCategoria':'ACADEMIA','activo':'S','fechaRegistro':'2017-10-26T23:11:23','fechaActualizacion':'2017-10-26T23:11:23'},{'$id':'4','cveCategoria':4,'descCategoria':'DEPORTES','activo':'S','fechaRegistro':'2017-10-26T23:11:23','fechaActualizacion':'2017-10-26T23:11:23'}]}";
        //        CPFeedCat responseData = JsonHelper.Deserialize<CPFeedCat>(jsonArmado);
        //        //await BlobCache.LocalMachine.InsertObject<CPFeedCat>("DefaultCategory", responseData, DateTimeOffset.Now.AddDays(1));
        //        return jsonArmado;
        //    }
        //    return "";
        //}
       

        public async Task<CPFeed> GetForumAsync(int tag)
        {
            
            var accessToken = Settings.AuthToken;

            if (!string.IsNullOrEmpty(accessToken))
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Add the Authorization header with the AccessToken.
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                    // create the URL string.
                    string url = string.Format("v1/Forum/{0}/Messages?page=1", tag);

                    // make the request
                    HttpResponseMessage response = await client.GetAsync(url);

                    // parse the response and return the data.
                    string jsonString = await response.Content.ReadAsStringAsync();
                    CPFeed responseData = JsonHelper.Deserialize<CPFeed>(jsonString);
                    //await BlobCache.LocalMachine.InsertObject<CPFeed>("DefaultForum", responseData, DateTimeOffset.Now.AddDays(1));
                    return responseData;
                }
            }
            else
            {
                
                return null;
            }
        }

        public Task<CPFeed> GetForumAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<bool> GetAccessToken(string username, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                // We want the response to be JSON.
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // Build up the data to POST.
                List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("grant_type", "password"));
                postData.Add(new KeyValuePair<string, string>("client_id", clientId));
                postData.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
                postData.Add(new KeyValuePair<string, string>("username", username));
                postData.Add(new KeyValuePair<string, string>("password", password));
                FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
                // Post to the Server and parse the response.
                try
                {
                    var response = await client.PostAsync("Token", content);
                    response.EnsureSuccessStatusCode();
                    string jsonString = response.Content.ReadAsStringAsync().Result;
                    //object responseData = JsonConvert.DeserializeObject(jsonString);
                    Login responseData = JsonHelper.Deserialize<Login>(jsonString);

                    Settings.AuthLoginToken = responseData.access_token;


                    return true;
                    // return the Access Token.
                    //return responseData.ToString();
                }
                catch (Exception ex)
                {

                    initialized = false;
                    return false;
                }
                return false;

            }
        }

        public async Task<MyProfile> GetMyProfile()
        {
            var loginToken = Settings.AuthLoginToken;

            if (!string.IsNullOrEmpty(loginToken))
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Add the Authorization header with the AccessToken.
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginToken);

                    // create the URL string.
                    string url = string.Format("v1/My/Profile");

                    // make the request
                    HttpResponseMessage response = await client.GetAsync(url);
                    // make the request


                    // parse the response and return the data.
                    string jsonString = await response.Content.ReadAsStringAsync();
                    MyProfile responseData = JsonHelper.Deserialize<MyProfile>(jsonString);


                    await BlobCache.LocalMachine.InsertObject<MyProfile>("DefaultArticle", responseData, DateTimeOffset.Now.AddDays(1));
                    // await dataStorageService.Save_Value("MyProfile", responseData);

                    return responseData;
                }
            }
            else
            {
                return null;
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the page of Articles.
        /// </summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page of articles.</returns>
        public async Task<CPFeed> MyArticles(int page)
        {
            //var loginToken = Settings.AuthLoginToken;
            //if (!string.IsNullOrEmpty(loginToken))
            //{

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Add the Authorization header with the AccessToken.
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer ");

                    // create the URL string.
                    string url = string.Format("v1/My/Articles?page={0}", page);

                    // make the request
                    HttpResponseMessage response = await client.GetAsync(url);

                    // parse the response and return the data.
                    string jsonString = await response.Content.ReadAsStringAsync();
                    CPFeed responseData = JsonHelper.Deserialize<CPFeed>(jsonString);
                    await BlobCache.LocalMachine.InsertObject<CPFeed>("MyArticle", responseData, DateTimeOffset.Now.AddDays(3));
                    
                    return responseData;
                }
            //}
            //else
            //{

            //    return null;
            //}
        }

        public async Task<CPFeed> MyMessage(int page)
        {
            var loginToken = Settings.AuthLoginToken;
            if (!string.IsNullOrEmpty(loginToken))
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Add the Authorization header with the AccessToken.
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginToken);

                    // create the URL string.
                    string url = string.Format("v1/My/Messages?page={0}", page);

                    // make the request
                    HttpResponseMessage response = await client.GetAsync(url);

                    // parse the response and return the data.
                    string jsonString = await response.Content.ReadAsStringAsync();
                    CPFeed responseData = JsonHelper.Deserialize<CPFeed>(jsonString);
                    await BlobCache.LocalMachine.InsertObject<CPFeed>("MyMessage", responseData, DateTimeOffset.Now.AddDays(3));

                    return responseData;
                }
            }
            else
            {

                return null;
            }
        }

        public async Task<CPFeed> MyTips(int page)
        {
            var loginToken = Settings.AuthLoginToken;
            if (!string.IsNullOrEmpty(loginToken))
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Add the Authorization header with the AccessToken.
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginToken);

                    // create the URL string.
                    string url = string.Format("v1/My/tips?page={0}", page);

                    // make the request
                    HttpResponseMessage response = await client.GetAsync(url);

                    // parse the response and return the data.
                    string jsonString = await response.Content.ReadAsStringAsync();

                    CPFeed responseData = JsonHelper.Deserialize<CPFeed>(jsonString);
                    await BlobCache.LocalMachine.InsertObject<CPFeed>("MyTips", responseData, DateTimeOffset.Now.AddDays(3));

                    return responseData;
                }
            }
            else
            {

                return null;
            }
        }

        public async Task<CPFeed> MyBlogs(int page)
        {
            var loginToken = Settings.AuthLoginToken;
            if (!string.IsNullOrEmpty(loginToken))
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Add the Authorization header with the AccessToken.
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginToken);

                    // create the URL string.
                    string url = string.Format("v1/My/blogposts?page={0}", page);

                    // make the request
                    HttpResponseMessage response = await client.GetAsync(url);

                    // parse the response and return the data.
                    string jsonString = await response.Content.ReadAsStringAsync();

                    CPFeed responseData = JsonHelper.Deserialize<CPFeed>(jsonString);
                    await BlobCache.LocalMachine.InsertObject<CPFeed>("MyBlogs", responseData, DateTimeOffset.Now.AddDays(3));

                    return responseData;
                }
            }
            else
            {

                return null;
            }
        }

       

    }
}

