## Controller
    - là một lớp kế thừa Controller của thư viện : Microsoft.AspNetCore.Mvc
    - Action trong Controller là một phương thức public (Không được static)
    - Action trả về bất kì kiểu dữ liệu nào, phổ biến là IActionResult
    - các dịch vụ inject vào Controller thông qua hàm tạo
## View
    - là file.cshtml
    - View cho Action lưu tại :/View/Controller/ActionName.cshtml
    - thêm thư mục lưu trữ view:
    //{0} = ten Action
    //{1} = ten Controller
    //{2} = ten Areas
    // RazorViewEngine.ViewExtension(phan duoi cua file tim den(action.cshtml))
    options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
## Cách truyền dữ liệu sang View
    - Model
    - ViewData
    - ViewBag
    - TemData
## Areas
    - Là tên dùng để routing
    - Là cấu trúc thư mục chứa mvc
    - Thiết lập Areas cho Controller =  '''[Areas("areasName")]'''
    - Tạo cấu trúc thư mục

dotnet aspnet-codegenerator area areaName

## Route

## Url generation

## Url Helper: Action, ActionLink, RouteUrl, Link

## HtmlTagHelper