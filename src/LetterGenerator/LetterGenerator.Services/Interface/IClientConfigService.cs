using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterGenerator.Services.Interface
{
    public interface IClientConfigService
    {
        Task LoadClientSettingsAsync(object clientId);
    }
}
