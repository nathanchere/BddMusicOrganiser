using System;
using System.Collections.Generic;
using MusicPresort.Specs;

namespace MusicPresort
{
    public class OrchestratorThingy
    {
        public List<PreprocessResult> Results { get; private set; }

        public List<MusicFolder> GoodFolders { get; private set; }
        public List<MusicFolder> BadFolders { get; private set; }

        private IFolderProcessor _processor;

        public OrchestratorThingy() : this(
            new FolderProcessor()
        ){}

        public OrchestratorThingy(IFolderProcessor processor)
        {
            _processor = processor;

            GoodFolders = new List<MusicFolder>();
            BadFolders = new List<MusicFolder>();
            Results = new List<PreprocessResult>();    
        }
       
        public void ProcessFolder(MusicFolder folder)
        {
            if (folder.Analysis != null) return;

            if(!_processor.IsValid(folder))
                BadFolders.Add(folder);
            else
                GoodFolders.Add(folder);

            folder.Analysis = new AnalysisCache();
        }
        
        /// <summary>
        /// Basic/shallow verification of folder suitability for processing
        /// </summary>
        public void PreprocessFolder(MusicFolder folder)
        {            
            try
            {
                if (string.IsNullOrEmpty(folder.FileName)) return;
                folder.Date = new Date(folder.FileName.Split(' ')[0]);
            }
            catch (Exception ex)
            {
                // TODO: WTF was I doing here
            }            
        }
    }

    public class PreprocessResult
    {
        public MusicFolder Folder { get; set; }
        public Date Date { get; set; }
    }
}