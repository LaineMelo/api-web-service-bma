using Microsoft.EntityFrameworkCore;

namespace api_web_service_bma.Models
{
    public interface IApiBeneficiario : IDisposable
    {
        DbSet<Beneficiario> Beneficiarios { get; }
        int SaveChanges();
        void MarkAsModified(Beneficiario item);
    }
}
