using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Sev1.UserFiles.Api
{
    // ���� �������������, �������� � ����������� � ������ Program
    public class Program
    {
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            // Run()
            // ���� ����� ��������� middleware-��������� � ���� Run[Middleware],
            // ������� ���������� � ����� ���������.��� �������,
            // �� ��������� ��� ���������� middleware � �����������
            // � ����� ��������� ��������, ��������� �� ����� ��������
            // ��������� middleware - ���������.
            // https://habr.com/ru/company/otus/blog/528692/
        }

        // ���������� ������������� ���������
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}