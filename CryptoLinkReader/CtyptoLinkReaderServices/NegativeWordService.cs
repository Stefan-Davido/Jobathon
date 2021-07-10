using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Configuration;
using Entities;
using CryptoLinkReaderRepository.Interfaces;

namespace CtyptoLinkReaderServices
{
    public class NegativeWordService : InegativeService
    {
        private readonly INegativeWordRepository _negativeWordRepository;
        public NegativeWordService(INegativeWordRepository negativeWordRepository)
        {
            _negativeWordRepository = negativeWordRepository;
        }
            
        public IEnumerable<NegativeWord> NegativeWords()
        {
            var result = _negativeWordRepository.AllNegativeWords();
            return result;
        }


        public String LoadInformation(String url)
        {
             //private const int TIMEOUT = 30;

             HttpWebRequest myWebRequest = null;
            HttpWebResponse myWebResponse = null;
            Stream receiveStream = null;
            Encoding encode = null;
            StreamReader readStream = null;
            string text = null;

            try
            {
                myWebRequest = HttpWebRequest.Create(url) as HttpWebRequest;

                //myWebRequest.Timeout = TIMEOUT;
                //myWebRequest.ReadWriteTimeout = TIMEOUT;

                myWebResponse = myWebRequest.GetResponse() as HttpWebResponse;
                receiveStream = myWebResponse.GetResponseStream();
                encode = System.Text.Encoding.GetEncoding("utf-8");
                readStream = new StreamReader(receiveStream, encode);
                text = readStream.ReadToEnd().ToLower();
                if (readStream != null) readStream.Close();
                if (receiveStream != null) receiveStream.Close();
                if (myWebResponse != null) myWebResponse.Close();
            }
            catch (Exception)
            {
                //Do Something
            }
            finally
            {
                readStream = null;
                receiveStream = null;
                myWebResponse = null;
                myWebRequest = null;
            }
            return text;
        }
    }
}
