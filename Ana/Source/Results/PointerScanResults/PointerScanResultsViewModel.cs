﻿namespace Ana.Source.Results.PointerScanResults
{
    using Content;
    using Docking;
    using Engine;
    using Main;
    using Mvvm.Command;
    using Project;
    using Snapshots;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;
    using UserSettings;
    using Utils.Extensions;

    /// <summary>
    /// View model for the Process Selector.
    /// </summary>
    internal class PointerScanResultsViewModel : ToolViewModel, ISnapshotObserver
    {
        /// <summary>
        /// The content id for the docking library associated with this view model.
        /// </summary>
        public const String ToolContentId = nameof(PointerScanResultsViewModel);

        /// <summary>
        /// The number of elements to display on each page.
        /// </summary>
        private const Int32 PageSize = 64;

        /// <summary>
        /// Singleton instance of the <see cref="PointerScanResultsViewModel" /> class.
        /// </summary>
        private static Lazy<PointerScanResultsViewModel> pointerScanResultsViewModelInstance = new Lazy<PointerScanResultsViewModel>(
                () => { return new PointerScanResultsViewModel(); },
                LazyThreadSafetyMode.ExecutionAndPublication);

        private Type activeType;

        /// <summary>
        /// The current page of scan results.
        /// </summary>
        private Int64 currentPage;

        /// <summary>
        /// The total number of addresses.
        /// </summary>
        private Int64 addressCount;

        /// <summary>
        /// The addresses on the current page.
        /// </summary>
        private ObservableCollection<PointerScanResult> addresses;

        /// <summary>
        /// Prevents a default instance of the <see cref="PointerScanResultsViewModel" /> class from being created.
        /// </summary>
        private PointerScanResultsViewModel() : base("Pointer Scan Results")
        {
            this.ContentId = PointerScanResultsViewModel.ToolContentId;
            this.ChangeTypeSByteCommand = new RelayCommand(() => Task.Run(() => this.ChangeType(typeof(SByte))), () => true);
            this.ChangeTypeInt16Command = new RelayCommand(() => Task.Run(() => this.ChangeType(typeof(Int16))), () => true);
            this.ChangeTypeInt32Command = new RelayCommand(() => Task.Run(() => this.ChangeType(typeof(Int32))), () => true);
            this.ChangeTypeInt64Command = new RelayCommand(() => Task.Run(() => this.ChangeType(typeof(Int64))), () => true);
            this.ChangeTypeByteCommand = new RelayCommand(() => Task.Run(() => this.ChangeType(typeof(Byte))), () => true);
            this.ChangeTypeUInt16Command = new RelayCommand(() => Task.Run(() => this.ChangeType(typeof(UInt16))), () => true);
            this.ChangeTypeUInt32Command = new RelayCommand(() => Task.Run(() => this.ChangeType(typeof(UInt32))), () => true);
            this.ChangeTypeUInt64Command = new RelayCommand(() => Task.Run(() => this.ChangeType(typeof(UInt64))), () => true);
            this.ChangeTypeSingleCommand = new RelayCommand(() => Task.Run(() => this.ChangeType(typeof(Single))), () => true);
            this.ChangeTypeDoubleCommand = new RelayCommand(() => Task.Run(() => this.ChangeType(typeof(Double))), () => true);
            this.FirstPageCommand = new RelayCommand(() => Task.Run(() => this.FirstPage()), () => true);
            this.LastPageCommand = new RelayCommand(() => Task.Run(() => this.LastPage()), () => true);
            this.PreviousPageCommand = new RelayCommand(() => Task.Run(() => this.PreviousPage()), () => true);
            this.NextPageCommand = new RelayCommand(() => Task.Run(() => this.NextPage()), () => true);
            this.AddAddressCommand = new RelayCommand<PointerScanResult>((address) => Task.Run(() => this.AddAddress(address)), (address) => true);
            this.PointerScanResultsObservers = new List<IPointerScanResultsObserver>();
            this.ObserverLock = new Object();
            this.ActiveType = typeof(Int32);
            this.addresses = new ObservableCollection<PointerScanResult>();

            SnapshotManager.GetInstance().Subscribe(this);
            MainViewModel.GetInstance().Subscribe(this);

            this.UpdateScanResults();
        }

        public ICommand ChangeTypeSByteCommand { get; private set; }

        public ICommand ChangeTypeInt16Command { get; private set; }

        public ICommand ChangeTypeInt32Command { get; private set; }

        public ICommand ChangeTypeInt64Command { get; private set; }

        public ICommand ChangeTypeByteCommand { get; private set; }

        public ICommand ChangeTypeUInt16Command { get; private set; }

        public ICommand ChangeTypeUInt32Command { get; private set; }

        public ICommand ChangeTypeUInt64Command { get; private set; }

        public ICommand ChangeTypeSingleCommand { get; private set; }

        public ICommand ChangeTypeDoubleCommand { get; private set; }

        /// <summary>
        /// Gets the command to go to the first page.
        /// </summary>
        public ICommand FirstPageCommand { get; private set; }

        /// <summary>
        /// Gets the command to go to the last page.
        /// </summary>
        public ICommand LastPageCommand { get; private set; }

        /// <summary>
        /// Gets the command to go to the previous page.
        /// </summary>
        public ICommand PreviousPageCommand { get; private set; }

        /// <summary>
        /// Gets the command to go to the next page.
        /// </summary>
        public ICommand NextPageCommand { get; private set; }

        /// <summary>
        /// Gets the command to select a target process.
        /// </summary>
        public ICommand AddAddressCommand { get; private set; }

        public Type ActiveType
        {
            get
            {
                return this.activeType;
            }

            set
            {
                this.activeType = value;
                this.NotifyObservers();
                this.RaisePropertyChanged(nameof(this.ActiveType));
                this.RaisePropertyChanged(nameof(this.ActiveTypeName));
                this.RaisePropertyChanged(nameof(this.ActiveTypeImage));
            }
        }

        public String ActiveTypeName
        {
            get
            {
                switch (Type.GetTypeCode(this.ActiveType))
                {
                    case TypeCode.SByte:
                        return "SByte";
                    case TypeCode.Int16:
                        return "Int16";
                    case TypeCode.Int32:
                        return "Int32";
                    case TypeCode.Int64:
                        return "Int64";
                    case TypeCode.Byte:
                        return "Byte";
                    case TypeCode.UInt16:
                        return "UInt16";
                    case TypeCode.UInt32:
                        return "UInt32";
                    case TypeCode.UInt64:
                        return "UInt64";
                    case TypeCode.Single:
                        return "Single";
                    case TypeCode.Double:
                        return "Double";
                    default:
                        return "Invalid Type";
                }
            }
        }

        public BitmapSource ActiveTypeImage
        {
            get
            {
                switch (Type.GetTypeCode(this.ActiveType))
                {
                    case TypeCode.SByte:
                        return Images.BlueBlocks1;
                    case TypeCode.Int16:
                        return Images.BlueBlocks2;
                    case TypeCode.Int32:
                        return Images.BlueBlocks4;
                    case TypeCode.Int64:
                        return Images.BlueBlocks8;
                    case TypeCode.Byte:
                        return Images.PurpleBlocks1;
                    case TypeCode.UInt16:
                        return Images.PurpleBlocks2;
                    case TypeCode.UInt32:
                        return Images.PurpleBlocks4;
                    case TypeCode.UInt64:
                        return Images.PurpleBlocks8;
                    case TypeCode.Single:
                        return Images.OrangeBlocks4;
                    case TypeCode.Double:
                        return Images.OrangeBlocks8;
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the total number of addresses found.
        /// </summary>
        public Int64 CurrentPage
        {
            get
            {
                return this.currentPage;
            }

            set
            {
                this.currentPage = value;
                this.LoadPointerScanResults();
                this.RaisePropertyChanged(nameof(this.CurrentPage));
            }
        }

        /// <summary>
        /// Gets the total number of addresses found.
        /// </summary>
        public Int64 PageCount
        {
            get
            {
                return this.ResultCount / PointerScanResultsViewModel.PageSize;
            }
        }

        /// <summary>
        /// Gets or sets the total number of addresses found.
        /// </summary>
        public Int64 ResultCount
        {
            get
            {
                return this.addressCount;
            }

            set
            {
                this.addressCount = value;
                this.RaisePropertyChanged(nameof(this.ResultCount));
                this.RaisePropertyChanged(nameof(this.PageCount));
            }
        }

        /// <summary>
        /// Gets the address elements.
        /// </summary>
        public ObservableCollection<PointerScanResult> Addresses
        {
            get
            {
                return this.addresses;
            }
        }

        private Object ObserverLock { get; set; }

        /// <summary>
        /// Gets or sets objects observing changes in the active snapshot.
        /// </summary>
        private List<IPointerScanResultsObserver> PointerScanResultsObservers { get; set; }

        /// <summary>
        /// Gets a singleton instance of the <see cref="PointerScanResultsViewModel"/> class.
        /// </summary>
        /// <returns>A singleton instance of the class.</returns>
        public static PointerScanResultsViewModel GetInstance()
        {
            return PointerScanResultsViewModel.pointerScanResultsViewModelInstance.Value;
        }

        /// <summary>
        /// Subscribes the given object to changes in the active snapshot.
        /// </summary>
        /// <param name="snapshotObserver">The object to observe active snapshot changes.</param>
        public void Subscribe(IPointerScanResultsObserver snapshotObserver)
        {
            lock (this.ObserverLock)
            {
                if (!this.PointerScanResultsObservers.Contains(snapshotObserver))
                {
                    this.PointerScanResultsObservers.Add(snapshotObserver);
                    snapshotObserver.Update(this.ActiveType);
                }
            }
        }

        /// <summary>
        /// Unsubscribes the given object from changes in the active snapshot.
        /// </summary>
        /// <param name="snapshotObserver">The object to observe active snapshot changes.</param>
        public void Unsubscribe(IPointerScanResultsObserver snapshotObserver)
        {
            lock (this.ObserverLock)
            {
                if (this.PointerScanResultsObservers.Contains(snapshotObserver))
                {
                    this.PointerScanResultsObservers.Remove(snapshotObserver);
                }
            }
        }

        /// <summary>
        /// Recieves an update of the active snapshot.
        /// </summary>
        /// <param name="snapshot">The active snapshot.</param>
        public void Update(Snapshot snapshot)
        {
            this.ResultCount = snapshot == null ? 0 : snapshot.GetElementCount();
            this.CurrentPage = 0;
        }

        /// <summary>
        /// Loads the results for the current page.
        /// </summary>
        private void LoadPointerScanResults()
        {
            this.RaisePropertyChanged(nameof(this.Addresses));
        }

        /// <summary>
        /// Updates the values for the current scan results.
        /// </summary>
        private void UpdateScanResults()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Boolean readSuccess;
                    this.Addresses.ForEach(x => x.ElementValue = EngineCore.GetInstance().OperatingSystemAdapter.Read(this.ActiveType, x.ElementAddress, out readSuccess).ToString());
                    this.RaisePropertyChanged(nameof(this.Addresses));
                    Thread.Sleep(SettingsViewModel.GetInstance().ResultReadInterval);
                }
            });
        }

        private void ChangeType(Type newType)
        {
            this.ActiveType = newType;
        }

        /// <summary>
        /// Goes to the first page of results.
        /// </summary>
        private void FirstPage()
        {
            this.CurrentPage = 0;
        }

        /// <summary>
        /// Goes to the last page of results.
        /// </summary>
        private void LastPage()
        {
            this.CurrentPage = this.PageCount;
        }

        /// <summary>
        /// Goes to the previous page of results.
        /// </summary>
        private void PreviousPage()
        {
            this.CurrentPage = this.CurrentPage == 0 ? this.CurrentPage : this.CurrentPage - 1;
        }

        /// <summary>
        /// Goes to the next page of results.
        /// </summary>
        private void NextPage()
        {
            this.CurrentPage = this.CurrentPage >= this.PageCount ? this.CurrentPage : this.CurrentPage + 1;
        }

        /// <summary>
        /// Adds the given scan result address to the project explorer.
        /// </summary>
        /// <param name="scanResult">The scan result to add to the project explorer.</param>
        private void AddAddress(PointerScanResult scanResult)
        {
            ProjectExplorerViewModel.GetInstance().AddSpecificAddressItem(scanResult.ElementAddress, typeof(Int32));
        }

        /// <summary>
        /// Notify all observing objects of an active type change.
        /// </summary>
        private void NotifyObservers()
        {
            lock (this.ObserverLock)
            {
                foreach (IPointerScanResultsObserver observer in this.PointerScanResultsObservers)
                {
                    observer.Update(this.ActiveType);
                }
            }
        }
    }
    //// End class
}
//// End namespace