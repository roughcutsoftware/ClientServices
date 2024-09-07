using ClientServices.Dtos;
using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClientServices.Base
{
    public class ViewModelBase<T> : IRepositoryAsync<T> where T : class
    {
        public HttpClient RestClient { get; private set; }

        public ViewModelBase(string baseUrl)
        {
            this.RestClient = new HttpClient();

            this.RestClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<List<T>> GetListAsync(string actionUrl)
        {
            // new up a list of T
            var list = new List<T>();
            
            // get the todos list
            var response = await this.RestClient.GetAsync(actionUrl);

            // check if the response is successful
            if (response.IsSuccessStatusCode)
            {
                // get the response content
                var content = await response.Content.ReadAsStringAsync();

                //check if the response content is not null
                if (!string.IsNullOrEmpty(content))
                {
                    // cast items into a list of items
                    list = JsonConvert.DeserializeObject<List<T>>(content);
                }
            }

            // return the list
            return list;

        }

        // intentionally not implemented for initial commit - Houston
        public Task<T> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> QueryAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(T entity, bool isNewItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
