﻿#region FileHeader
// ==========================================================
// File:            TeamworkProjects.FileHandler.cs
// Last Mod:        19.07.2016
// Created:         19.07.2016
// Created By:      Tim cadenbach
//  
// Copyright (C) 2016 Digital Crew Limited
// History:
//  19.07.2016 - Created
//  ==========================================================
#endregion

#region Imports

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teamwork.Client;
using TeamworkProjects.HTTPClient;
using Teamwork.Shared.Schema.Projects.V1;
using Teamwork.Shared.Schema.Projects.V1.Response;
using TeamworkProjects.Response;

#endregion

namespace Teamwork.Projects.Endpoints
{

    /// <summary>
    /// 
    /// </summary>
    public class PendingFile
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "ref")]
        public string Reference { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FileUploadResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "pendingFile")]
        public PendingFile pendingFile { get; set; }
    }

    public class FileResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "file")]
        public TeamWorkFile File { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public String Status { get; set; }
    }


    public class ProjectFilesResult
    {
        public string company { get; set; }
        public string name { get; set; }
        public string id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "files")]
        public List<TeamWorkFile> Files { get; set; }
    }

    public class FilesResponse
    {
        public ProjectFilesResult project { get; set; }
    }

    /// <summary>
    /// Handler for Activities
    /// </summary>
    public class FileHandler
    {
        private readonly Client.Client client;


        public delegate void ProgressChangesd(object sender, double e);
        public event ProgressChangesd onProgressChanged;
        /// <summary>
        /// Constructor for Project Handler
        /// </summary>
        /// <param name="client">TeamworkClient (Init needed!)</param>
        public FileHandler(Client.Client client)
        {
            this.client = client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            var fs = new FileStream(fileName,
                FileMode.Open,
                FileAccess.Read);
            var br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int) numBytes);
            return buff;
        }

        /// <summary>
        /// Upload a file to a given project
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="description"></param>
        /// <param name="filepath"></param>
        /// <param name="filename"></param>
        /// <param name="isPrivate">default false</param>
        /// <param name="categoryID">default 0</param>
        /// <returns></returns>
        public async Task<bool> UploadFileToProject(int projectID, string description, string filepath,
            string filename, bool isPrivate = false, int categoryID = 0,string categoryName = "", string notify = "", string grantaccess = "", string pApiKey = "", string pDomain = "")
        {

            HttpClientHandler hand = new HttpClientHandler();
            ProgressMessageHandler processMessageHander = new ProgressMessageHandler(hand);
            processMessageHander.HttpSendProgress += ProcessMessageHander_HttpSendProgress;
            var clientwReport = Client.GetTeamworkClient(new Uri(pDomain), pApiKey,processMessageHander);
            using (var content = new MultipartFormDataContent())
                {
                    var info = new FileInfo(filepath);
                    FileStream fs = info.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                var streamContent = new StreamContent(fs);
                    streamContent.Headers.Add("Content-Type", "application/octet-stream");
                    streamContent.Headers.Add("Content-Disposition",
                        "form-data; name=\"file\"; filename=\"" + Path.GetFileName(filepath) + "\"");
                    content.Add(streamContent, "file", Path.GetFileName(filepath));
                
                HttpResponseMessage message = await clientwReport.HttpClient.PostAsync("pendingfiles.json", content);

                    if (message.StatusCode != HttpStatusCode.OK)
                    {
                        using (Stream responseStream = await message.Content.ReadAsStreamAsync())
                        {
                            string jsonMessage = new StreamReader(responseStream).ReadToEnd();
                            var result = JsonConvert.DeserializeObject<FileUploadResponse>(jsonMessage);

                            var file = new TeamWorkFile
                            {
                                description = description,
                                Name = filename,
                                PendingFileRef = result.pendingFile.Reference,
                                Isprivate = isPrivate == false ? "0" : "1",
                               
                            };

                            if (categoryID > -1)
                            {
                                file.CategoryId = categoryID.ToString(CultureInfo.InvariantCulture);
                                file.CategoryName = "";
                            }
                            else
                            {
                                file.CategoryName = "No Category";
                            }
                            if (!string.IsNullOrEmpty(notify)) file.notify = notify;
                            if (!string.IsNullOrEmpty(grantaccess)) file.GrantAccessTo = grantaccess;


                            try
                            {
                            var response = await clientwReport.HttpClient.PostWithReturnAsync("/projects/" + projectID + "/files.json",
                                    new StringContent("{\"file\": " + JsonConvert.SerializeObject(file) + "}", Encoding.UTF8));

                            if (response.StatusCode == HttpStatusCode.OK)
                                return true;
                        }
                            catch (Exception ex)
                            {
                                throw ex;
                            }


                        }
                    }
                    return false;
                }
        }


        public async Task<bool> UploadFileToTask(int pProjectId, int pTaskId, string description, string filepath,
    string filename, bool isPrivate = false, int categoryID = 0)
        {

            using (var content = new MultipartFormDataContent())
            {
                var info = new FileInfo(filepath);
                FileStream fs = info.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                var streamContent = new StreamContent(fs);
                streamContent.Headers.Add("Content-Type", "application/octet-stream");
                streamContent.Headers.Add("Content-Disposition","form-data; name=\"file\"; filename=\"" + Path.GetFileName(filepath) + "\"");
                content.Add(streamContent, "file", Path.GetFileName(filepath));

                HttpResponseMessage message = await this.client.HttpClient.PostAsync("pendingfiles.json", content);

                if (message.StatusCode != HttpStatusCode.OK)
                {
                    using (Stream responseStream = await message.Content.ReadAsStreamAsync())
                    {
                        string jsonMessage = new StreamReader(responseStream).ReadToEnd();
                        var result = JsonConvert.DeserializeObject<FileUploadResponse>(jsonMessage);

                        var file = new TeamWorkFile
                        {
                            CategoryId = categoryID.ToString(CultureInfo.InvariantCulture),
                            CategoryName = "",
                            description = description,
                            Name = filename,
                            PendingFileRef = result.pendingFile.Reference,
                            Isprivate = isPrivate == false ? "0" : "1"
                        };

                        var response = await client.HttpClient.PostWithReturnAsync("/project/" + pProjectId + "/tasks/" + pTaskId + "/files.json",
                            new StringContent("{\"file\": " + JsonConvert.SerializeObject(file) + "}", Encoding.UTF8));

                        if (response.StatusCode == HttpStatusCode.OK)
                            return true;
                    }
                }
                return false;
            }
        }

        public async Task<bool> UploadFileToMessage(int pProjectId, int pMessageId, string description, string filepath,
    string filename, bool isPrivate = false, int categoryID = 0)
        {

            using (var content = new MultipartFormDataContent())
            {
                var info = new FileInfo(filepath);
                FileStream fs = info.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                var streamContent = new StreamContent(fs);
                streamContent.Headers.Add("Content-Type", "application/octet-stream");
                streamContent.Headers.Add("Content-Disposition",
                    "form-data; name=\"file\"; filename=\"" + Path.GetFileName(filepath) + "\"");
                content.Add(streamContent, "file", Path.GetFileName(filepath));

                HttpResponseMessage message = await this.client.HttpClient.PostAsync("pendingfiles.json", content);

                if (message.StatusCode != HttpStatusCode.OK)
                {
                    using (Stream responseStream = await message.Content.ReadAsStreamAsync())
                    {
                        string jsonMessage = new StreamReader(responseStream).ReadToEnd();
                        var result = JsonConvert.DeserializeObject<FileUploadResponse>(jsonMessage);

                        var file = new TeamWorkFile
                        {
                            CategoryId = categoryID.ToString(CultureInfo.InvariantCulture),
                            CategoryName = "",
                            description = description,
                            Name = filename,
                            PendingFileRef = result.pendingFile.Reference,
                            Isprivate = isPrivate == false ? "0" : "1"
                        };

                        var response = await client.HttpClient.PostWithReturnAsync("/project/" + pProjectId + "/messages/" + pMessageId + "/files.json",
                            new StringContent("{\"file\": " + JsonConvert.SerializeObject(file) + "}", Encoding.UTF8));

                        if (response.StatusCode == HttpStatusCode.OK)
                            return true;
                    }
                }
                return false;
            }
        }

        public async Task<string> UploadFileToProjectGetFileRefBack(int projectID, string description, string filepath,
    string filename, bool isPrivate = false, int categoryID = 0)
        {

            using (var content = new MultipartFormDataContent())
            {
                var info = new FileInfo(filepath);
                FileStream fs = info.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                var streamContent = new StreamContent(fs);
                streamContent.Headers.Add("Content-Type", "application/octet-stream");
                streamContent.Headers.Add("Content-Disposition",
                    "form-data; name=\"file\"; filename=\"" + Path.GetFileName(filepath) + "\"");
                content.Add(streamContent, "file", Path.GetFileName(filepath));

                HttpResponseMessage message = await this.client.HttpClient.PostAsync("pendingfiles.json", content);

                if (message.StatusCode != HttpStatusCode.OK)
                {
                    using (Stream responseStream = await message.Content.ReadAsStreamAsync())
                    {
                        string jsonMessage = new StreamReader(responseStream).ReadToEnd();
                        var result = JsonConvert.DeserializeObject<FileUploadResponse>(jsonMessage);
                        return result.pendingFile.Reference;
                    }
                }
                return "";
            }
        }


        private void ProcessMessageHander_HttpSendProgress(object sender, HttpProgressEventArgs e)
        {
            onProgressChanged?.Invoke(sender,e.ProgressPercentage);
        }


        /// <summary>
        /// Upload a file to a given project
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="description"></param>
        /// <param name="filepath"></param>
        /// <param name="filename"></param>
        /// <param name="fileid"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> UploadNewFileVersionToProject(int projectID, string description,
            string filepath, string filename, string fileid, string pApiKey = "", string pDomain = "")
        {

            HttpClientHandler hand = new HttpClientHandler();
            ProgressMessageHandler processMessageHander = new ProgressMessageHandler(hand);
            processMessageHander.HttpSendProgress += ProcessMessageHander_HttpSendProgress;
            var clientwReport = Client.GetTeamworkClient(new Uri(pDomain), pApiKey, processMessageHander);
            using (var content = new MultipartFormDataContent())
                {
                    var info = new FileInfo(filepath);
                    FileStream fs = info.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);


                    var streamContent = new StreamContent(fs);
                    streamContent.Headers.Add("Content-Type", "application/octet-stream");
                    streamContent.Headers.Add("Content-Disposition",
                        "form-data; name=\"file\"; filename=\"" + Path.GetFileName(filepath) + "\"");
                    content.Add(streamContent, "file", Path.GetFileName(filepath));
                    try
                    {
                        HttpResponseMessage message = await clientwReport.HttpClient.PostAsync("pendingfiles.json", content);
                        if (message.StatusCode != HttpStatusCode.OK)
                        {
                            using (Stream responseStream = await message.Content.ReadAsStreamAsync())
                            {
                                string jsonMessage = new StreamReader(responseStream).ReadToEnd();
                                var result = JsonConvert.DeserializeObject<FileUploadResponse>(jsonMessage);

                                var file = new TeamworkFileVersion
                                {
                                    description = description + ".",
                                    pendingFileRef = result.pendingFile.Reference
                                };

                                var response =
                                    await
                                        client.HttpClient.PostWithReturnAsync("/files/" + fileid + ".json",
                                            new StringContent(
                                                "{\"fileversion\": " + JsonConvert.SerializeObject(file) + "}",
                                                Encoding.UTF8));

                                if (response.StatusCode == HttpStatusCode.OK)
                                    return new BaseResponse<bool>(true, HttpStatusCode.OK);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            return new BaseResponse<bool>(false, HttpStatusCode.InternalServerError);
        }


        public async Task<FileResponse> GetFile(int fileID)
        {
            using (var client = new AuthorizedHttpClient(this.client.ApiKey, this.client.Domain))
            {
                var data = await client.GetAsync<FileResponse>("files/" + fileID + ".json", null);
                if (data.StatusCode == HttpStatusCode.OK) return (FileResponse) data.ContentObj;
            }
            return new FileResponse {Status = "ERROR", File = null};
        }

        public async Task<FilesResponse> GetFilesInProject(int projectID)
        {
            using (var client = new AuthorizedHttpClient(this.client.ApiKey, this.client.Domain))
            {
                var data = await client.GetAsync<FilesResponse>("projects/" + projectID + "/files.json", null);
                if (data.StatusCode == HttpStatusCode.OK) return (FilesResponse) data.ContentObj;
            }
            return new FilesResponse {project = null};
        }
    }
}