using System;
using System.IO;

namespace IoReader.Models
{
    public class BookModel : IContentModel, IDisposable
    {
        private bool _disposedValue;

        public Stream ContentsStream { get; set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    ContentsStream.Dispose();
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}