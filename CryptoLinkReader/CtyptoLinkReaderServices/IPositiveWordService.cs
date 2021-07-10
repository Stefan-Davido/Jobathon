using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CtyptoLinkReaderServices
{
    public interface IPositiveWordService
    {
        IEnumerable<PositiveWord> AllPositiveWords();
    }
}
