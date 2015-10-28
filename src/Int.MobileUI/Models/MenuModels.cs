using System.ComponentModel.DataAnnotations;

namespace Int.MobileUI.Models
{
    public class CurrentMenuModel
    {
        public string Id{get;set;}
        public string Name{get;set;}
        public string ParentId{get;set;}
        public string ParentName{ get; set; }
    }

    public class PageMenuListModel
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int SortCode { get; set; }
        public string Icon { get; set; }
    }
    public class MenuListModel
    {
        public string Id { get; set; }
        public string AppSystemId { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int AllowEdit { get; set; }
        public int AllowDelete { get; set; }
        public int SortCode { get; set; }
        public string Icon { get; set; }
        public int IsEnabled { get; set; }
    }

    public class MenuModel
    {
        public string Id { get; set; }
        public string AppSystemId { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int AllowEdit { get; set; }
        public int AllowDelete { get; set; }
        public int SortCode { get; set; }
        public string Icon { get; set; }
        public int IsEnabled { get; set; }
    }

    public class MenuCreateModel
    {
        [Required(ErrorMessage = "请输入应用系统ID")]
        public string AppSystemId { get; set; }
        public string ParentId { get; set; }
        [Required(ErrorMessage = "请输入按钮名称")]
        public string Name { get; set; }
        public string Url { get; set; }
        public int AllowEdit { get; set; }
        public int AllowDelete { get; set; }
        public int SortCode { get; set; }
        public string Icon { get; set; }
    }

    public class MenuUpdateModel
    {
        public string ParentId { get; set; }
        [Required(ErrorMessage = "请输入按钮名称")]
        public string Name { get; set; }
        public string Url { get; set; }
        public int AllowEdit { get; set; }
        public int AllowDelete { get; set; }
        public int SortCode { get; set; }
        public string Icon { get; set; }
        public int IsEnabled { get; set; }
    }
}
