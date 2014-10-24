using System;
using System.Linq;
using MusicPresort.Specs;

namespace MusicPresort
{
    public interface IFolderProcessor
    {
        void Process(MusicFolder folder);
    }

    public class FolderProcessor : IFolderProcessor
    {
        public FolderProcessor()
        {
            
        }       

        public void Process(MusicFolder folder)
        {
            // TODO: ?
        }
    }
}