using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;

namespace SNT.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinaryUtility;

        public CloudinaryService(Cloudinary cloudinaryUtility)
        {
            this.cloudinaryUtility = cloudinaryUtility;
        }

        public Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
