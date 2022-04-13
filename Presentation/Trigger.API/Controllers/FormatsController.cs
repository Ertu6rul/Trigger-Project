﻿using Amazon.S3.Model;
using IronPython.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Scripting.Hosting;
using Trigger.Application.Repositories;
using Trigger.Domain.Entities;
using Trigger.Domain.Entities.Models;

namespace Trigger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatsController : ControllerBase
    {
        readonly private IFormatWriteRepository _formatWriteRepository;
        readonly private IFormatReadRepository _formatReadRepository;

        public FormatsController(
            IFormatReadRepository formatReadRepository,
            IFormatWriteRepository formatWriteRepository)
        {
            _formatReadRepository = formatReadRepository;
            _formatWriteRepository = formatWriteRepository;
        }
        [HttpGet]
        public async Task<ActionResult<byte[]>> Get()
        {
            var format = _formatReadRepository.GetByIdAsync(10); // IQueryable(Format)
            var voice = await _formatReadRepository.GetFileFromS3(format.Result.Voice1Url, "YVkoX/2P2uh6V/Q3tjnVYfhORKSODUS8uPgBtz4m", "AKIA6D7UD3FPE6UDHWPC", "badu-bucketaws-deneme");
            return voice;
        }

        [HttpPost]
        public async Task<ActionResult<Format>> Format()
        {
            var files = Request.Form.Files;
            //var files = new List<IFormFile>() { model.Voice1,model.Voice2, model.Voice3 , model.Voice4 , model.Voice5 , model.Voice6 };
            var nameList = _formatReadRepository.ReturnFileNames(files);
            //var nameList = new List<string>() {model.Voice1.FileName, model.Voice2.FileName, model.Voice3.FileName, model.Voice4.FileName, model.Voice5.FileName, model.Voice6.FileName };

            var format = new Format()
            {
                Name = "X",
                Voice1Url = nameList[0],
                Voice2Url = nameList[1],
                Voice3Url = nameList[2],
                Voice4Url = nameList[3],
                Voice5Url = nameList[4],
                Voice6Url = nameList[5],
                Score = 9
            };
            await _formatWriteRepository.AddAsync(format);
            await _formatWriteRepository.SaveAsync();
            await _formatWriteRepository.UploadToS3("YVkoX/2P2uh6V/Q3tjnVYfhORKSODUS8uPgBtz4m", "AKIA6D7UD3FPE6UDHWPC", "badu-bucketaws-deneme", nameList, "AudioFiles", files);




            return CreatedAtAction("Format", new { id = format.Id }, format);


        }
    }
}