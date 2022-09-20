using System.Threading.Tasks;

namespace FractalzBackendScheduler.Application.Abstractions
{
    public interface IEmailService
    {
        Task SendEmail(string email, string subject, string message);
        
    }
}