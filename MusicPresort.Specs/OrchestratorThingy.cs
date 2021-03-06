﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MusicPresort.Specs;

namespace MusicPresort
{
    public class OrchestratorThingy
    {
        public List<PreprocessResult> Results { get; private set; }

        public List<MusicFolder> GoodFolders { get; private set; }
        public List<MusicFolder> BadFolders { get; private set; }
        public string RootFolder { get; set; }

        private IFolderAnalyser _analyser;
        private IFolderProcessor _processor;

        public OrchestratorThingy() : this(
            new FolderProcessor(), new FolderAnalyser()){}

        public OrchestratorThingy(IFolderProcessor processor, IFolderAnalyser analyser)
        {
            _processor = processor;
            _analyser = analyser;

            GoodFolders = new List<MusicFolder>();
            BadFolders = new List<MusicFolder>();
            Results = new List<PreprocessResult>();
        }
       
        public void ProcessFolder(MusicFolder folder)
        {
            if (folder.Analysis != null) return;

            if(!_analyser.IsValid(folder)) _processor.Process(folder);

            if (!_analyser.IsValid(folder))
                BadFolders.Add(folder); // TODO: probably change these tests
            else
                GoodFolders.Add(folder);

            folder.Analysis = new AnalysisCache();
        }
               
    }

    public class PreprocessResult
    {
        public MusicFolder Folder { get; set; }
        public Date Date { get; set; }
    }
}