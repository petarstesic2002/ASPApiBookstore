using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.UseCase
{
    public interface IUserUseCase
    {
        int Id {  get; }
        string Email { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
