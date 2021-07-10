using Bookstore.Data;
using CryptoLinkReaderRepository.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoLinkReaderRepository
{
    public class PoritiveWordRepository : IPositiveWordRepository
    {

        private readonly DataContext _dataContext;

        public PoritiveWordRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<PositiveWord> AllPositiveWords()
        {
            var result = _dataContext.PositiveWord.AsEnumerable();
            return result;
        }
    }
}
