using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.UseCase
{
    public interface ICommand<TData> : IUseCase
    {
        void Execute(TData data);
    }
}
