using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CtyptoLinkReaderServices
{
    public interface InegativeService
    {
        IEnumerable<NegativeWord> NegativeWords();
    }
}
