using IoReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace IoReader.Models
{
    public class BookModel : IContentModel, IDisposable
    {
        private bool disposedValue;

        public Stream ContentsStream { get; set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    ContentsStream.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}