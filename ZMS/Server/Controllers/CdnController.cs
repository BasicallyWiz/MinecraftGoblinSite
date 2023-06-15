using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IOFile = System.IO.File;

namespace ZMS.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CdnController : ControllerBase
  {
    [HttpGet]
    public IActionResult Get(string file)
    {
      file = file.Replace("../", "");
      if (!IOFile.Exists($"{Directory.GetCurrentDirectory()}/News/{file}")) return NotFound("File not found");

      string mimeType = "application/octet-stream";
      var fileExtension = Path.GetExtension(file);
      Microsoft.Win32.RegistryKey? registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(fileExtension.ToLower());
      if (registryKey != null && registryKey.GetValue("Content Type") != null)
      {
        mimeType = registryKey.GetValue("Content Type").ToString();
      }

      switch (fileExtension)
      {
        case ".md":
          mimeType = "text/markdown";
          break;
      }

      return File(IOFile.OpenRead($"{Directory.GetCurrentDirectory()}/News/{file}"), mimeType);
    }
  }
}
