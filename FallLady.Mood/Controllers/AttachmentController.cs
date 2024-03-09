using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Framework.Core.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace FallLady.Mood.Controllers
{
    public class AttachmentController : BaseController
    {
        [HttpGet]
        public virtual async Task<ActionResult> Image(string id, string folderName)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            if (string.IsNullOrEmpty(folderName))
                return NotFound();

            string path = "";

            var fileExtension = Path.GetExtension(path);
            var mimiType = "";

            Enum.TryParse(folderName, out FileFoldersEnum folder);

            FileFoldersEnum folderEnum = folder;

            path = GetFileUrl(id, folderEnum);
            Debug.Print(path);
            if (!Path.HasExtension(path))
                path += ".jpg";

            if (!System.IO.File.Exists(path))
                return NotFound();

            switch (fileExtension)
            {
                case ".rar":
                    mimiType = "application/x-rar";
                    break;

                default:
                    // code block
                    new FileExtensionContentTypeProvider().TryGetContentType(path, out mimiType);
                    break;
            }
            return File(path, mimiType is null ? "application/octet-stream" : mimiType, Path.GetFileName(path));
        }
    }
}
