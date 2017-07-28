using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TeamworkProjects.Endpoints
{
    using TeamworkProjects;
    using TeamworkProjects.Base.Model;
    using TeamworkProjects.HTTPClient;
    using TeamworkProjects.Response;

    public class TagHandler
    {
        private readonly Client _client;

        /// <summary>
        /// Constructor for Project Handler
        /// </summary>
        /// <param name="client">TeamworkClient (Init needed!)</param>
        public TagHandler(Client client)
        {
            _client = client;
        }


        /// <summary>
        ///   Returns all tags the user has access to
        /// </summary>
        /// <returns></returns>
        public async Task<List<Tag>> GetAllTagsAsync()
        {
           var data = await _client.HttpClient.GetListAsync<Tag>("tags.json","tags", null);
           if (data.StatusCode == HttpStatusCode.OK) return data.List;
            return null;
        }


        /// <summary>
        ///   Returns all tags the user has access to
        /// </summary>
        /// <returns></returns>
        public async Task<TagResponse> GetTagAsync(int tag_id)
        {
                var data = await _client.HttpClient.GetAsync<TagResponse>("/tags/" + tag_id + ".json", null);
                if (data.StatusCode == HttpStatusCode.OK) return (TagResponse)data.ContentObj;
           return null;
        }


        /// <summary>
        ///   Add a new Tag
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponse<int>> AddTagAsync(Tag theTag)
        {
  
                string post = JsonConvert.SerializeObject(theTag);
                return
                  await _client.HttpClient.PostWithReturnAsync("/tags.json", new StringContent("{\"tag\": " + theTag + "}", Encoding.UTF8));
            
        }


        /// <summary>
        ///   Add a new Tag
        /// </summary>
        /// <returns></returns>
        public async Task<bool> UpdateTagAsync(Tag theTag)
        {
            try
            {
       
                    string post = JsonConvert.SerializeObject(theTag);
                    await _client.HttpClient.PutAsync("/tags/" + theTag.ID + ".json", new StringContent("{\"tag\": " + post + "}", Encoding.UTF8));
                    return true;
                
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete a Task
        /// </summary>
        /// <param name="tagid"></param>
        /// <returns></returns>
        public async Task<bool> DeleteTask(int tagid)
        {
 
                var response = await _client.HttpClient.DeleteAsync("/tags/" + tagid + ".json");
            
            return false;
        }

    }
}
