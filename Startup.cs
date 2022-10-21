using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using App.ExtendMethods;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Routing;
using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using App.Data;
using Microsoft.Extensions.FileProviders;
using System.IO;
using App.Menu;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace App
{
    public class Startup
    {
        public static string ContentRootPath { get; set; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            ContentRootPath = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDistributedMemoryCache();           // Đăng ký dịch vụ lưu cache trong bộ nhớ (Session sẽ sử dụng nó)
            services.AddSession(cfg =>                      // Đăng ký dịch vụ Session
            {                    
                cfg.Cookie.Name = "appmvc";                 // Đặt tên Session - tên này sử dụng ở Browser (Cookie)
                cfg.IdleTimeout = new TimeSpan(0, 30, 0);   // Thời gian tồn tại của Session
            });

            services.AddOptions();                                          // Kích hoạt Options
            var mailsettings = Configuration.GetSection("MailSettings");    // đọc config
            services.Configure<MailSettings>(mailsettings);                 // đăng ký để Inject
            services.AddTransient<IEmailSender, SendMailService>();         // Đăng ký dịch vụ Mail



            services.AddDbContext<AppDbContext>(options =>
            {
                string connectstring = Configuration.GetConnectionString("AppMvcConnectionString");
                options.UseSqlServer(connectstring);
            });

            services.AddControllersWithViews();
            services.AddRazorPages();
            //services.AddTransient(typeof(ILogger<>), typeof(Logger<>));
            services.Configure<RazorViewEngineOptions>(options =>
            {
                // mac dinh se tim theo cau truc /Views/Controller/Action
                //neu tim theo cau truc tren khong thay se tim toi /MyView/Controler/Action

                //{0} = ten Action
                //{1} = ten Controller
                //{2} = ten Areas
                // RazorViewEngine.ViewExtension(phan duoi cua file tim den(action.cshtml))
                options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
            });

            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = false;        // Thêm dấu / vào cuối URL
                options.LowercaseUrls = true;               // url chữ thường
                options.LowercaseQueryStrings = false;      // không bắt query trong url phải in thường
            });


            //services.AddSingleton(typeof(ProductService), typeof(ProductService));
            services.AddSingleton<PlanetService>();

            //dang ki Identity
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Truy cập IdentityOptions
            services.Configure<IdentityOptions>(options =>
            {
                // Thiết lập về Password
                options.Password.RequireDigit = false;              // Không bắt phải có số
                options.Password.RequireLowercase = false;          // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false;    // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false;          // Không bắt buộc chữ in
                options.Password.RequiredLength = 3;                // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 1;           // Số ký tự riêng biệt

                // Cấu hình Lockout - khóa user
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);   // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 5;                        // Thất bại 5 lầ thì khóa
                options.Lockout.AllowedForNewUsers = true;

                // Cấu hình về User.
                options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true; // Email là duy nhất

                // Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = true;        // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false; // Xác thực số điện thoại

            });

            // Cấu hình Cookie
            services.ConfigureApplicationCookie(options =>
            {
                // options.Cookie.HttpOnly = true;  
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = $"/login/";                                 // Url đến trang đăng nhập
                options.LogoutPath = $"/logout/";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";   // Trang khi User bị cấm truy cập
            });
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                // Trên 5 giây truy cập lại sẽ nạp lại thông tin User (Role)
                // SecurityStamp trong bảng User đổi -> nạp lại thông tinn Security
                options.ValidationInterval = TimeSpan.FromSeconds(5);
            });

            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = false;            // Thêm dấu / vào cuối URL
                options.LowercaseUrls = true;                   // url chữ thường
                options.LowercaseQueryStrings = false;          // không bắt query trong url phải in thường
            });


            services.AddAuthorization(options =>
            {
                // User thỏa mãn policy khi có roleclaim: permission với giá trị manage.user
                options.AddPolicy("AdminDropdown", policy =>
                {
                    policy.RequireClaim("permission", "manage.user");
                });

            });

            services.AddAuthentication()
                    .AddGoogle(googleOptions =>
                    {
                        // Đọc thông tin Authentication:Google từ appsettings.json
                        IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");

                        // Thiết lập ClientID và ClientSecret để truy cập API google
                        googleOptions.ClientId = googleAuthNSection["ClientId"];
                        googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];

                    })
                    .AddFacebook(facebookOptions =>
                    {
                        // Đọc cấu hình
                        IConfigurationSection facebookAuthNSection = Configuration.GetSection("Authentication:Facebook");
                        facebookOptions.AppId = facebookAuthNSection["AppId"];
                        facebookOptions.AppSecret = facebookAuthNSection["AppSecret"];
                        // Thiết lập đường dẫn Facebook chuyển hướng đến
                        facebookOptions.CallbackPath = "/dang-nhap-tu-facebook";
                    });

            services.AddSingleton<IdentityErrorDescriber, AppIdentityErrorDescriber>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ViewManageMenu", builder =>
                {
                    builder.RequireAuthenticatedUser();
                    builder.RequireRole(RoleName.Administrator);
                });
            });

            services.AddDbContext<ApDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ApDbContext")));

            services.AddTransient<CartService>();

            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();

            services.AddTransient<AdminSidebarService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Uploads")
                ),
                RequestPath = "/contents"
            });

            app.UseSession();

            app.AddStatusCodePage(); // tùy biến respone từ lỗi 400 - 599

            app.UseRouting();

            app.UseAuthentication(); // xac dinh danh tinh
            app.UseAuthorization(); // xac thuc quyen truy cap

            app.UseEndpoints(endpoints =>
            {

                // URL: /{controller}/{action}/{id?}
                // abc/xyz => controler=abc, goi method xyz

                endpoints.MapGet("/sayhi", async (context) =>
                {
                    await context.Response.WriteAsync($"Hello ASP .NET MVC");
                });


                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "first",
                    pattern: "{url:regex(^((xemsanpham)|(ViewProduct))$)}/{id?}",
                    defaults: new
                    {
                        controller = "First",
                        action = "ViewProduct"
                    }
                );

                endpoints.MapAreaControllerRoute(
                    name: "default",
                    pattern: "/{controller}/{action=Index}/{id?}",
                    areaName: "ProductManage"
                );

                endpoints.MapAreaControllerRoute(
                    name: "default",
                    pattern: "/{controller}/{action=Index}/{id?}",
                    areaName: "Contact"
                );

                //controller khong co areas
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "/{controller=Home}/{action=Index}/{id?}"

                );

                // endpoints.MapControllerRoute(
                //     name: "default",
                //     pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
