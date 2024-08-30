using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.UseCase
{
    public interface IUserUseCaseProvider
    {
        public IUserUseCase getUser();
    }
}
