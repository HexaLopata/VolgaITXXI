﻿namespace VolgaIT.Views
{
    public abstract class ViewFactory
    {
        public abstract IMainView MainView { get; }
        public abstract IAnalyzerView AnalyzerView { get; }
    }
}
