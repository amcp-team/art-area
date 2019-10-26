using System.Collections.Generic;
namespace ArtArea.Web.ViewModels
{
  public class TaskViewModel
  {
    public string Name {get;set;}
    public string Description{get;set;}
    public List<FileViewModel> Slides{get;set;}

  }

}