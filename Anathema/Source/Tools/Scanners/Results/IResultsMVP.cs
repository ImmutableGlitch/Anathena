﻿using Binarysharp.MemoryManagement;
using Binarysharp.MemoryManagement.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anathema
{
    delegate void ResultsEventHandler(Object Sender, ResultsEventArgs Args);
    class ResultsEventArgs : EventArgs
    {
        public List<String> Addresses = null;
        public List<String> Values = null;
        public List<String> Labels = null;
        public UInt64 MemorySize = 0;
    }

    interface IResultsView : IView
    {
        void DisplayResults(ListViewItem[] Items);
        void UpdateMemorySize(String MemorySize);
    }

    abstract class IResultsModel : IScannerModel
    {
        // Events triggered by the model (upstream)
        public event ResultsEventHandler EventUpdateDisplay;
        protected virtual void OnEventUpdateDisplay(ResultsEventArgs E)
        {
            EventUpdateDisplay(this, E);
        }
        public event ResultsEventHandler EventUpdateMemorySize;
        protected virtual void OnEventUpdateMemorySize(ResultsEventArgs E)
        {
            EventUpdateMemorySize(this, E);
        }

        // Functions invoked by presenter (downstream)
        public abstract void UpdateScanType(Type ScanType);
        public abstract Type GetScanType();
    }

    class ResultsPresenter : Presenter<IResultsView, IResultsModel>
    {
        new IResultsView View;
        new IResultsModel Model;

        public ResultsPresenter(IResultsView View, IResultsModel Model) : base(View, Model)
        {
            this.View = View;
            this.Model = Model;

            // Bind events triggered by the model
            Model.EventUpdateDisplay += EventUpdateDisplay;
            Model.EventUpdateMemorySize += EventUpdateMemorySize;
        }

        #region Method definitions called by the view (downstream)

        public void UpdateScanType(Type ScanType)
        {
            if (ScanType == typeof(Byte) || ScanType == typeof(UInt16) || ScanType == typeof(UInt32) || ScanType == typeof(UInt64))
                throw new Exception("Invalid type. ScanType parameter assumes signed type.");

            // Apply type change
            Type PreviousScanType = Model.GetScanType();
            Model.UpdateScanType(ScanType);

            // Enforce same sign as previous type
            var @switch = new Dictionary<Type, Action> {
                    { typeof(Byte), () => ChangeSign() },
                    { typeof(UInt16), () => ChangeSign() },
                    { typeof(UInt32), () => ChangeSign() },
                    { typeof(UInt64), () => ChangeSign() },
                };

            if (@switch.ContainsKey(PreviousScanType))
                @switch[PreviousScanType]();
        }

        public void ChangeSign()
        {
            Type ScanType = Model.GetScanType();

            var @switch = new Dictionary<Type, Action> {
                    { typeof(Byte), () => ScanType = typeof(SByte) },
                    { typeof(SByte), () => ScanType = typeof(Byte) },
                    { typeof(Int16), () => ScanType = typeof(UInt16) },
                    { typeof(Int32), () => ScanType = typeof(UInt32) },
                    { typeof(Int64), () => ScanType = typeof(UInt64) },
                    { typeof(UInt16), () => ScanType = typeof(Int16) },
                    { typeof(UInt32), () => ScanType = typeof(Int32) },
                    { typeof(UInt64), () => ScanType = typeof(Int64) },
                };

            if (@switch.ContainsKey(ScanType))
                @switch[ScanType]();

            Model.UpdateScanType(ScanType);
        }

        #endregion

        #region Event definitions for events triggered by the model (upstream)

        private void EventUpdateDisplay(Object Sender, ResultsEventArgs E)
        {
            if (E.Addresses == null || E.Values == null)
                throw new Exception("Addresses and values reqiured to pass to result display.");

            if (E.Addresses.Count != E.Values.Count)
                    throw new Exception("Unequal number of addresses and values being passed to result display");
            
            // Create empty labels if none specified
            if (E.Labels == null || E.Labels.Count != E.Addresses.Count)
                E.Labels = Enumerable.Repeat("", E.Addresses.Count).ToList();

            // Transform items to list view format to pass to the GUI
            List<ListViewItem> Items = new List<ListViewItem>();
            for (Int32 Index = 0; Index < E.Addresses.Count; Index++)
                Items.Add(new ListViewItem(new String[] { E.Addresses[Index], E.Values[Index], E.Labels[Index] }));

            View.DisplayResults(Items.ToArray());
        }

        private void EventUpdateMemorySize(Object Sender, ResultsEventArgs E)
        {
            View.UpdateMemorySize(Conversions.ByteCountToMetricSize(E.MemorySize));
        }

        #endregion
    }
}