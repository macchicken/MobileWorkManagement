using System.ComponentModel.DataAnnotations;

namespace Int.MobileUI.Models
{
    public class AppSystemCreateModel
    {
        [Required(ErrorMessage = "编码不能为空。")]
        public string Code { get; set; }
        [Required(ErrorMessage = "名称不能为空。")]
        public string Name { get; set; }
        public int SortCode { get; set; }
        public string SSOAuthAddress { get; set; }
        public string Icon { get; set; }
    }

    public class AppSystemUpdateModel
    {
        [Required(ErrorMessage = "应用ID不能为空。")]
        public string Id { get; set; }
        [Required(ErrorMessage = "名称不能为空。")]
        public string Name { get; private set; }
        public int SortCode { get; private set; }
        public int IsEnabled { get; private set; }
        public string SSOAuthAddress { get; private set; }
        public string Icon { get; private set; }
    }
}
