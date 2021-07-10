using CryptoLinkReaderRepository.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CtyptoLinkReaderServices
{
    public class PositiveWordRepositoryService : IPositiveWordService
    {
        private readonly IPositiveWordRepository _positiveWordRepository;
        public PositiveWordRepositoryService(IPositiveWordRepository negativeWordRepository)
        {
            _positiveWordRepository = negativeWordRepository;
        }

        public IEnumerable<PositiveWord> AllPositiveWords()
        {
            var result = _positiveWordRepository.AllPositiveWords();
            return result;
        }
    }
}
