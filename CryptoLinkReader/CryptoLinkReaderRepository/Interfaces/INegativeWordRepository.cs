using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoLinkReaderRepository.Interfaces
{
    public interface INegativeWordRepository
    {
        IEnumerable<NegativeWord> AllNegativeWords();
    }
}
