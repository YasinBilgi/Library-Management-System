using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Entites.Models
{
    public partial class MainPage
    {
        public byte Id { get; set; }
        public string? SliderİmageUrl1 { get; set; }
        public string? SliderİmageUrl2 { get; set; }
        public string? SliderİmageUrl3 { get; set; }
        public string? SliderTitle1 { get; set; }
        public string? SliderTite2 { get; set; }
        public string? SliderTitle3 { get; set; }
        public string? SliderSubtitle1 { get; set; }
        public string? SliderSubtitle2 { get; set; }
        public string? SliderSubtitle3 { get; set; }
        public string? ServiceTitle1 { get; set; }
        public string? ServiceTitle2 { get; set; }
        public string? ServiceTitle3 { get; set; }
        public string? ServiceDescription1 { get; set; }
        public string? ServiceDescription2 { get; set; }
        public string? ServiceDescription3 { get; set; }
        public string? LastSavedTitle { get; set; }
        public bool? İsActive { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}
