using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using MyDataHandler_DataAccess.DTO;
using MyDataHandler_Services.IServices;
using Newtonsoft.Json;

namespace AzureFunctions
{
    public class LoadInternsData
    {
        private readonly IInternService _internService;

        public LoadInternsData(IInternService internService)
        {
            _internService = internService;
        }

        [FunctionName("LoadInternsData")]
        public async Task Run([BlobTrigger("interns/{name}", Connection = "BlobConnectionString")] CloudBlockBlob myBlob, string name, ILogger log)
        {
            var streamData = await myBlob.DownloadTextAsync();
            var internsList = new List<InternsDTO>();
            if (!string.IsNullOrEmpty(streamData))
            {
                internsList = JsonConvert.DeserializeObject<List<InternsDTO>>(streamData);
            }

            foreach (var intern in internsList)
            {
                await _internService.Create(intern);
            }

            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob} Bytes \n Interns Loaded : {internsList.Count}");
        }
    }
}
