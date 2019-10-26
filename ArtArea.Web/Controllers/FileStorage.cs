using System.Collections.Generic;
using ArtArea.Web.Models;

namespace ArtArea.Web.Controller
{
    public static class DataStorage
    {
      public static List<byte[]> UploadedFiles = new List<byte[]>();

      public static List<Comment> Comments = new List<Comment>(); 
    }

}