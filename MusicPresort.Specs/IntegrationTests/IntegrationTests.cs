using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MusicPresort.Specs;

namespace MusicPresort
{
    public class IntegrationTests
    {
        private IFileSystem _fileSystem;

        private void InitialiseMockFileSystem()
        {
            var mock = new Mock<IFileSystem>();
            mock.Setup(m => m.GetDirectories(It.IsAny<string>())).Returns(() => null);
        }

        public void Sandwich()
        {
            //InitialiseMockFileSystem();

            //var x = new OrchestratorThingy();

            //foreach (var dir in _fileSystem.GetDirectories(@"A:\Test"))
            //{
            //    x.PreprocessFolder();
            //}

            //x.PreprocessFolder();

        }
    }

    public interface IFileSystem
    {
        IList<string> GetDirectories(string rootPath);
    }

    class FileSystem : IFileSystem
    {
        public IList<string> GetDirectories(string rootPath)
        {
            return Directory.GetDirectories(rootPath);
        }
    }

}
