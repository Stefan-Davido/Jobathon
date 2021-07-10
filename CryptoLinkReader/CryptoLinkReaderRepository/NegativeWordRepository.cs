using Bookstore.Data;
using CryptoLinkReaderRepository.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoLinkReaderRepository
{
    public class NegativeWordRepository : INegativeWordRepository
    {
        private readonly DataContext _dataContext;

        public NegativeWordRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public IEnumerable<NegativeWord> AllNegativeWords()
        {
            var result = _dataContext.NegativeWord.AsEnumerable();
            return result;
        }
    }
}
