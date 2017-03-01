using System.Collections.Generic;

namespace Planning.Client.MVCApp.Views.Todo
{
    public class DetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}