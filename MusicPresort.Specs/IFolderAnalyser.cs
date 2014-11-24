using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using MusicPresort.Specs;
using ServiceStack.Text;

namespace MusicPresort
{
    public interface IFolderAnalyser
    {
        AnalysisCache Analyse(MusicFolder folder);
    }

    public enum AnalysisError
    {
        None,
        NoMp3sFound,
        MissingArtistNames,
        MissingAlbumTitles,
        MissingTrackNumbers,
        InvalidTrackNumbers,
        InvalidTrackNumberSequence,
        MissingTrackTitles,
        MixedArtistNames,
        MixedAlbumTitles,
        MissingTags,
    }

    public class FolderAnalyser : IFolderAnalyser
    {
        private readonly IFileSystem _fileSystem;

        private readonly Func<MusicFile, bool> IsArtistMissing;
        private readonly Func<MusicFile, bool> IsAlbumMissing;
        private readonly Func<MusicFile, bool> IsTrackNumberMissing;
        private readonly Func<MusicFile, bool> IsTrackNumberInvalid;
        private readonly Func<MusicFolder, bool> IsTrackNumberSequenceIncomplete;
        private readonly Func<MusicFile, bool> IsTrackNameMissing;

        public AnalysisCache Analyse(MusicFolder folder)
        {
            var result = new AnalysisCache(folder.FullPath);
            
            foreach (var file in folder.Files)
            {
                result.Files.Add(new DataFile{FullPath = file.Path});
            }

            foreach (var error in GetErrors(folder))
            {
                result.Errors.Add(error);
            }

            folder.Analysis = result;

            _fileSystem.File.WriteAllText(folder.AnalysisCachePath(), JsonSerializer.SerializeToString(result));

            return result;
        }

        public IEnumerable<AnalysisError> GetErrors(MusicFolder folder)
        {
            if(folder.Files.Any(f=>f.Tag == null))
            {
                yield return AnalysisError.MissingTags;
                yield break;
            }

            if (!folder.Files.Any()) yield return AnalysisError.NoMp3sFound;

            if (folder.Files.Any(IsArtistMissing)) yield return AnalysisError.MissingArtistNames;

            if (folder.Files.Any(IsAlbumMissing)) yield return AnalysisError.MissingAlbumTitles;

            if (folder.Files.Any(IsTrackNumberMissing)) yield return AnalysisError.MissingTrackNumbers;

            if (folder.Files.Any(IsTrackNameMissing)) yield return AnalysisError.MissingTrackTitles;

            if (folder.Files.Any(IsTrackNumberInvalid)) yield return AnalysisError.InvalidTrackNumbers;

            if (IsTrackNumberSequenceIncomplete(folder)) yield return AnalysisError.InvalidTrackNumberSequence;

            if (folder.Files.Any(x => x.Tag.ArtistName != folder.Files[0].Tag.ArtistName)) yield return AnalysisError.MixedArtistNames;

            if (folder.Files.Any(x => x.Tag.AlbumTitle != folder.Files[0].Tag.AlbumTitle)) yield return AnalysisError.MixedAlbumTitles;            
        }

        public FolderAnalyser(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;

            IsArtistMissing = f => string.IsNullOrEmpty(f.Tag.ArtistName);
            IsAlbumMissing = f => string.IsNullOrEmpty(f.Tag.AlbumTitle);
            IsTrackNumberMissing = f => !f.Tag.TrackNumber.HasValue;
            IsTrackNumberInvalid = f => !f.Tag.TrackNumber.HasValue || f.Tag.TrackNumber.Value <= 0;
            IsTrackNumberSequenceIncomplete = f =>
            {
                int i = 1;
                foreach (var file in f.Files.OrderBy(x => x.Tag.TrackNumber))
                {
                    if (file.Tag.TrackNumber != i) return true;
                    i++;
                }
                return false;
            };
            IsTrackNameMissing = f => string.IsNullOrWhiteSpace(f.Tag.TrackTitle);
        }
    }
}