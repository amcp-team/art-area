using System.Collections.Generic;
using ArtArea.Web.Models;
using ArtArea.Web.ViewModels;

namespace ArtArea.Web.Models
{
    public static class DataStorage
    {
      // public static List<byte[]> UploadedFiles = new List<byte[]>();

      public static List<FileViewModel> UploadedFiles = new List<FileViewModel>();

      public static List<CommentViewModel> Comments = new List<CommentViewModel>(); 
    }

}