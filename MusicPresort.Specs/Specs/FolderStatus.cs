using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;
using TechTalk.SpecFlow;
using Xunit;

namespace MusicPresort.Specs
{
    [Binding, Scope(Feature = "Folder status")]
    class FolderStatus
    {
        public FolderStatus()
        {
            _fixture = new Fixture();

            _fileSystem = new MockFileSystem();
            _analyser = new FolderAnalyser(_fileSystem);            
        }

        private Fixture _fixture;        
        private readonly IFolderAnalyser _analyser;
        private MusicFolder _folder;
        private readonly MockFileSystem _fileSystem;
        private string _folderPath;

        #region Helpers
        private void AddFile(string artistName, string albumTitle, string trackTitle, int? trackNumber)
        {
            throw new NotImplementedException();
            //_folder._files.Add(
            //    new MusicFile{
            //        ArtistName = artistName,
            //        AlbumTitle = albumTitle,
            //        TrackTitle = trackTitle,
            //        TrackNumber = trackNumber
            //    }
            //);
        }

        #endregion

        #region Given
        [Given(@"the folder has no analysis cache")]
        public void GivenTheFolderHasNoAnalysisCache()
        {
            _folder.Analysis = null;
        }

        [Given(@"the folder has an analysis cache")]
        public void GivenTheFolderHasAnAnalysisCache()
        {
            _folder.Analysis = _fixture.Build<AnalysisCache>().Create();
        }

        [Given(@"I have a music folder")]
        public void GivenIHaveAMusicFolder()
        {
            _folder = _fixture.Create<MusicFolder>();
            _folderPath = string.Format(@"C:\{1}\{0}", _folder.FullPath, _fixture.Create<string>());
            _folder.FullPath = _folderPath;
        }

        [Given(@"the music folder hasn't been processed")]
        public void GivenTheMusicFolderHasnTBeenProcessed()
        {            
            _folder.Analysis = null;
        }

        [Given(@"the target folder on disk contains specific files")]
        public void GivenTheMusicFolderContainsSpecificFiles()
        {
            foreach(var file in _fixture.CreateMany<string>(_folderPath + Path.DirectorySeparatorChar, 5))
            {
                _fileSystem.AddFile(file, new MockFileData(_fixture.Create<string>()));          
            }            
        }

        #endregion

        #region When
        [When(@"I analyse the folder")]
        public void WhenIAnalysesTheFolder()
        {
            _analyser.Analyse(_folder);
        }
        #endregion

        #region Then       
        [Then(@"the analysis should list the specific files relative to the root path")]
        public void ThenAnalysisCacheShouldListTheSpecificFilesRelativeToTheRootPath()
        {
            foreach (var file in _fileSystem.AllFiles)
            {
                
            }
        }

        [Then(@"the analysis should contain the root path of the music folder")]
        public void ThenAnalysisCacheShouldContainTheRootPathOfTheMusicFolder()
        {
            Assert.Equal(_folder.FullPath, _folder.Analysis.RootPath);
        }


        [Then(@"the music folder should contain the analysis results")]
        public void ThenTheMusicFolderShouldCacheTheAnalysisResults()
        {
            Assert.NotNull(_folder.Analysis);
        }

        [Then(@"the analysis should list the files in the music folder")]
        public void ThenAnalysisCacheShouldListTheFilesInTheMusicFolder()
        {            
            Assert.Equal(_folder.Analysis.Files.Count, _folder.Files.Count);
            foreach (var file in _folder.Files)
            {
                Assert.Contains(file.Path, _folder.Analysis.Files.Select(x=>x.FullPath));
            }
        }

        [Then(@"the cache should be written to disk")]
        public void ThenTheCacheShouldBeWrittenToDisk()
        {
            var expectedPath = Path.Combine(_folder.Analysis.RootPath, AnalysisCache.FileName);
            
            Assert.True(_fileSystem.File.Exists(_folder.AnalysisCachePath()));
        }

        #endregion
    }
}
