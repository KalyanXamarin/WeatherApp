using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services;

namespace WeatherApp.WebServices
{
    public class ServiceRepository<TResult>
    {
        // Used for making the actual http calls
        private HttpClient Client;

        public string CurrentEnvironment { set; get; }

        /// <summary>
        /// Gets or sets the current endpoint. This should be set by any service extending HttpOperation.
        /// </summary>
        /// <value>The current endpoint.</value>
        public string CurrentEndpoint { get; set; }
        /// <summary>
        /// Initializes a new instance of the http operation class. 
        /// </summary>
        /// <param name="endpoint">Endpoint for the operation, optional.</param>
        /// <exception cref="ArgumentNullException">This exception is thrown when you pass an environment that is null.</exception>
        public ServiceRepository(string environment, string endpoint)
        {
            if (string.IsNullOrEmpty(environment))
            {
                throw new ArgumentNullException(nameof(environment), "You must pass a valid environment string to OperationHelper's constructor. This exception might be caused by Profile.Current() returning null.");
            }

            this.CurrentEnvironment = environment;
            this.Client = new HttpClient();
            this.CurrentEndpoint = endpoint;
        }

        /// <summary>
        /// Retrieves data from the server and deserialises the JSON
        /// </summary>
        /// <returns>The request.</returns>
        public async Task<ServiceResult<TResult>> GetRequest()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new ServiceResult<TResult>(false,"No internet connection");
            }
            try
            {
                var serviceResult = new ServiceResult<TResult>();
                var serviceresponse = await this.Client.GetAsync(this.GetEndPointUrl());
                if (serviceresponse != null && serviceresponse.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        var rawData = await serviceresponse.Content.ReadAsStringAsync();
                        var desiralizedResponse = JsonConvert.DeserializeObject<TResult>(rawData);
                        serviceResult.Result = desiralizedResponse;
                        serviceResult.IsSucess = true;
                    }
                    catch (Exception ex)
                    {
                        serviceResult.IsSucess = false;
                        serviceResult.ErrorMessage=ex.Message;
                    }
                }
                return serviceResult;
            }
            catch (HttpRequestException e)
            {
                return new ServiceResult<TResult>(false, e.Message);
            }
        }

        /// <summary>
        /// Gets the end point URL, by combining the currentEnvironment and currentEndpoint
        /// </summary>
        /// <returns>The end point URL.</returns>
        protected Uri GetEndPointUrl()
        {
            var endpoint = new Uri(this.CurrentEnvironment + this.CurrentEndpoint);
            return endpoint;
        }
    }
}
