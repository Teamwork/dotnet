using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Teamwork;
using Teamwork.Projects.Base.Model;


namespace TeamWork.Handler
{
  public class CalendarEndpoint
  {

    private readonly Client client;

    /// <summary>
    /// Constructor for Project Handler
    /// </summary>
    public CalendarEndpoint(Client pClient)
    {
      this.client = pClient;
    }




    /// <summary>
    ///   Returns all projects the user has access to
    /// </summary>
    /// <returns></returns>
    public async Task<List<Event>> GetEventsForUser(int pUserId)
    {
      try
      {

        var start = DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day;
        var end = DateTime.Now.AddDays(1).Year + DateTime.Now.AddDays(1).Month + DateTime.Now.AddDays(1).Day;

        var requestString = $"/calendarevents.json?page=1&startDate={start}&endDate={end}&userId={pUserId}";
        var data = await client.HttpClient.GetListAsync<Event>(requestString, "projects", null);
        if (data.StatusCode == HttpStatusCode.OK) return data.List;
        if (data.StatusCode == HttpStatusCode.InternalServerError)
        {
          throw new Exception(data.Message);
        }
        return null;
      }
      catch (Exception ex)
      {
        throw new Exception("Error processing Teamwork API Request: ", ex);
      }
    }

  }
}
