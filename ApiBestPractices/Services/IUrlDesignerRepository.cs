using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ApiBestPractices.Services
{
    public interface IUrlDesignerRepository
    {
        
        public string getUrl(string PathUrl);
    }
}
