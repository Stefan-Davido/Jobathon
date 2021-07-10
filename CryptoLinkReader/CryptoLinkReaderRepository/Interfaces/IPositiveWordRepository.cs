using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoLinkReaderRepository.Interfaces
{
    public interface IPositiveWordRepository
    {
        IEnumerable<PositiveWord> AllPositiveWords();
    }
}
